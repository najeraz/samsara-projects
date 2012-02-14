
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
    public class UserPermissionFormController
    {
        #region Attributes

        private UserPermissionForm frmUserPermission;
        private UserPermission UserPermission;
        private IUserPermissionService srvUserPermission;

        #endregion Attributes

        #region Constructor

        public UserPermissionFormController(UserPermissionForm instance)
        {
            this.frmUserPermission = instance;
            this.srvUserPermission = SamsaraAppContext.Resolve<IUserPermissionService>();
            Assert.IsNotNull(this.srvUserPermission);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmUserPermission.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmUserPermission.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmUserPermission.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmUserPermission.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmUserPermission.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmUserPermission.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmUserPermission.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmUserPermission.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmUserPermission.HiddenDetail(!show);
            if (show)
                this.frmUserPermission.tabPrincipal.SelectedTab = this.frmUserPermission.tabPrincipal.TabPages["New"];
            else
                this.frmUserPermission.tabPrincipal.SelectedTab = this.frmUserPermission.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmUserPermission.txtDetName.Text == null || 
                this.frmUserPermission.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Permiso de Usuario.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmUserPermission.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.UserPermission.Name = this.frmUserPermission.txtDetName.Text;
            this.UserPermission.Description = this.frmUserPermission.txtDetDescription.Text;

            this.UserPermission.Activated = true;
            this.UserPermission.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmUserPermission.txtDetName.Text = string.Empty;
            this.frmUserPermission.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmUserPermission.txtSchName.Text = string.Empty;
        }

        private void SaveUserPermission()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Permiso de Usuario?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvUserPermission.SaveOrUpdate(this.UserPermission);
                this.frmUserPermission.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditUserPermission(int UserPermissionId)
        {
            this.UserPermission = this.srvUserPermission.GetById(UserPermissionId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmUserPermission.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmUserPermission.txtDetName.Text = this.UserPermission.Name;
            this.frmUserPermission.txtDetDescription.Text = this.UserPermission.Description;
        }

        private void DeleteEntity(int UserPermissionId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Permiso de Usuario?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.UserPermission = this.srvUserPermission.GetById(UserPermissionId);
            this.UserPermission.Activated = false;
            this.UserPermission.Deleted = true;
            this.srvUserPermission.SaveOrUpdate(this.UserPermission);
            this.Search();
        }

        private void Search()
        {
            UserPermissionParameters pmtUserPermission = new UserPermissionParameters();

            pmtUserPermission.Name = "%" + this.frmUserPermission.txtSchName.Text + "%";

            DataTable dtUserPermissions = srvUserPermission.SearchByParameters(pmtUserPermission);

            this.frmUserPermission.grdSchSearch.DataSource = null;
            this.frmUserPermission.grdSchSearch.DataSource = dtUserPermissions;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.UserPermission = new UserPermission();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveUserPermission();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUserPermission.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditUserPermission(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmUserPermission.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUserPermission.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
