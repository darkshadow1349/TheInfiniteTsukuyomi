namespace Tree_Of_Life
{
    partial class CommandLine
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
            this.output = new System.Windows.Forms.TextBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.output.ForeColor = System.Drawing.Color.Lime;
            this.output.Location = new System.Drawing.Point(2, 4);
            this.output.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(957, 634);
            this.output.TabIndex = 0;
            // 
            // InputBox
            // 
            this.InputBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.InputBox.ForeColor = System.Drawing.Color.Lime;
            this.InputBox.Location = new System.Drawing.Point(1, 641);
            this.InputBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(958, 22);
            this.InputBox.TabIndex = 1;
            this.InputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            // 
            // CommandLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 666);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.output);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CommandLine";
            this.Text = "Command Line";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandLine_FormClosing);
            this.Shown += new System.EventHandler(this.CommandLine_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.TextBox InputBox;
    }
}