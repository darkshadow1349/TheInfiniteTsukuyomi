﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace Tree_Of_Life
{
    public partial class FileExplorerViewer : Form
    {
        private NetworkStream stream;

        public FileExplorerViewer(NetworkStream stream)
        {
            InitializeComponent();
            this.stream = stream;
        }
    }
}
