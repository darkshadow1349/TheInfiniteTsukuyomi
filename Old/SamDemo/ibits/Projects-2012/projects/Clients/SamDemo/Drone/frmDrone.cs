using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drone
{
    public partial class frmDrone : Form
    {
        private bool IsConnected = false;
        private TCPClient Client;
        private delegate void MarshallMessage(string from, string message);
        private bool ConnectedToServer = false;
        public frmDrone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsConnected == false)
            {
                ConnectToServer();
            }
            else
            {
                DisconnectFromServer();
            }
        }
        private void DisconnectFromServer()
        {
            Client.Disconnect();
            IsConnected = false;
            button1.Text = "Connect";
        }
        private void ConnectToServer()
        {
            Client = new TCPClient();
            Client.ClientConnected += Client_ClientConnected;
            Client.ClientDisconnected += Client_ClientDisconnected;
            Client.TextReceived += Client_TextReceived;
            if (Client.ConnectoServerAndLogin(txtIPAddress.Text, Convert.ToInt32(txtPort.Text), "Drone") == false)
            {
                MessageBox.Show("Could not connect - error: " + Client.ReturnLastError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        void Client_TextReceived(TCPClient client, string text)
        {
            string from = GetTagToken(text, "1");
            string command = GetTagToken(text, "2");
            string forx = "";
            string dowhat = "";
            if (from.ToLower() == "client" && command.ToLower() == "command")
            {
                forx = GetTagToken(text, "3");
                dowhat = GetTagToken(text, "4");
                UpdateServerListBox("Inwards <", "client has told me to " + dowhat);
            }
            else
            {
                UpdateServerListBox("Inwards <", text);
            }
        }

        void Client_ClientDisconnected(TCPClient client, string errorMessage)
        {
            ConnectedToServer = false;
            UpdateServerListBox("Inwards <", "Disconnected from server " + errorMessage);
            
        }

        void Client_ClientConnected(TCPClient client)
        {
            ConnectedToServer = true;
            UpdateServerListBox("Inwards <", "Connected to server");
            
        }
        private void UpdateServerListBox(string from, string message)
        {
            if (this.InvokeRequired == true)
            {
                MarshallMessage d = new MarshallMessage(UpdateServerListBox);
                this.Invoke(d, from, message);
            }
            else
            {
                Messages.Items.Add(from + " " + message);
                button2.Enabled = ConnectedToServer;
                if (button2.Enabled == true)
                {
                    button1.Text = "Disconnect";
                    txtIPAddress.Enabled = false;
                    txtPort.Enabled = false;
                    IsConnected = true;
                }
                else
                {
                    button1.Text = "Connect";
                    txtIPAddress.Enabled = true;
                    txtPort.Enabled = true;
                    IsConnected = false;
                }
                txtCommand.Enabled = ConnectedToServer;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string command = "1=drone|2=command|3=client|4=" + txtCommand.Text + "|";
            Client.SendMessage(command);
            UpdateServerListBox("Outwards >", command );
            txtCommand.Text = "";
        }
        private string GetTagToken(string data, string token)
        {
            // Get stuff out of the message string based on the token - e.g. 1=

            if (data.EndsWith("|") == false) data = data + "|";
            string look = token.Trim() + "=";
            int startIndex = data.IndexOf(look);
            if (startIndex < 0) return ""; //can't find it
            int endIndex = data.IndexOf("|", startIndex);
            startIndex = startIndex + look.Length;
            string answer = data.Substring(startIndex, endIndex - startIndex);
            return answer;
        }
    }
}
