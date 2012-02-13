
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Forms.Forms;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Forms.Controller
{
    public class UserFormController
    {
        #region Attributes

        private UserForm frmUser;
        private User User;
        private IUserService srvUser;

        #endregion Attributes

        #region Constructor

        public UserFormController(UserForm instance)
        {
            this.frmUser = instance;
            this.srvUser = SamsaraAppContext.Resolve<IUserService>();
            Assert.IsNotNull(this.srvUser);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmUser.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmUser.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmUser.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmUser.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmUser.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmUser.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmUser.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmUser.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmUser.HiddenDetail(!show);
            if (show)
                this.frmUser.tabPrincipal.SelectedTab = this.frmUser.tabPrincipal.TabPages["New"];
            else
                this.frmUser.tabPrincipal.SelectedTab = this.frmUser.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmUser.txtDetUsername.Text == null || 
                this.frmUser.txtDetUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmUser.txtDetUsername.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.User.Username = this.frmUser.txtDetUsername.Text;
            this.User.Password = this.frmUser.txtDetPassword.Text;

            this.User.Activated = true;
            this.User.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmUser.txtDetUsername.Text = string.Empty;
            this.frmUser.txtDetPassword.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmUser.txtSchUsername.Text = string.Empty;
        }

        private void SaveUser()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el User?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvUser.SaveOrUpdate(this.User);
                this.frmUser.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditUser(int UserId)
        {
            this.User = this.srvUser.GetById(UserId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmUser.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmUser.txtDetUsername.Text = this.User.Username;
            //this.frmUser.txtDetPassword.Text = this.User.Password;
        }

        private void DeleteEntity(int UserId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.User = this.srvUser.GetById(UserId);
            this.User.Activated = false;
            this.User.Deleted = true;
            this.srvUser.SaveOrUpdate(this.User);
            this.Search();
        }

        private void Search()
        {
            UserParameters pmtUser = new UserParameters();

            pmtUser.Username = "%" + this.frmUser.txtSchUsername.Text + "%";

            DataTable dtUsers = srvUser.SearchByParameters(pmtUser);

            this.frmUser.grdSchSearch.DataSource = null;
            this.frmUser.grdSchSearch.DataSource = dtUsers;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.User = new User();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveUser();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUser.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditUser(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmUser.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUser.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
