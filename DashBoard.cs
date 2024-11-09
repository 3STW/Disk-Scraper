using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disk_Scraper
{
    public partial class DashBoard : Form
    {
        // so you can Drag the Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        ////////////////////////////////////////////////////////////////////////////////////////////

        public DashBoard()
        {
            InitializeComponent();
            UsernameLabel.Text = Properties.Settings.Default.Username;
        }

        public void loadform(object Form)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(f);
            this.panel1.Tag = f;
            f.Show();
        }

        private void guna2vSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void DBBtn_Click(object sender, EventArgs e)
        {
            loadform(new CleanerForm());
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            loadform(new About());
        }

        private void guna2GradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void KillProcess_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
