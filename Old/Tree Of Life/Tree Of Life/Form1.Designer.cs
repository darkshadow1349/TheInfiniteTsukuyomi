namespace Tree_Of_Life
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.treeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Start = new System.Windows.Forms.ToolStripMenuItem();
            this.End = new System.Windows.Forms.ToolStripMenuItem();
            this.Ping = new System.Windows.Forms.ToolStripMenuItem();
            this.KillAll = new System.Windows.Forms.ToolStripMenuItem();
            this.BranchGrid = new System.Windows.Forms.DataGridView();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Online = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.status = new System.Windows.Forms.ToolStripLabel();
            this.ConnectedBranches = new System.Windows.Forms.ToolStripLabel();
            this.BranchMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.SendMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.Beep = new System.Windows.Forms.ToolStripMenuItem();
            this.CMD = new System.Windows.Forms.ToolStripMenuItem();
            this.Bluescreen = new System.Windows.Forms.ToolStripMenuItem();
            this.Shutdown = new System.Windows.Forms.ToolStripMenuItem();
            this.Restart = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.Camera = new System.Windows.Forms.ToolStripMenuItem();
            this.RDP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BranchGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.BranchMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // treeToolStripMenuItem
            // 
            this.treeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Start,
            this.End,
            this.Ping,
            this.KillAll});
            this.treeToolStripMenuItem.Name = "treeToolStripMenuItem";
            this.treeToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.treeToolStripMenuItem.Text = "Tree";
            // 
            // Start
            // 
            this.Start.Name = "Start";
            this.Start.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Start.Size = new System.Drawing.Size(164, 22);
            this.Start.Text = "Start Tree";
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // End
            // 
            this.End.Name = "End";
            this.End.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.End.Size = new System.Drawing.Size(164, 22);
            this.End.Text = "End Tree";
            this.End.Click += new System.EventHandler(this.End_Click);
            // 
            // Ping
            // 
            this.Ping.Name = "Ping";
            this.Ping.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.Ping.Size = new System.Drawing.Size(164, 22);
            this.Ping.Text = "Tree Ping";
            this.Ping.Click += new System.EventHandler(this.Ping_Click);
            // 
            // KillAll
            // 
            this.KillAll.Name = "KillAll";
            this.KillAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.KillAll.Size = new System.Drawing.Size(164, 22);
            this.KillAll.Text = "Kill All";
            this.KillAll.Click += new System.EventHandler(this.KillAll_Click);
            // 
            // BranchGrid
            // 
            this.BranchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BranchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPAddress,
            this.Name,
            this.Country,
            this.Online,
            this.OS});
            this.BranchGrid.Location = new System.Drawing.Point(12, 75);
            this.BranchGrid.Name = "BranchGrid";
            this.BranchGrid.Size = new System.Drawing.Size(672, 339);
            this.BranchGrid.TabIndex = 1;
            this.BranchGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BranchGrid_MouseDoubleClick);
            // 
            // IPAddress
            // 
            this.IPAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IPAddress.HeaderText = "IPAddress";
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Name.HeaderText = "Computer Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Online
            // 
            this.Online.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Online.HeaderText = "Online";
            this.Online.Name = "Online";
            this.Online.ReadOnly = true;
            // 
            // OS
            // 
            this.OS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OS.HeaderText = "Operating System";
            this.OS.Name = "OS";
            this.OS.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status,
            this.ConnectedBranches});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(696, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(57, 22);
            this.status.Text = "Waiting...";
            // 
            // ConnectedBranches
            // 
            this.ConnectedBranches.Name = "ConnectedBranches";
            this.ConnectedBranches.Size = new System.Drawing.Size(13, 22);
            this.ConnectedBranches.Text = "0";
            // 
            // BranchMenu
            // 
            this.BranchMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BranchMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Disconnect,
            this.SendMessage,
            this.Beep,
            this.CMD,
            this.Bluescreen,
            this.Shutdown,
            this.Restart,
            this.FileExplorer,
            this.Camera,
            this.RDP});
            this.BranchMenu.Name = "contextMenuStrip1";
            this.BranchMenu.Size = new System.Drawing.Size(162, 224);
            // 
            // Disconnect
            // 
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(161, 22);
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // SendMessage
            // 
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(161, 22);
            this.SendMessage.Text = "Send Message";
            this.SendMessage.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // Beep
            // 
            this.Beep.Name = "Beep";
            this.Beep.Size = new System.Drawing.Size(161, 22);
            this.Beep.Text = "Beep";
            this.Beep.Click += new System.EventHandler(this.Beep_Click);
            // 
            // CMD
            // 
            this.CMD.Name = "CMD";
            this.CMD.Size = new System.Drawing.Size(161, 22);
            this.CMD.Text = "Command Line";
            this.CMD.Click += new System.EventHandler(this.CMD_Click);
            // 
            // Bluescreen
            // 
            this.Bluescreen.Name = "Bluescreen";
            this.Bluescreen.Size = new System.Drawing.Size(161, 22);
            this.Bluescreen.Text = "Blue Screen";
            this.Bluescreen.Click += new System.EventHandler(this.Bluescreen_Click);
            // 
            // Shutdown
            // 
            this.Shutdown.Name = "Shutdown";
            this.Shutdown.Size = new System.Drawing.Size(161, 22);
            this.Shutdown.Text = "Shutdown";
            this.Shutdown.Click += new System.EventHandler(this.Shutdown_Click);
            // 
            // Restart
            // 
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(161, 22);
            this.Restart.Text = "Restart";
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // FileExplorer
            // 
            this.FileExplorer.Name = "FileExplorer";
            this.FileExplorer.Size = new System.Drawing.Size(161, 22);
            this.FileExplorer.Text = "File Explorer";
            this.FileExplorer.Click += new System.EventHandler(this.FileExplorer_Click);
            // 
            // Camera
            // 
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(161, 22);
            this.Camera.Text = "Camera";
            // 
            // RDP
            // 
            this.RDP.Name = "RDP";
            this.RDP.Size = new System.Drawing.Size(161, 22);
            this.RDP.Text = "Remote Desktop";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 426);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.BranchGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            //this.Name = "Form1";
            this.Text = "Tree Of Life";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BranchGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.BranchMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem treeToolStripMenuItem;
        private System.Windows.Forms.DataGridView BranchGrid;
        private System.Windows.Forms.ToolStripMenuItem Start;
        private System.Windows.Forms.ToolStripMenuItem End;
        private System.Windows.Forms.ToolStripMenuItem Ping;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel status;
        private System.Windows.Forms.ToolStripLabel ConnectedBranches;
        private System.Windows.Forms.ContextMenuStrip BranchMenu;
        private System.Windows.Forms.ToolStripMenuItem Disconnect;
        private System.Windows.Forms.ToolStripMenuItem SendMessage;
        private System.Windows.Forms.ToolStripMenuItem Beep;
        private System.Windows.Forms.ToolStripMenuItem CMD;
        private System.Windows.Forms.ToolStripMenuItem Bluescreen;
        private System.Windows.Forms.ToolStripMenuItem Shutdown;
        private System.Windows.Forms.ToolStripMenuItem FileExplorer;
        private System.Windows.Forms.ToolStripMenuItem Camera;
        private System.Windows.Forms.ToolStripMenuItem RDP;
        private System.Windows.Forms.ToolStripMenuItem KillAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Online;
        private System.Windows.Forms.DataGridViewTextBoxColumn OS;
        private System.Windows.Forms.ToolStripMenuItem Restart;
    }
}

