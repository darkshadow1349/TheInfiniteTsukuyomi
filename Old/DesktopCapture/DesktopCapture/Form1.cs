using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;

namespace DesktopCapture
{
    public partial class Form1 : Form
    {
        private Bitmap memoryImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureDesktop();
            //Save();
            pictureBox1.Image = memoryImage;
        }

        private void CaptureDesktop()
        {
            try
            {
                Rectangle rc = Screen.PrimaryScreen.Bounds;
                memoryImage = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
                using (Graphics memoryGrphics = Graphics.FromImage(memoryImage))
                {
                    memoryGrphics.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);
                }
            }
            catch (Exception e) { }
        }

        private void Save()
        {
            String pathName = String.Format("{0}\\", Path.GetDirectoryName(Application.ExecutablePath));
            string filename = String.Format("{0}Desktop.JPG", pathName);
            try
            {
                memoryImage.Save(filename, ImageFormat.Jpeg);
            }
            catch (Exception e) { }
        }
    }
}
