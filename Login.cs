namespace Disk_Scraper
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            UsernameTextBox.Text = Properties.Settings.Default.Username;
            PasswordTextBox.Text = Properties.Settings.Default.Password;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {


            if (UsernameTextBox.Text == "")
            {
                MessageBox.Show("Please Enter a Valid Username");
            }
            else if (PasswordTextBox.Text == "")
            {
                MessageBox.Show("Please Enter a Valid Password");
            }
            else
            {
                if (RemeberMeCheck.Checked)
                {
                    Properties.Settings.Default.Username = UsernameTextBox.Text;
                    Properties.Settings.Default.Password = PasswordTextBox.Text;
                    Properties.Settings.Default.Save();
                }

                DashBoard DS = new DashBoard();
                DS.Show();
                this.Hide();
            }
        }
    }
}
