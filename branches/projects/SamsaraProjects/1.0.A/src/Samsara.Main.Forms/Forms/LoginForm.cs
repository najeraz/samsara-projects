
using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using Samsara.Base.Core.Context;
using Samsara.Framework.Util;
using Samsara.Main.Core.Entities;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Forms.Forms
{
    public partial class LoginForm : Form
    {
        private LoadingApplicationForm frmLoadingApplication = new LoadingApplicationForm();
        private ILoginAttemptService srvLoginAttempt;

        public LoginForm()
        {
            try
            {
                frmLoadingApplication.Show();

                this.srvLoginAttempt = SamsaraAppContext.Resolve<ILoginAttemptService>();

                frmLoadingApplication.Close();

                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ExceptionsUtil.InnerExceptionsMessages(ex));
                Environment.Exit(1);
            }
        }

        [DebuggerStepThrough]
        private void ubtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                LoginAttempt loginAttempt = new LoginAttempt();

                loginAttempt.Username = this.txtUsername.Text;
                loginAttempt.MacAddresses = NetworkUtil.GetMACAddresses();
                loginAttempt.DomainUser = WindowsIdentity.GetCurrent().Name;
                loginAttempt.Successful = Session.Session.Login(this.txtUsername.Text, this.txtPassword.Text);

                if (loginAttempt.Successful)
                {
                    loginAttempt.User = Session.Session.User;
                    this.srvLoginAttempt.Save(loginAttempt);

                    this.Hide();
                    this.ClearFields();

                    MainForm frmMain = new MainForm();
                    frmMain.ShowDialog();

                    if (frmMain.ClosedSession)
                    {
                        this.Show();
                        return;
                    }
                }
                else
                {
                    this.srvLoginAttempt.Save(loginAttempt);

                    MessageBox.Show("El usuario y/o contraseña son incorrectos",
                        "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ClearFields();
                    return;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }

        private void ClearFields()
        {
            this.txtUsername.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtUsername.Focus();
            this.txtUsername.Select();
        }

        private void ubtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
