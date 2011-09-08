
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Common;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class OrganizationFormController
    {
        #region Attributes

        private OrganizationForm frmOrganization;
        private Organization Organization;
        private IOrganizationService srvOrganization;

        #endregion Attributes

        #region Constructor

        public OrganizationFormController(OrganizationForm instance)
        {
            this.frmOrganization = instance;
            this.srvOrganization = SamsaraAppContext.Resolve<IOrganizationService>();
            Assert.IsNotNull(this.srvOrganization);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmOrganization.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmOrganization.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmOrganization.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmOrganization.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmOrganization.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmOrganization.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmOrganization.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmOrganization.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmOrganization.HiddenDetail(!show);
            if (show)
                this.frmOrganization.tabPrincipal.SelectedTab = this.frmOrganization.tabPrincipal.TabPages["New"];
            else
                this.frmOrganization.tabPrincipal.SelectedTab = this.frmOrganization.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmOrganization.txtDetName.Text == null || 
                this.frmOrganization.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Organization.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOrganization.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.Organization.Name = this.frmOrganization.txtDetName.Text;
            this.Organization.Description = this.frmOrganization.txtDetDescription.Text;

            this.Organization.Activated = true;
            this.Organization.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmOrganization.txtDetName.Text = string.Empty;
            this.frmOrganization.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmOrganization.txtSchName.Text = string.Empty;
        }

        private void SaveOrganization()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Organization?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvOrganization.SaveOrUpdate(this.Organization);
                this.frmOrganization.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditOrganization(int OrganizationId)
        {
            this.Organization = this.srvOrganization.GetById(OrganizationId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmOrganization.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmOrganization.txtDetName.Text = this.Organization.Name;
            this.frmOrganization.txtDetDescription.Text = this.Organization.Description;
        }

        private void DeleteEntity(int OrganizationId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.Organization = this.srvOrganization.GetById(OrganizationId);
            this.Organization.Activated = false;
            this.Organization.Deleted = true;
            this.srvOrganization.SaveOrUpdate(this.Organization);
            this.Search();
        }

        private void Search()
        {
            OrganizationParameters pmtOrganization = new OrganizationParameters();

            pmtOrganization.Name = "%" + this.frmOrganization.txtSchName.Text + "%";

            DataTable dtOrganizations = srvOrganization.SearchByParameters(pmtOrganization);

            this.frmOrganization.grdSchSearch.DataSource = null;
            this.frmOrganization.grdSchSearch.DataSource = dtOrganizations;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.Organization = new Organization();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveOrganization();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOrganization.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditOrganization(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmOrganization.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOrganization.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
