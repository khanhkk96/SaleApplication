using Controller;
using System;
using System.Configuration;
using System.Windows.Forms;
using WaitFormExample;

namespace SaleProject
{
    public partial class Login : Form
    {
        WaitFormFunc waitForm = new WaitFormFunc();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                waitForm.Show(this);
                const string connection = "Data Source={0};Initial Catalog=SaleDB;Integrated Security=True";
                string fullConnectionString = string.Format(connection, txtUsername.Text.Trim());

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["SaleDB"].ConnectionString = fullConnectionString;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");

                MainScreen mainScreen = new MainScreen();
                mainScreen.Show();
                this.Visible = false;

                waitForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constant.ERROR_CONNECT, Constant.NOTE_TEXT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                waitForm.Close();
                //Application.Exit();
            }
        }
    }
}
