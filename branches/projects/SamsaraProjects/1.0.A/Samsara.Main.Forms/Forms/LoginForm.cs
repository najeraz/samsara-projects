
using System;
using System.Windows.Forms;

namespace Samsara.Main.Forms.Forms
{
    public partial class LoginForm : Form
    {
        private LoadingApplicationForm frmLoadingApplication = new LoadingApplicationForm();

        public LoginForm()
        {
            frmLoadingApplication.Show();
            Session.Session.Login(string.Empty, string.Empty);
            frmLoadingApplication.Close();

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ubtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (Session.Session.Login(this.txtUsername.Text, this.txtPassword.Text))
                {
                    this.Hide();
                    (new MainForm()).ShowDialog();
                }
                else
                {
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }
    }
}
