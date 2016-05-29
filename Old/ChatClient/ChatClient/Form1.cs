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

namespace ChatClient
{
    public partial class Form1 : Form
    {

        private NetworkStream stream;
        private TcpClient client = new TcpClient();
        private StreamReader reader;
        private StreamWriter writer;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string msg = textBox2.Text;
                writer.WriteLine(msg);
                textBox2.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            textBox2.Focus();
            for (; ; )
            {
                InitializeChat();
                System.Threading.Thread.Sleep(5000);
            }
        }


        private delegate void PutTextDel(string text);
        private void PutText(string text)
        {
            if(textBox1.InvokeRequired)
            {
                Invoke(new PutTextDel(PutText), new object[] { text });
            }
            else
            {
                textBox1.AppendText("Me: " + text);
            }
        }


        private void ContListen()
        {
            while(true)
            {
                string line = reader.ReadLine();
                textBox1.AppendText("Server: " + line);
            }
        }

        private void InitializeChat()
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
                catch (Exception e) { return; }
            }

            Thread listen = new Thread(new ThreadStart(ContListen));
            listen.Start();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}
