namespace TreeOfLife
{
    partial class BranchManager
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
            this.CommunicationTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SendBeepBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DurationBox = new System.Windows.Forms.TextBox();
            this.FrequencyBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BSODBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SendMessageBox = new System.Windows.Forms.TextBox();
            this.SendMessageBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CommunicationTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommunicationTab
            // 
            this.CommunicationTab.Controls.Add(this.tabPage1);
            this.CommunicationTab.Location = new System.Drawing.Point(12, 12);
            this.CommunicationTab.Name = "CommunicationTab";
            this.CommunicationTab.SelectedIndex = 0;
            this.CommunicationTab.Size = new System.Drawing.Size(573, 453);
            this.CommunicationTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Communication";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SendBeepBtn);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.DurationBox);
            this.panel3.Controls.Add(this.FrequencyBox);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(6, 225);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 100);
            this.panel3.TabIndex = 5;
            // 
            // SendBeepBtn
            // 
            this.SendBeepBtn.Location = new System.Drawing.Point(6, 71);
            this.SendBeepBtn.Name = "SendBeepBtn";
            this.SendBeepBtn.Size = new System.Drawing.Size(261, 23);
            this.SendBeepBtn.TabIndex = 5;
            this.SendBeepBtn.Text = "Send Beep";
            this.SendBeepBtn.UseVisualStyleBackColor = true;
            this.SendBeepBtn.Click += new System.EventHandler(this.SendBeep_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Frequency";
            // 
            // DurationBox
            // 
            this.DurationBox.Location = new System.Drawing.Point(143, 45);
            this.DurationBox.Name = "DurationBox";
            this.DurationBox.Size = new System.Drawing.Size(124, 20);
            this.DurationBox.TabIndex = 2;
            // 
            // FrequencyBox
            // 
            this.FrequencyBox.Location = new System.Drawing.Point(6, 45);
            this.FrequencyBox.Name = "FrequencyBox";
            this.FrequencyBox.Size = new System.Drawing.Size(131, 20);
            this.FrequencyBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Send Beep";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BSODBtn);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(6, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 57);
            this.panel2.TabIndex = 4;
            // 
            // BSODBtn
            // 
            this.BSODBtn.Location = new System.Drawing.Point(6, 26);
            this.BSODBtn.Name = "BSODBtn";
            this.BSODBtn.Size = new System.Drawing.Size(263, 23);
            this.BSODBtn.TabIndex = 1;
            this.BSODBtn.Text = "Send Blue Screen";
            this.BSODBtn.UseVisualStyleBackColor = true;
            this.BSODBtn.Click += new System.EventHandler(this.BSODBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Blue Screen Of Death";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SendMessageBox);
            this.panel1.Controls.Add(this.SendMessageBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 150);
            this.panel1.TabIndex = 3;
            // 
            // SendMessageBox
            // 
            this.SendMessageBox.Location = new System.Drawing.Point(6, 24);
            this.SendMessageBox.Multiline = true;
            this.SendMessageBox.Name = "SendMessageBox";
            this.SendMessageBox.Size = new System.Drawing.Size(261, 86);
            this.SendMessageBox.TabIndex = 1;
            // 
            // SendMessageBtn
            // 
            this.SendMessageBtn.Location = new System.Drawing.Point(6, 116);
            this.SendMessageBtn.Name = "SendMessageBtn";
            this.SendMessageBtn.Size = new System.Drawing.Size(261, 23);
            this.SendMessageBtn.TabIndex = 2;
            this.SendMessageBtn.Text = "Send";
            this.SendMessageBtn.UseVisualStyleBackColor = true;
            this.SendMessageBtn.Click += new System.EventHandler(this.SendMessageBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Send A Message";
            // 
            // BranchManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 477);
            this.Controls.Add(this.CommunicationTab);
            this.Name = "BranchManager";
            this.Text = "BranchManager";
            this.CommunicationTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl CommunicationTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SendMessageBtn;
        private System.Windows.Forms.TextBox SendMessageBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BSODBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SendBeepBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DurationBox;
        private System.Windows.Forms.TextBox FrequencyBox;
    }
}