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

namespace Tree_Of_Life
{
    public partial class CommandLine : Form
    {
        private StringBuilder builder;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public CommandLine(NetworkStream stream)
        {
            InitializeComponent();
            this.stream = stream;
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    builder.Append(InputBox.Text.ToString());
                    writer.WriteLine(builder.ToString());
                    writer.Flush();
                    InputBox.Text = "";
                    builder.Remove(0, builder.Length);      
                    
                }
            }
            catch (Exception err) { }
        }

        private void CommandLine_Shown(object sender, EventArgs e)
        {
            Thread display = new Thread(new ThreadStart(DisplayStream));
            display.Start();

            InputBox.Focus();
        }

        private void DisplayStream()
        {
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            builder = new StringBuilder();

            while(!this.IsDisposed)//Keep doing this until it is disposed
            {
                try
                {
                    builder.Append(reader.ReadLine());
                    builder.Append("\r\n");
                }
                catch (Exception err) 
                {
                    CleanUp();
                    break;
                }
                Application.DoEvents();

                DisplayMessage(builder.ToString());
                builder.Remove(0, builder.Length);

            }
        }

        private delegate void DisplayDelegate(string message);
        private void DisplayMessage(string message)
        {
            if (output.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessage), new object[] { message });
            }
            else
            {
                output.AppendText(message);
            }
        }

        private void CleanUp()
        {
            try
            {
                reader.Close();
                writer.Close();
                stream.Close();
            }
            catch (Exception e) { }
        }

        private void CommandLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            writer.WriteLine("exit");
            writer.Flush();
            //CleanUp();
        }
    }
}