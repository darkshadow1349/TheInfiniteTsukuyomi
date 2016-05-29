using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    public class TCPClient
    {

        public bool IsConnected = false;
        public string ConnectionID = "";
        public string RemoteAddress = "";
        public string ReturnLastError = "";

        private TcpClient Client;
        private byte[] ReceiveBytes = new byte[1024];
        private StringBuilder ReceiveBuffer = new StringBuilder();
        private StringBuilder LastBuffer = new StringBuilder();
        private StringBuilder PrevBuffer = new StringBuilder();

        public delegate void ClientConnectedEvent(TCPClient client);
        public event ClientConnectedEvent ClientConnected;

        public delegate void ClientDisConnectedEvent(TCPClient client, string errorMessage);
        public event ClientDisConnectedEvent ClientDisconnected;

        public delegate void TextReceivedEvent(TCPClient client, string text);
        public event TextReceivedEvent TextReceived;
        public bool ConnectoServerAndLogin(string Server, int Port, string WhichDevice)
        {
            bool success = true;
            try
            {

                Client = new TcpClient();

                Client.Connect(Server, Port);


                NetworkStream netStream = Client.GetStream();
                netStream.BeginRead(ReceiveBytes, 0, 1024, DoStreamReceive, null);

                IsConnected = true;

                // Now send a message to tell it who I am

                SendSomeData("1=" + WhichDevice + "|2=connected|");

                if (ClientConnected != null) ClientConnected(this);
            }
            catch (Exception ex)
            {

                ReturnLastError = ex.Message.ToString();
                success = false;
            }
            return success;
        }
        public void Disconnect()
        {
            Client.Close();
        }
        private void SendSomeData(string Data)
        {
            StreamWriter writer = new StreamWriter(Client.GetStream());
            writer.Write(Data.Replace("\0", "") + "\0");
            writer.Flush();
        }
        public void SendMessage(string text)
        {
            SendSomeData(text);
        }
        private void DoStreamReceive(IAsyncResult asyncResult)
        {
            int intCount = 0;

            try
            {
                NetworkStream netStream = Client.GetStream();
                lock (netStream)
                {
                    intCount = netStream.EndRead(asyncResult);
                }
                if (intCount < 1)
                {
                    if (ClientDisconnected != null)
                    {
                        ClientDisconnected(this, "Remote socket " + Client.Client.RemoteEndPoint.ToString() + " disconnected");
                    }
                    return;

                }

                string Buffer = Encoding.UTF8.GetString(ReceiveBytes, 0, intCount);

                int idx = Buffer.IndexOf("\0"); // End of message - process this message and move onto the next one
                if (idx > -1)
                {
                    LastBuffer.Append(Buffer.Substring(0, idx));
                    PrevBuffer = new StringBuilder();
                    PrevBuffer.Append(LastBuffer.ToString());
                    string TotalData = LastBuffer.ToString();
                    if (TextReceived != null) TextReceived(this, TotalData);
                    LastBuffer = new StringBuilder();

                    if (idx + 1 < Buffer.Length)
                    {
                        int idd = idx + 1;
                        string Remainder = Buffer.Substring(idd, (Buffer.Length - idd));
                        LastBuffer.Append(Remainder);
                    }
                }
                else
                {
                    LastBuffer.Append(Encoding.UTF8.GetString(ReceiveBytes, 0, intCount));
                }
                lock (netStream)
                {
                    netStream.BeginRead(ReceiveBytes, 0, 1024, DoStreamReceive, null);
                }
            }
            catch (Exception ex)
            {
                if (ClientDisconnected != null)
                {
                    ClientDisconnected(this, "Connection to server closed");
                }
                return;
            }
        }
    }
}
