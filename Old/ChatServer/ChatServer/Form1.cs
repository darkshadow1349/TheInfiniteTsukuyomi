using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatServer
{
    public partial class Form1 : Form
    {

        private NetworkStream stream;
        private TcpListener listener;
        private StreamReader reader;
        private StreamWriter writer;
        private Socket socket;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            textBox2.Focus();
            Thread thStart = new Thread(new ThreadStart(InitializeChat));
            thStart.Start();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string msg = textBox2.Text;
                writer.WriteLine(msg);
                textBox2.Text = "";
            }
        }

        private void ContListen()
        {
            while (true)
            {
                string line = reader.ReadLine();
                textBox1.AppendText("Server: " + line);
            }
        }

        private void InitializeChat()
        {

            listener = new TcpListener(System.Net.IPAddress.Any, 6666);
            listener.Start();
            while(true)
            {
                socket = listener.AcceptSocket();
                stream = new NetworkStream(socket);
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);
                break;
            }
            
            Thread listen = new Thread(new ThreadStart(ContListen));
            listen.Start();
        }

        private delegate void PutTextDel(string text);
        private void PutText(string text)
        {
            if (textBox1.InvokeRequired)
            {
                Invoke(new PutTextDel(PutText), new object[] { text });
            }
            else
            {
                textBox1.AppendText("Me: " + text);
            }
        }
    }
}
