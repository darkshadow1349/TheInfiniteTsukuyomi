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
    public class TCPServer
    {
        public string ReturnLastError = "";
        public string ListenOnAddress;
        public int ListenOnPort;

        private IPAddress ListeningAddress;
        private Thread ListeningThread;
        private TcpListener TCPListener;

        public delegate void ClientConnectedEvent(TCPClient client);
        public event ClientConnectedEvent ClientConnected;

        public delegate void ClientDisConnectedEvent(TCPClient client, string errorMessage);
        public event ClientDisConnectedEvent ClientDisconnected;

        public delegate void TextReceivedEvent(TCPClient client, string text);
        public event TextReceivedEvent TextReceived;

        public bool StartTCPServer()
        {

            bool success = true;
            try
            {

                ListeningAddress = IPAddress.Parse(ListenOnAddress);
                ListeningThread = new Thread(new ThreadStart(RunTCPListener));
                ListeningThread.Start();
            }
            catch (Exception ex)
            {

                ReturnLastError = ex.Message.ToString();
            }
            return success;
        }
        public void CloseServer()
        {
            TCPListener.Server.Close();
        }
        private void RunTCPListener()
        {
            try
            {
                TCPListener = new TcpListener(ListeningAddress, ListenOnPort);
                TCPListener.Start();
                do
                {
                    try
                    {
                        TCPClient Client = new TCPClient(TCPListener.AcceptTcpClient());
                        Client.ClientDisconnected += Client_ClientDisconnected;
                        Client.ClientConnected += Client_ClientConnected;
                        Client.TextReceived += Client_TextReceived;
                        if (ClientConnected != null) ClientConnected(Client);
                    }
                    catch (Exception ex)
                    {
                        return;
                    }

                } while (true);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void Client_TextReceived(TCPClient client, string text)
        {
            if (TextReceived != null) TextReceived(client, text);
        }

        private void Client_ClientConnected(TCPClient client)
        {
            if (ClientConnected != null) ClientConnected(client);
        }

        private void Client_ClientDisconnected(TCPClient client, string errorMessage)
        {
            if (ClientDisconnected != null) ClientDisconnected(client, errorMessage);
        }
    }
}
