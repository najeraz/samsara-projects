﻿
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Samsara.Support.Util;

namespace Samsara.Main.Forms.Forms
{
    public partial class LoginForm : Form
    {
        private LoadingApplicationForm frmLoadingApplication = new LoadingApplicationForm();

        public LoginForm()
        {
            try
            {
                Random random = new Random();

                frmLoadingApplication.Show();
                Session.Session.Login(random.Next().ToString(), random.Next().ToString());
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
                if (Session.Session.Login(this.txtUsername.Text, this.txtPassword.Text))
                {
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
