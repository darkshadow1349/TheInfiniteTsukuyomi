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
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace PortBindingShellListener
{
    public partial class Form1 : Form
    {
        private TcpListener listener;
        private NetworkStream stream;
        private Socket socket;
        private StreamReader reader;
        private StreamWriter writer;
        private StringBuilder builder;

        public Form1()
        {
            InitializeComponent();
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    builder.Append(input.Text.ToString());
                    writer.WriteLine(builder);
                    writer.Flush();

                    builder.Remove(0, builder.Length);

                    if (input.Text.Equals("exit")) CleanUp();
                    if (input.Text.Equals("terminate")) CleanUp();
                    if (input.Text.Equals("cls")) output.Text = ""; input.Text = "";
                }
            }
            catch (Exception err) { }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Thread thStart = new Thread(new ThreadStart(StartListen));
            thStart.Start();
            input.Focus();
        }

        private void StartListen()
        {
            listener = new TcpListener(System.Net.IPAddress.Any, 4444);
            listener.Start();
            for(; ; )
            {
                socket = listener.AcceptSocket();
                IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                status.Text = "New Connection From: " + ip;

                Thread run = new Thread(new ThreadStart(Run));
                run.Start();
            }
        }

        private void Run()
        {
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            builder = new StringBuilder();

            while(true)
            {
                try
                {
                    builder.Append(reader.ReadLine());
                    builder.Append("\r\n");
                }
                catch(Exception e)
                {
                    CleanUp();
                    break;
                }

                Application.DoEvents();
                DisplayMessage(builder.ToString());
                builder.Remove(0, builder.Length);
            }
        }

        private void CleanUp()
        {
            try
            {
                socket.Close();
                stream.Close();
                reader.Close();
                writer.Close();
            }
            catch(Exception e){}

            status.Text = "Connection Lost";
        }

        private delegate void DisplayDelegate(string message);
        private void DisplayMessage(string message)
        {
            if(output.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessage), new object[] { message });
            }else
            {
                output.AppendText(message);
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            CleanUp();
            System.Environment.Exit(System.Environment.ExitCode);
        }
    }
}
