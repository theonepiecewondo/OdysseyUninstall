using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;

namespace Odyssey_Uninstall
{
    public partial class Uninstall_Form : Form
    {

        //Make a custome Error Handler that will spill into our Form Log if a error is encounterd.
        //Need this event handler to dynamically handle the errors and add new ones if need be
        private void HandleError(string errorMessage, string errorSource)
        {
            textBox1.SelectionColor = Color.Red;
            textBox1.AppendText("**** ERROR ****\r\n");
            textBox1.AppendText("Error Source: " + errorSource + Environment.NewLine);
            textBox1.AppendText("Error: " + errorMessage + Environment.NewLine);
            textBox1.SelectionColor = Color.Black;
        }

        private void Delete_Keys(string[] Keys, RegistryKey type, string inclusion)
        {   
            //Handle a list of keys  and the type to be deleted. Also includes a inclusion based on what the user selected. We don't want to delete the wrong keys
            foreach (string key in Keys)
            {
                if (key.Contains(inclusion)) //Check if the keys contain a inclusion defined on our checked states
                {

                    type.DeleteSubKeyTree(key); //Take the key type hkcu, hklm, hku, or hklm64 and deleted the key.
                    textBox1.AppendText("Deleting: " + type.Name + "\\" + key + Environment.NewLine);
                }

            }
        }

        private void Odyssey_Registry(List<string> paths, string inclusion)
        {
            textBox1.SelectionColor = Color.Blue;
            textBox1.AppendText("***** Deleting Registry Keys *****\r\n");

            //Open the registry and assign a value so we know where to look.
            RegistryKey user_key = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default);

            //add our keys into a list so our program can properly handle them
            List<string> keys = new List<string>(user_key.GetSubKeyNames());
            for(int i = 0; i < keys.Count; i++)
            {
                foreach(string path in paths)
                { 
                    //For each key we need to use the paths defined by our checkboxes to look for and delete.
                    string UserFullKeyPath = keys[i] + "\\" + path;
                    string LocalKeyPath = "HKEY_LOCAL_MACHINE\\" + path;

                    //All tyler tech keys are located in these hives so we must porcess them all. The user hive is special and needs to be processed differently.
                    RegistryKey Ukey = Registry.Users.OpenSubKey(UserFullKeyPath, true);
                    RegistryKey lm_key = Registry.LocalMachine.OpenSubKey(path, true);
                    RegistryKey lm64_key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(path, true);

                    //Processes each set of keys if they exist in the paths and ignore them if null.
                    if (Ukey != null)
                    {
                        string[] Ukeys = Ukey.GetSubKeyNames();
                        Delete_Keys(Ukeys, Ukey, inclusion);
                    }
                    if (lm_key != null)
                    {
                        string[] lm = lm_key.GetSubKeyNames();
                        Delete_Keys(lm, lm_key, inclusion);
                    }
                    if (lm64_key != null)
                    {
                        string[] lm64 = lm64_key.GetSubKeyNames();
                        Delete_Keys(lm64, lm64_key, inclusion);
                    }
                }


            }
        }

