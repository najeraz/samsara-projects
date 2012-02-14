
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
    public class UserPermissionsFormController
    {
        #region Attributes

        private UserPermissionsForm frmUserPermissions;
        private UserPermissions UserPermissions;
        private IUserPermissionsService srvUserPermissions;

        #endregion Attributes

        #region Constructor

        public UserPermissionsFormController(UserPermissionsForm instance)
        {
            this.frmUserPermissions = instance;
            this.srvUserPermissions = SamsaraAppContext.Resolve<IUserPermissionsService>();
            Assert.IsNotNull(this.srvUserPermissions);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmUserPermissions.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmUserPermissions.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmUserPermissions.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmUserPermissions.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmUserPermissions.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmUserPermissions.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmUserPermissions.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmUserPermissions.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmUserPermissions.HiddenDetail(!show);
            if (show)
                this.frmUserPermissions.tabPrincipal.SelectedTab = this.frmUserPermissions.tabPrincipal.TabPages["New"];
            else
                this.frmUserPermissions.tabPrincipal.SelectedTab = this.frmUserPermissions.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmUserPermissions.txtDetName.Text == null || 
                this.frmUserPermissions.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Permiso de Usuario.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmUserPermissions.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.UserPermissions.Name = this.frmUserPermissions.txtDetName.Text;
            this.UserPermissions.Description = this.frmUserPermissions.txtDetDescription.Text;

            this.UserPermissions.Activated = true;
            this.UserPermissions.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmUserPermissions.txtDetName.Text = string.Empty;
            this.frmUserPermissions.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmUserPermissions.txtSchName.Text = string.Empty;
        }

        private void SaveUserPermissions()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Permiso de Usuario?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvUserPermissions.SaveOrUpdate(this.UserPermissions);
                this.frmUserPermissions.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditUserPermissions(int UserPermissionsId)
        {
            this.UserPermissions = this.srvUserPermissions.GetById(UserPermissionsId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmUserPermissions.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmUserPermissions.txtDetName.Text = this.UserPermissions.Name;
            this.frmUserPermissions.txtDetDescription.Text = this.UserPermissions.Description;
        }

        private void DeleteEntity(int UserPermissionsId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Permiso de Usuario?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.UserPermissions = this.srvUserPermissions.GetById(UserPermissionsId);
            this.UserPermissions.Activated = false;
            this.UserPermissions.Deleted = true;
            this.srvUserPermissions.SaveOrUpdate(this.UserPermissions);
            this.Search();
        }

        private void Search()
        {
            UserPermissionsParameters pmtUserPermissions = new UserPermissionsParameters();

            pmtUserPermissions.Name = "%" + this.frmUserPermissions.txtSchName.Text + "%";

            DataTable dtUserPermissionss = srvUserPermissions.SearchByParameters(pmtUserPermissions);

            this.frmUserPermissions.grdSchSearch.DataSource = null;
            this.frmUserPermissions.grdSchSearch.DataSource = dtUserPermissionss;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.UserPermissions = new UserPermissions();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveUserPermissions();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUserPermissions.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditUserPermissions(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmUserPermissions.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUserPermissions.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
