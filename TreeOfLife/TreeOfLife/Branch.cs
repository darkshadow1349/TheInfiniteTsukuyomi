using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TreeOfLife
{
    public class Branch
    {
        private object ThreadLock = new object();

        public int id { get; set; }
        public string IP { get; set; }
        public string Computer_Name { get; set; }
        public string Country { get; set; }
        public string Operating_System { get; set; }
        public bool Online { get; set; }
        //public NetworkStream stream { get; set; }
        public Socket socket { get; set; }

        public Branch() { }

        public Branch(int id, string IP, string Computer_Name, string Country, string Operating_System, bool Online, Socket socket)
        {
            this.id = id;
            this.IP = IP;
            this.Computer_Name = Computer_Name;
            this.Country = Country;
            this.Operating_System = Operating_System;
            this.Online = Online;

            this.socket = socket;
        }

        public bool SendCommand(int command)
        {
            lock(ThreadLock)
            {
                bool CommandSent = false;

                try
                {
                    StreamWriter writer = new StreamWriter(new NetworkStream(socket));

                    writer.Write(command);
                    writer.Close();
                    CommandSent = true;
                }
                catch (Exception e) { }

                return CommandSent;
            }
        }

        public bool SendMessage(string Message)
        {
            lock(ThreadLock)
            {
                bool MessageSent = false;

                try
                {
                    SendCommand(1);
                    Thread.Sleep(5000);
                    StreamWriter writer = new StreamWriter(new NetworkStream(socket));
                    writer.WriteLine(Message);
                    writer.Close();
                    MessageSent = true;
                }
                catch(Exception e){}

                return MessageSent;
            }
        }

        public bool SendBeep(string Freq, string Duration)
        {
            lock(ThreadLock)
            {
                bool BeepSent = false;
                string data = Freq + "," + Duration;

                try
                {
                    SendCommand(2);

                    StreamWriter writer = new StreamWriter(new NetworkStream(socket));
                    writer.WriteLine(data);
                    writer.Close();
                    BeepSent = true;
                }
                catch(Exception e){}

                return BeepSent;
            }
        }
    }
}