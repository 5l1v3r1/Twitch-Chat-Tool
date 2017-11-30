using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Twitch_Tool
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Chat Box Closed 302, 224
        // Chat Box Opened 302, 570
        // Chat Box No Group Box 256, 339

        bool hidden;

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            this.TopMost = false;
            hidden = false;
            this.Size = new System.Drawing.Size(302, 224);
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            metroLabel1.Text = "Chat Box Opacity: " + metroTrackBar1.Value + "%";
            this.Opacity = metroTrackBar1.Value / (double)100;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == String.Empty)
            {
                MessageBox.Show("Please enter a username!");
            }
            else
            {
                webBrowser1.Visible = true;
                webBrowser1.Navigate("https://twitch.tv/" + metroTextBox1.Text + "/chat");
                this.Size = new System.Drawing.Size(302, 592);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = false;
            this.Size = new System.Drawing.Size(302, 224);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (this.TopMost == false)
            {
                this.TopMost = true;
                metroButton3.Text = "Disable Top Most";
            }
            else
            {
                this.TopMost = false;
                metroButton3.Text = "Make Top Most";
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (hidden == false)
            {
                webBrowser1.Location = new Point (0, 3);
                webBrowser1.Size = new Size (302, 560);
                metroButton4.Location = new Point(23, 378);
                this.Size = new System.Drawing.Size(302, 413);
                groupBox1.Visible = false;
                metroButton4.Text = "Show Settings Box";
                hidden = true;
            }
            else
            {
                groupBox1.Visible = true;
                this.Size = new System.Drawing.Size(302, 592);
                webBrowser1.Location = new Point(23, 214);
                webBrowser1.Size = new Size(256, 339);
                metroButton4.Location = new Point(23, 559);
                metroButton4.Text = "Hide Settings Box";
                hidden = false;
            }
        }
    }
}
