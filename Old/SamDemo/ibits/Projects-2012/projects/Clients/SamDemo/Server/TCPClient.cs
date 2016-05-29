using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class TCPClient
    {
       
        public bool IsConnected = false;
        public string ConnectionID = "";
        public string RemoteAddress = "";
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



        public TCPClient(TcpClient ConnectedClient)
        {
            ConnectionID = System.Guid.NewGuid().ToString();
            Client = ConnectedClient;
            RemoteAddress = Client.Client.RemoteEndPoint.ToString();
            IsConnected = true;
       
            NetworkStream netStream = Client.GetStream();
            netStream.BeginRead(ReceiveBytes, 0, 1024, DoStreamReceive, null);
        }
        public void Close()
        {
            Client.Close();
        }
        public void SendData(string Data)
        {
            StreamWriter writer = new StreamWriter(Client.GetStream());
            writer.Write(Data.Replace("\0", "") + "\0");
            writer.Flush();
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
                    ClientDisconnected(this, "Remote socket closed");
                }
                return;
            }
        }
    }
}
