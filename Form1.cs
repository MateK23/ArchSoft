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
            try
            {
                CreatePdfTable obj1 = new CreatePdfTable();

                // Success message
                logOutput.ForeColor = System.Drawing.Color.Green;
                logOutput.Text = "File Saved";
            }
            catch (Exception exception)
            {
                // Error message

                logOutput.ForeColor = System.Drawing.Color.Red;
                // logOutput.Text = exception.Message;
                logOutput.Text = exception.ToString();
            }
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
    }
}