using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Branch
{
    public partial class BlueScreen : Form
    {
        public BlueScreen()
        {
            InitializeComponent();
        }

        private void BlueScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            BlueScreen bs = new BlueScreen();
            bs.Show();
        }
    }
}
