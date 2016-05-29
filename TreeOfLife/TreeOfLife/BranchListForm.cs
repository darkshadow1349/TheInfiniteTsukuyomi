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

namespace TreeOfLife
{
    public partial class BranchListForm : Form
    {

        private Socket socket;
        private TcpListener listener;
        private List<Branch> Branches = new List<Branch>();
        private int i = 0;
        private bool started = false;
        private object ThreadLock = new object();
        private Thread thStart;

        public BranchListForm()
        {
            InitializeComponent();
        }

        public void StartTree()
        {
            lock(ThreadLock)
            {
                listener = new TcpListener(System.Net.IPAddress.Any, 6666);
                listener.Start();
                toolStripStatusLabel1.Text = "Tree Started...";

                for (;;)
                {
                    socket = listener.AcceptSocket();
                    IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                    toolStripStatusLabel1.Text = ip + " has been captured in the Infinite Tsukuyomi";
                    StreamReader reader = new StreamReader(new NetworkStream(socket));
                    string[] data_received = reader.ReadLine().Split(',');
                    Branches.Add(new Branch(i, ip.ToString(), data_received[0], data_received[1], data_received[2], true, new NetworkStream(socket)));
                    string[] grid_data = { ip.ToString(), data_received[0], data_received[1], data_received[2] };
                    reader.Close();
                    InitializeGrid(grid_data);
                    i++;

                    if(!started)
                    {
                        break;
                    }
                }
            }
        }

        private delegate void InitializeGridDelegate(string[] data);
        private void InitializeGrid(string[] data)
        {
            if (this.BranchGrid.InvokeRequired)
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

        private void BranchListForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Waiting to start...";
        }

        private void StartTreeItem_Click(object sender, EventArgs e)
        {
            thStart = new Thread(new ThreadStart(StartTree));
            thStart.Start();
            started = true;
            StartTreeBtn.Text = "End Tree";
        }

        private Branch GetBranch(string ip)
        {
            Branch branch = null;
            foreach (Branch b in Branches)
            {
                if (b.IP.Equals(ip))
                {
                    branch = b;
                }
            }
            return branch;
        }

        private void BranchGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                BranchGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                string ip = BranchGrid.CurrentRow.Cells["IPAddress"].Value.ToString();
                BranchManager control = new BranchManager(GetBranch(ip));
                control.Show();
            }
            catch (Exception e1) { MessageBox.Show("No Branch Selected"); }
        }

        public void CleanUp()
        {
            try
            {
                socket.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void StartTreeBtn_Click(object sender, EventArgs e)
        {
            if(!started)
            {
                started = true;
                StartTreeBtn.Text = "End Tree";
                thStart = new Thread(new ThreadStart(StartTree));
                thStart.Start();

            }else if(started)
            {
                started = false;
                StartTreeBtn.Text = "Start Tree";
            }
        }

        private void BranchListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            CleanUp();
        }
    }
}
