namespace Tree_Of_Life
{
    partial class KeyLoggerView
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
            this.LogOutput = new System.Windows.Forms.TextBox();
            this.Kill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogOutput
            // 
            this.LogOutput.Location = new System.Drawing.Point(1, 1);
            this.LogOutput.Multiline = true;
            this.LogOutput.Name = "LogOutput";
            this.LogOutput.ReadOnly = true;
            this.LogOutput.Size = new System.Drawing.Size(525, 230);
            this.LogOutput.TabIndex = 0;
            // 
            // Kill
            // 
            this.Kill.Location = new System.Drawing.Point(1, 237);
            this.Kill.Name = "Kill";
            this.Kill.Size = new System.Drawing.Size(525, 23);
            this.Kill.TabIndex = 1;
            this.Kill.Text = "Stop Keylogger";
            this.Kill.UseVisualStyleBackColor = true;
            this.Kill.Click += new System.EventHandler(this.Kill_Click);
            // 
            // KeyLoggerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 261);
            this.Controls.Add(this.Kill);
            this.Controls.Add(this.LogOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "KeyLoggerView";
            this.Text = "KeyLoggerView";
            this.Shown += new System.EventHandler(this.KeyLoggerView_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogOutput;
        private System.Windows.Forms.Button Kill;
    }
}