using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Odyssey_Uninstall
{
    public partial class OdysseyUninstall : Form
    {
        //Create bools to check the state of the Form buttons
        public static bool NavigatorCheck;
        public static bool JudgeCheck;
        public static bool CacheCheck;
        public static bool AllCheck;

        public OdysseyUninstall()
        {
            InitializeComponent();
        }

        private void Odyssey_Uninstall(object sender, EventArgs e)
        {
        }

        private void Uninstall_btn(object sender, EventArgs e)
        {
            //When a user hits the button we need to verify the checked state of the buttons and add them to our list so we can send the variables to the new form.
            List<CheckBox> checkBoxState = new List<CheckBox>() { checkboxJudge, checkboxNavigator, checkboxCache, checkboxAll };
            NavigatorCheck = checkboxNavigator.Checked;
            JudgeCheck = checkboxJudge.Checked;
            CacheCheck = checkboxCache.Checked;
            AllCheck = checkboxAll.Checked;
            //Here we add all the checked states by one for the number of items. If it's greater then one proceed to the new form. 
            int total = 0;
            foreach(CheckBox item in checkBoxState)
            {
                if (item.Checked)
                {
                    total++;
                }
            }
            if(total >= 1)
            {
                //Initialize the new form and hide this first form. Users don't need to see the first one anymore
                Uninstall_Form form2 = new Uninstall_Form();
                this.Hide();
                form2.Show();
            }
            else
            {
                //If users don't select a check box we need to warn them and do nothing
                MessageBox.Show("Please Select Something To Uninstall");
            }
                

        }

        private void ExitBtn(object sender, EventArgs e)
        {
            //Exit the form if the user hits the exit button
            Environment.Exit(0);
        }

        //Whenever a user hits the All button we need to processes all check boxes to visually update for the user. 
        private void checkboxAll_CheckedChanged(object sender, EventArgs e)
        {

            List<CheckBox> checkBoxState = new List<CheckBox>() { checkboxJudge, checkboxNavigator, checkboxCache, checkboxAll };
            foreach (CheckBox item in checkBoxState)
            {
                if (checkboxAll.Checked)
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }
        
    }
}
