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
using System.IO;
using System.Threading;

namespace Branch
{
    public partial class Chat : Form
    {
        private string tree = "Tree: ";
        private string branch = "Me: ";

        private StreamReader reader;
        private StreamWriter writer;

        public Chat(StreamReader reader, StreamWriter writer)
        {
            InitializeComponent();
            this.reader = reader;
            this.writer = writer;
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Chat_Shown(object sender, EventArgs e)
        {

        }
    }
}
