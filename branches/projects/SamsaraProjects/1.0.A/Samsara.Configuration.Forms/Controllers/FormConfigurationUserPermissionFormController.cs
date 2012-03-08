
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Forms.Forms;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Configuration.Forms.Controller
{
    public class FormConfigurationUserPermissionFormController
    {
        #region Attributes

        private FormConfigurationUserPermissionForm frmFormConfigurationUserPermission;
        private FormConfigurationUserPermission FormConfigurationUserPermission;
        private IFormConfigurationUserPermissionService srvFormConfigurationUserPermission;

        #endregion Attributes

        #region Constructor

        public FormConfigurationUserPermissionFormController(FormConfigurationUserPermissionForm instance)
        {
            this.frmFormConfigurationUserPermission = instance;
            this.srvFormConfigurationUserPermission = SamsaraAppContext.Resolve<IFormConfigurationUserPermissionService>();
            Assert.IsNotNull(this.srvFormConfigurationUserPermission);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmFormConfigurationUserPermission.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmFormConfigurationUserPermission.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmFormConfigurationUserPermission.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmFormConfigurationUserPermission.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmFormConfigurationUserPermission.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmFormConfigurationUserPermission.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmFormConfigurationUserPermission.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmFormConfigurationUserPermission.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmFormConfigurationUserPermission.HiddenDetail(!show);
            if (show)
                this.frmFormConfigurationUserPermission.tabPrincipal.SelectedTab = this.frmFormConfigurationUserPermission.tabPrincipal.TabPages["New"];
            else
                this.frmFormConfigurationUserPermission.tabPrincipal.SelectedTab = this.frmFormConfigurationUserPermission.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmFormConfigurationUserPermission.txtDetName.Text == null || 
                this.frmFormConfigurationUserPermission.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Permiso de Usuario.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmFormConfigurationUserPermission.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.FormConfigurationUserPermission.Name = this.frmFormConfigurationUserPermission.txtDetName.Text;
            this.FormConfigurationUserPermission.Description = this.frmFormConfigurationUserPermission.txtDetDescription.Text;

            this.FormConfigurationUserPermission.Activated = true;
            this.FormConfigurationUserPermission.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmFormConfigurationUserPermission.txtDetName.Text = string.Empty;
            this.frmFormConfigurationUserPermission.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmFormConfigurationUserPermission.txtSchName.Text = string.Empty;
        }

        private void SaveFormConfigurationUserPermission()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Permiso de Usuario?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvFormConfigurationUserPermission.SaveOrUpdate(this.FormConfigurationUserPermission);
                this.frmFormConfigurationUserPermission.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditFormConfigurationUserPermission(int FormConfigurationUserPermissionId)
        {
            this.FormConfigurationUserPermission = this.srvFormConfigurationUserPermission.GetById(FormConfigurationUserPermissionId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmFormConfigurationUserPermission.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmFormConfigurationUserPermission.txtDetName.Text = this.FormConfigurationUserPermission.Name;
            this.frmFormConfigurationUserPermission.txtDetDescription.Text = this.FormConfigurationUserPermission.Description;
        }

        private void DeleteEntity(int FormConfigurationUserPermissionId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Permiso de Usuario?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.FormConfigurationUserPermission = this.srvFormConfigurationUserPermission.GetById(FormConfigurationUserPermissionId);
            this.FormConfigurationUserPermission.Activated = false;
            this.FormConfigurationUserPermission.Deleted = true;
            this.srvFormConfigurationUserPermission.SaveOrUpdate(this.FormConfigurationUserPermission);
            this.Search();
        }

        private void Search()
        {
            FormConfigurationUserPermissionParameters pmtFormConfigurationUserPermission = new FormConfigurationUserPermissionParameters();

            pmtFormConfigurationUserPermission.Name = "%" + this.frmFormConfigurationUserPermission.txtSchName.Text + "%";

            DataTable dtFormConfigurationUserPermissions = srvFormConfigurationUserPermission.SearchByParameters(pmtFormConfigurationUserPermission);

            this.frmFormConfigurationUserPermission.grdSchSearch.DataSource = null;
            this.frmFormConfigurationUserPermission.grdSchSearch.DataSource = dtFormConfigurationUserPermissions;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.FormConfigurationUserPermission = new FormConfigurationUserPermission();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveFormConfigurationUserPermission();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmFormConfigurationUserPermission.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditFormConfigurationUserPermission(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmFormConfigurationUserPermission.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmFormConfigurationUserPermission.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
