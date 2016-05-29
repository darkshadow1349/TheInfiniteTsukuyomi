using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class frmServer : Form
    {
        private bool IsListening = false;
        
        // The connections to the drone and client

        private TCPClient drone;
        private TCPClient client;
        private bool droneConnected = false;
        private bool clientConnected = false;

        // The actual TCP Server

        private TCPServer server;



        private delegate void MarshallMessage(string from, string message);

        public frmServer()
        {
            InitializeComponent();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            txtIPAddress.Text = LocalIPAddress();
        }
        public string LocalIPAddress()
        {
            string str = "";

            System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(str);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsListening == false)
            {
                StartListening();
            }
            else
            {
                StopListening();
            }
        }
        private void StopListening()
        {
            // close connections to drone and client and then close the listener down

            if (clientConnected == true) client.Close();
            if (droneConnected == true) drone.Close();
            clientConnected = false;
            droneConnected = false;
            txtIPAddress.Enabled = true;
            txtPort.Enabled = true;
            button1.Text = "Start";
            IsListening = false;
            server.CloseServer();
            server = null;
        }
        private void StartListening()
        {
            txtIPAddress.Enabled = false;
            txtPort.Enabled = false;
            button1.Text = "Stop";
            IsListening = true;
            server = new TCPServer();
            server.ClientConnected += server_ClientConnected;
            server.ClientDisconnected += server_ClientDisconnected;
            server.TextReceived += server_TextReceived;
            server.ListenOnAddress = txtIPAddress.Text;
            server.ListenOnPort = Convert.ToInt32(txtPort.Text);
            server.StartTCPServer();
        }

        void server_TextReceived(TCPClient remoteClient, string text)
        {
            // get the commands out of the string
            // 1 = who is it from
            // 2 = what does it want
            // 3 = who is it for

            string from = GetTagToken(text, "1");
            string command = GetTagToken(text, "2");
            string forx = "";
            string dowhat = "";

            if (from.ToLower() == "client" && command.ToLower() == "command")
            {
                forx = GetTagToken(text, "3");
                dowhat = GetTagToken(text, "4");
                if (forx.ToLower() == "drone" && droneConnected == true)
                {
                    drone.SendData(text);
                   
                }
                UpdateServerListBox(remoteClient.RemoteAddress, "Client has sent the drone the following command " + dowhat);
            }
            else if (from.ToLower() == "drone" && command.ToLower() == "command")
            {
                forx = GetTagToken(text, "3");
                dowhat = GetTagToken(text, "4");
                if (forx.ToLower() == "client" && clientConnected == true)
                {
                    client.SendData(text);

                }
                UpdateServerListBox(remoteClient.RemoteAddress, "Drone has sent the client the following command " + dowhat);
            }
            else if (from.ToLower() == "client" && command.ToLower() == "connected")
            {
                client = remoteClient;
                clientConnected = true;
                UpdateServerListBox(remoteClient.RemoteAddress, "Client has connected");
                
                if (droneConnected == true) //tell the drone that the client has connected
                {
                    drone.SendData("1=server|2=clientisconnected|");
                    // and now tell the client that the drone is in fact connected
                    client.SendData("1=server|2=droneisconnected|");

                }
            }
            else if (from.ToLower() == "drone" && command.ToLower() == "connected")
            {
                drone = remoteClient;
                droneConnected = true;
                UpdateServerListBox(remoteClient.RemoteAddress, "Drone has connected");
                if (clientConnected == true)
                {
                    client.SendData("1=server|2=droneisconnected|");
                    // and now tell the drone that the client is in fact connected
                    drone.SendData("1=server|2=clientisconnected|");
                }

                
            }
            else
            {
                UpdateServerListBox(remoteClient.RemoteAddress, text);
            }
        }

        void server_ClientDisconnected(TCPClient remoteClient, string errorMessage)
        {
            //figure out who has disconnected

            if (clientConnected == true && client.RemoteAddress == remoteClient.RemoteAddress)
            {
                clientConnected = false;
                UpdateServerListBox(remoteClient.RemoteAddress, "Client has Disconnected");
                
                //tell the drone if it is connected that the client has disconnected
               
                if (droneConnected == true)
                {
                    drone.SendData("1=server|2=clientdisconnected|");
                }
            }
            else if (droneConnected == true && drone.RemoteAddress == remoteClient.RemoteAddress)
            {
                droneConnected = false;
                UpdateServerListBox(remoteClient.RemoteAddress, "Drone has Disconnected");
                //tell the client if it is connected that the client has disconnected

                if (clientConnected == true)
                {
                    client.SendData("1=server|2=dronedisconnected|");
                }

            }
            else
            {
                UpdateServerListBox(remoteClient.RemoteAddress, "Disconnected with error " + errorMessage);
            }
        }
        void server_ClientConnected(TCPClient client)
        {
            UpdateServerListBox(client.RemoteAddress, "Connected");
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Messages.Items.Clear();
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

        private void frmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