        private void folderSearchDestroy(string path, string execption, bool Judge)
        {
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                try
                {
                    if (folder.Contains(execption))
                    {
                        Debug.WriteLine("Exception: " + folder);

                    }
                    else
                    {
                        if (Judge && folder.Contains("Unity"))
                        {
                            Debug.WriteLine("Exception: " + folder);
                        }
                        else
                        {
                            textBox1.AppendText("Deleting: " + folder + Environment.NewLine);
                            Directory.Delete(folder, true);
                        }
                    }
                }
                catch (IOException ex)
                {
                    HandleError(ex.Message, "Folder");
                }
                catch (UnauthorizedAccessException ex)
                {
                    HandleError(ex.Message, "Folder");
                }
                catch (Exception ex)
                {
                    HandleError(ex.Message, "Folder");
                }
            }
        }

        private void cmdUninstall(string command)
        {
            try
            {
                //Here we are using the cmd command from our function to use the msi uninstaller to uninstall Odyssey or Judge Edition letting windows do some work for us.
                //We can use the GUID of Odyssey to accomplish this windows function.
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C " + command;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit(); //wait for command to finish so our folder and registry functions don't overlap the msi process

            }
            catch (Exception ex)
            {
                HandleError(ex.Message, "Error in Killing Processes");
            }
        }

        private void Navigator_Uninstall(List<string> Odyssey_paths, string execption, bool Judge)
        {

            textBox1.SelectionColor = Color.Blue;
            textBox1.AppendText("***** Deleting Files and Folders *****\r\n");

            //simple for loop to delete folders for all of our paths using our Folder Search and Destroy Function
            foreach (string path in Odyssey_paths)
            {
                try
                {
                    folderSearchDestroy(path, execption, Judge);
                }
                catch { }

            }

        }

        private void Cache_Uninstall()
        {
            //Need to create two list so we can combine them later as one list to mark for deletion
            List<string> UserFolders = new List<string>();
            List<string> RoamingFolders = new List<string>();

            //Get the user directories and add them to the list. Then delete All Users from the list since that isn't part of what we want. Remove Public and Default as well so we don't touch those folders
            UserFolders = Directory.GetDirectories(@"C:\Users").ToList();
            UserFolders.Remove(@"C:\Users\All Users");
            UserFolders.Remove(@"C:\Users\Public");
            UserFolders.Remove(@"C:\Users\Default");

            for (int i = 0; i < UserFolders.Count; i++)
            {
                //Need to take every individual user and append the local and roaming so we can clear the Tyler Tech files from them.
                string user = UserFolders[i];
                UserFolders[i] = user + @"\AppData\Local\";
                RoamingFolders.Add(user + @"\AppData\Roaming");

            }
            UserFolders = UserFolders.Concat(RoamingFolders).ToList(); //combine our list together
            textBox1.SelectionColor = Color.Blue;
            textBox1.AppendText("***** Clearing Cache Folders For All Users *****\r\n");

            //for each user we need to use the paths added above and compare them with the directories to find all folders containing tyler
            foreach (var user in UserFolders)
            {
                try
                {
                    string[] folders = Directory.GetDirectories(user); //Get actual user directories
                    foreach (string folder in folders)
                    {
                        if (folder.Contains("Tyler")) //compare actual folders for containing tyler so we can then delete them. Don't want to delete something accidentally 
                        {
                            textBox1.AppendText("Deleting: " + folder + Environment.NewLine);
                            Directory.Delete(folder, true);
                        }
                    }
                }
                //Catch different error and send them to our handler. We might just be able to condense this sense it doesn't handle anything special between them all.
                catch (IOException ex)
                {
                    HandleError(ex.Message, "Error In Deleting The Cache");
                }
                catch (UnauthorizedAccessException ex)
                {
                    HandleError(ex.Message, "Error In Deleting The Cache");
                }
                catch (Exception ex)
                {
                    HandleError(ex.Message, "Error In Deleting The Cache");
                }
            }
        }

        public Uninstall_Form()
        {
            InitializeComponent();
        }

        private void ExitBtn(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Uninstall_Form_Enter(object sender, EventArgs e)
        {
            //Hard code the paths needed to be deleted, ideally this should be made dynamic
            List<string> Odyssey_paths = new List<string> { @"C:\Program Files\Tyler Technologies", @"C:\Program Files\Common Files\Tyler Technologies", @"C:\Program Files (x86)\Common Files\Tyler Technologies", @"C:\ProgramData\Tyler Technologies", @"C:\Program Files (x86)\Tyler Technologies" };
            List<string> Registry_Paths = new List<string> { @"SOFTWARE\Tyler Technologies\", @"SOFTWARE\WOW6432Node\Tyler Technologies\" };

            //Shutdown all processes related to Odyssey and Judge Edition
            Process[] processes = Process.GetProcesses();
            string[] targetProcessNames = new string[] { "Tyler.SessionWorks.Judges", "OdySys", "Odyssey", "Unity" };

            foreach (Process pcress in processes)
            {
                if (targetProcessNames.Contains(pcress.ProcessName))
                {
                    pcress.Kill();
                }
            }

            if ((OdysseyUninstall.NavigatorCheck && !OdysseyUninstall.JudgeCheck) || (OdysseyUninstall.NavigatorCheck && OdysseyUninstall.CacheCheck && !OdysseyUninstall.JudgeCheck))
            {
                //We use the guid of Navigator to uninstall it first and then delete all the left over scraps manually
                cmdUninstall("msiexec.exe /x {DC334CF1-AFE6-4512-947C-8EAA0F03A8E3}");
                textBox1.AppendText("Navigator has been uninstalled.... looking for remnants \r\n");

                //Remove a path since these files seem to be necessary for Judge Edition to function without Navigator
                Odyssey_paths.Remove(@"C:\Program Files (x86)\Common Files\Tyler Technologies");

                //Send Odyssey Navigator paths and the exception to avoid to the function. We want to avoid all folders and files with Judge in them
                Navigator_Uninstall(Odyssey_paths, "Judge", OdysseyUninstall.NavigatorCheck);

                //Remove registry entries related to Odyssey and Unity but leave Judge Edition ones alone
                Odyssey_Registry(Registry_Paths, "Odyssey");
                Odyssey_Registry(Registry_Paths, "Unity");
                Cache_Uninstall();
                Debug.WriteLine("Odyssey Check");
            }
            else if (OdysseyUninstall.JudgeCheck && !OdysseyUninstall.NavigatorCheck || (OdysseyUninstall.JudgeCheck && OdysseyUninstall.CacheCheck && !OdysseyUninstall.NavigatorCheck))
            {
                //Reuse our odyssey uninstall function but don't touch navigator. Instead uninstall Judge Edition. Making this uninstaller dynamic.
                Navigator_Uninstall(Odyssey_paths, "Odyssey", OdysseyUninstall.JudgeCheck);
                Debug.WriteLine("Judge Check");
            }
            else if (OdysseyUninstall.CacheCheck && !OdysseyUninstall.NavigatorCheck && !OdysseyUninstall.JudgeCheck)
            {
                Cache_Uninstall();

            }
            else if (OdysseyUninstall.NavigatorCheck && OdysseyUninstall.JudgeCheck && OdysseyUninstall.CacheCheck)
            {
                //We hardcode a simple list since we don't need to avoid anything special in this registry path. Remove all tyler related paths
                List<string> Tyler_Registry_Paths = new List<string> { @"SOFTWARE\", @"SOFTWARE\WOW6432Node\" };

                //Combine all our functions to remove everything. 
                cmdUninstall("msiexec.exe /x {DC334CF1-AFE6-4512-947C-8EAA0F03A8E3}");
                Navigator_Uninstall(Odyssey_paths, "Judge", OdysseyUninstall.NavigatorCheck);
                Navigator_Uninstall(Odyssey_paths, "Odyssey", OdysseyUninstall.JudgeCheck);
                Cache_Uninstall();
                Odyssey_Registry(Tyler_Registry_Paths, "Tyler Technologies");
                Debug.WriteLine("Everything check");
            }
            else
            {
                Debug.WriteLine("Nothing Selected");
            }

            //Poorly implemented Progress bar that is for user enjoyment. 
            progressBar1.Maximum = 1000;
            progressBar1.Step = 1;
            for (int i = 0; i < 1000; i++)
            {
                double pow = Math.Pow(i, i);
                progressBar1.PerformStep();
            }
            textBox1.SelectionColor = Color.Green;
            textBox1.AppendText("***** Done *****\r\n");
        }
        private void Uninstall_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
