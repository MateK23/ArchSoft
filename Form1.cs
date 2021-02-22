using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ArchSoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            logOutput.Text = "";

            // Navigation Animation
            pnlNav.Height = btnMain.Height;
            pnlNav.Top = btnMain.Top;
            pnlNav.Left = btnMain.Left;
            btnMain.BackColor = Color.FromArgb(46, 51, 73);
            userControl21.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnMain.Height;
            pnlNav.Top = btnMain.Top;
            pnlNav.Left = btnMain.Left;
            btnMain.BackColor = Color.FromArgb(46, 51, 73);

            userControl21.Hide();
            userControl11.Show();
            userControl11.BringToFront();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSettings.Height;
            pnlNav.Top = btnSettings.Top;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);

            userControl11.Hide();
            userControl21.Show();
            userControl21.BringToFront();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            // try
            // {
            //     //
            //
            //
            //     // here goes new pdf code
            //
            //
            //
            //     //
            //
            //     // Success message
            //     logOutput.ForeColor = System.Drawing.Color.Green;
            //     logOutput.Text = "File Saved";
            // }
            // catch (Exception exception)
            // {
            //     // Error message
            //
            //     logOutput.ForeColor = System.Drawing.Color.Red;
            //     // logOutput.Text = exception.Message;
            //     logOutput.Text = exception.ToString();
            // }
            logOutput.ForeColor = System.Drawing.Color.Red;
            logOutput.Text = "This Button is not yet configured, try using Print Button to Open PDF file\nClick to clear";
        }
        

        private void btnMain_Leave(object sender, EventArgs e)
        {
            btnMain.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSettings_Leave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnWrite_Leave(object sender, EventArgs e)
        {
            btnWrite.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public const int WM_NCLButton = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLButton, HT_CAPTION, 0);
            }
        }
        
        private void logOutput_Click_1(object sender, EventArgs e)
        {
            logOutput.Text = "";
        }
    }
}