namespace TreeOfLife
{
    partial class BranchListForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.treeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelfDestructMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BotPingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BranchGrid = new System.Windows.Forms.DataGridView();
            this.IP_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Computer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operating_System = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Online = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StartTreeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartTreeBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BranchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // treeToolStripMenuItem
            // 
            this.treeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelfDestructMenuItem,
            this.BotPingMenuItem,
            this.StartTreeItem});
            this.treeToolStripMenuItem.Name = "treeToolStripMenuItem";
            this.treeToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.treeToolStripMenuItem.Text = "Tree";
            // 
            // SelfDestructMenuItem
            // 
            this.SelfDestructMenuItem.Name = "SelfDestructMenuItem";
            this.SelfDestructMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.SelfDestructMenuItem.Size = new System.Drawing.Size(192, 22);
            this.SelfDestructMenuItem.Text = "Self Destruct";
            // 
            // BotPingMenuItem
            // 
            this.BotPingMenuItem.Name = "BotPingMenuItem";
            this.BotPingMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.BotPingMenuItem.Size = new System.Drawing.Size(192, 22);
            this.BotPingMenuItem.Text = "Bot Ping";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 405);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(682, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // BranchGrid
            // 
            this.BranchGrid.AllowUserToDeleteRows = false;
            this.BranchGrid.AllowUserToOrderColumns = true;
            this.BranchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BranchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP_Address,
            this.Computer_Name,
            this.Country,
            this.Operating_System,
            this.Online});
            this.BranchGrid.Location = new System.Drawing.Point(12, 72);
            this.BranchGrid.Name = "BranchGrid";
            this.BranchGrid.ReadOnly = true;
            this.BranchGrid.Size = new System.Drawing.Size(658, 319);
            this.BranchGrid.TabIndex = 2;
            this.BranchGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BranchGrid_MouseDoubleClick);
            // 
            // IP_Address
            // 
            this.IP_Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IP_Address.HeaderText = "IP Address";
            this.IP_Address.Name = "IP_Address";
            this.IP_Address.ReadOnly = true;
            // 
            // Computer_Name
            // 
            this.Computer_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Computer_Name.HeaderText = "Computer Name";
            this.Computer_Name.Name = "Computer_Name";
            this.Computer_Name.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Operating_System
            // 
            this.Operating_System.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Operating_System.HeaderText = "Operating System";
            this.Operating_System.Name = "Operating_System";
            this.Operating_System.ReadOnly = true;
            // 
            // Online
            // 
            this.Online.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Online.HeaderText = "Online";
            this.Online.Name = "Online";
            this.Online.ReadOnly = true;
            // 
            // StartTreeItem
            // 
            this.StartTreeItem.Name = "StartTreeItem";
            this.StartTreeItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.StartTreeItem.Size = new System.Drawing.Size(192, 22);
            this.StartTreeItem.Text = "Start";
            this.StartTreeItem.Click += new System.EventHandler(this.StartTreeItem_Click);
            // 
            // StartTreeBtn
            // 
            this.StartTreeBtn.Location = new System.Drawing.Point(12, 33);
            this.StartTreeBtn.Name = "StartTreeBtn";
            this.StartTreeBtn.Size = new System.Drawing.Size(658, 23);
            this.StartTreeBtn.TabIndex = 3;
            this.StartTreeBtn.Text = "Start Tree";
            this.StartTreeBtn.UseVisualStyleBackColor = true;
            this.StartTreeBtn.Click += new System.EventHandler(this.StartTreeBtn_Click);
            // 
            // BranchListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 427);
            this.Controls.Add(this.StartTreeBtn);
            this.Controls.Add(this.BranchGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BranchListForm";
            this.Text = "Infinite Tsukuyomi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BranchListForm_FormClosing);
            this.Load += new System.EventHandler(this.BranchListForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BranchGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem treeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelfDestructMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BotPingMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView BranchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Computer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operating_System;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Online;
        private System.Windows.Forms.ToolStripMenuItem StartTreeItem;
        private System.Windows.Forms.Button StartTreeBtn;
    }
}

