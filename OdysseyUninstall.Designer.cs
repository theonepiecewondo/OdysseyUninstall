
namespace Odyssey_Uninstall
{
    partial class OdysseyUninstall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdysseyUninstall));
            this.checkboxNavigator = new System.Windows.Forms.CheckBox();
            this.checkboxJudge = new System.Windows.Forms.CheckBox();
            this.checkboxCache = new System.Windows.Forms.CheckBox();
            this.uninstall_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkboxAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkboxNavigator
            // 
            this.checkboxNavigator.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkboxNavigator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxNavigator.Location = new System.Drawing.Point(4, 107);
            this.checkboxNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.checkboxNavigator.Name = "checkboxNavigator";
            this.checkboxNavigator.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkboxNavigator.Size = new System.Drawing.Size(184, 30);
            this.checkboxNavigator.TabIndex = 1;
            this.checkboxNavigator.Text = "Odyssey Navigator";
            this.checkboxNavigator.UseVisualStyleBackColor = true;
            // 
            // checkboxJudge
            // 
            this.checkboxJudge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkboxJudge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxJudge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkboxJudge.Location = new System.Drawing.Point(4, 233);
            this.checkboxJudge.Margin = new System.Windows.Forms.Padding(4);
            this.checkboxJudge.Name = "checkboxJudge";
            this.checkboxJudge.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkboxJudge.Size = new System.Drawing.Size(252, 30);
            this.checkboxJudge.TabIndex = 2;
            this.checkboxJudge.Text = "Odyssey Judge Edition";
            this.checkboxJudge.UseVisualStyleBackColor = true;
            // 
            // checkboxCache
            // 
            this.checkboxCache.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkboxCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxCache.Location = new System.Drawing.Point(4, 170);
            this.checkboxCache.Margin = new System.Windows.Forms.Padding(4);
            this.checkboxCache.Name = "checkboxCache";
            this.checkboxCache.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkboxCache.Size = new System.Drawing.Size(184, 30);
            this.checkboxCache.TabIndex = 3;
            this.checkboxCache.Text = "Odyssey Cache";
            this.checkboxCache.UseVisualStyleBackColor = true;
            // 
            // uninstall_btn
            // 
            this.uninstall_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uninstall_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uninstall_btn.Location = new System.Drawing.Point(39, 18);
            this.uninstall_btn.Margin = new System.Windows.Forms.Padding(4);
            this.uninstall_btn.Name = "uninstall_btn";
            this.uninstall_btn.Size = new System.Drawing.Size(173, 62);
            this.uninstall_btn.TabIndex = 4;
            this.uninstall_btn.Text = "Uninstall";
            this.uninstall_btn.UseVisualStyleBackColor = true;
            this.uninstall_btn.Click += new System.EventHandler(this.Uninstall_btn);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(290, 18);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 62);
            this.button2.TabIndex = 5;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ExitBtn);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.checkboxCache, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkboxNavigator, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkboxAll, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkboxJudge, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, -1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.48092F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.08397F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.08397F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.08397F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.26718F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 334);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // checkboxAll
            // 
            this.checkboxAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkboxAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkboxAll.Location = new System.Drawing.Point(4, 292);
            this.checkboxAll.Margin = new System.Windows.Forms.Padding(4);
            this.checkboxAll.Name = "checkboxAll";
            this.checkboxAll.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkboxAll.Size = new System.Drawing.Size(250, 30);
            this.checkboxAll.TabIndex = 7;
            this.checkboxAll.Text = "All The Above";
            this.checkboxAll.UseVisualStyleBackColor = true;
            this.checkboxAll.CheckedChanged += new System.EventHandler(this.checkboxAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 91);
            this.label1.TabIndex = 8;
            this.label1.Text = "Idaho Supreme Court Odyssey Removal Tool. This tool is design to make removal of " +
    "Odyssey seamless. Please make sure all instances of Odyssey are closed. ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.uninstall_btn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 329);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(502, 98);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // OdysseyUninstall
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(505, 430);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OdysseyUninstall";
            this.Text = "Odyssey Uninstall";
            this.Load += new System.EventHandler(this.Odyssey_Uninstall);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkboxNavigator;
        private System.Windows.Forms.CheckBox checkboxJudge;
        private System.Windows.Forms.CheckBox checkboxCache;
        private System.Windows.Forms.Button uninstall_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkboxAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

