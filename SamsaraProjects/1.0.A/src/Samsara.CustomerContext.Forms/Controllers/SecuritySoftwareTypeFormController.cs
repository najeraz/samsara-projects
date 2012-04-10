
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Forms.Forms;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Controller
{
    public class SecuritySoftwareTypeFormController
    {
        #region Attributes

        private SecuritySoftwareTypeForm frmSecuritySoftwareType;
        private SecuritySoftwareType SecuritySoftwareType;
        private ISecuritySoftwareTypeService srvSecuritySoftwareType;

        #endregion Attributes

        #region Constructor

        public SecuritySoftwareTypeFormController(SecuritySoftwareTypeForm instance)
        {
            this.frmSecuritySoftwareType = instance;
            this.srvSecuritySoftwareType = SamsaraAppContext.Resolve<ISecuritySoftwareTypeService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmSecuritySoftwareType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmSecuritySoftwareType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmSecuritySoftwareType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmSecuritySoftwareType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmSecuritySoftwareType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmSecuritySoftwareType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmSecuritySoftwareType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmSecuritySoftwareType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmSecuritySoftwareType.HiddenDetail(!show);
            if (show)
                this.frmSecuritySoftwareType.tabPrincipal.SelectedTab = this.frmSecuritySoftwareType.tabPrincipal.TabPages["New"];
            else
                this.frmSecuritySoftwareType.tabPrincipal.SelectedTab = this.frmSecuritySoftwareType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmSecuritySoftwareType.txtDetName.Text == null || 
                this.frmSecuritySoftwareType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Tipo de Software de Seguridad.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmSecuritySoftwareType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.SecuritySoftwareType.Name = this.frmSecuritySoftwareType.txtDetName.Text;
            this.SecuritySoftwareType.Description = this.frmSecuritySoftwareType.txtDetDescription.Text;

            this.SecuritySoftwareType.Activated = true;
            this.SecuritySoftwareType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmSecuritySoftwareType.txtDetName.Text = string.Empty;
            this.frmSecuritySoftwareType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmSecuritySoftwareType.txtSchName.Text = string.Empty;
        }

        private void SaveSecuritySoftwareType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Tipo de Software de Seguridad?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvSecuritySoftwareType.SaveOrUpdate(this.SecuritySoftwareType);
                this.frmSecuritySoftwareType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditSecuritySoftwareType(int SecuritySoftwareTypeId)
        {
            this.SecuritySoftwareType = this.srvSecuritySoftwareType.GetById(SecuritySoftwareTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmSecuritySoftwareType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmSecuritySoftwareType.txtDetName.Text = this.SecuritySoftwareType.Name;
            this.frmSecuritySoftwareType.txtDetDescription.Text = this.SecuritySoftwareType.Description;
        }

        private void DeleteEntity(int SecuritySoftwareTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Tipo de Software de Seguridad?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.SecuritySoftwareType = this.srvSecuritySoftwareType.GetById(SecuritySoftwareTypeId);
            this.SecuritySoftwareType.Activated = false;
            this.SecuritySoftwareType.Deleted = true;
            this.srvSecuritySoftwareType.SaveOrUpdate(this.SecuritySoftwareType);
            this.Search();
        }

        private void Search()
        {
            SecuritySoftwareTypeParameters pmtSecuritySoftwareType = new SecuritySoftwareTypeParameters();

            pmtSecuritySoftwareType.Name = "%" + this.frmSecuritySoftwareType.txtSchName.Text + "%";

            DataTable dtSecuritySoftwareTypes = srvSecuritySoftwareType.SearchByParameters(pmtSecuritySoftwareType);

            this.frmSecuritySoftwareType.grdSchSearch.DataSource = null;
            this.frmSecuritySoftwareType.grdSchSearch.DataSource = dtSecuritySoftwareTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.SecuritySoftwareType = new SecuritySoftwareType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveSecuritySoftwareType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmSecuritySoftwareType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditSecuritySoftwareType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmSecuritySoftwareType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmSecuritySoftwareType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
