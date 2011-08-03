
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Enums;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.Support.Util;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class OpportunityFormController
    {
        #region Attributes

        private OpportunityForm frmOpportunity;
        private Opportunity Opportunity;
        private IOrganizationService srvOrganization;
        private IAsesorService srvAsesor;
        private IOpportunityService srvOpportunity;
        private IManufacturerService srvManufacturer;
        private TabPage hiddenOpportunityDetailTab;

        #endregion Attributes

        #region Constructor

        public OpportunityFormController(OpportunityForm instance)
        {
            this.frmOpportunity = instance;
            this.srvOrganization = SamsaraAppContext.Resolve<IOrganizationService>();
            Assert.IsNotNull(srvOrganization);
            this.srvAsesor = SamsaraAppContext.Resolve<IAsesorService>();
            Assert.IsNotNull(srvAsesor);
            this.srvOpportunity = SamsaraAppContext.Resolve<IOpportunityService>();
            Assert.IsNotNull(srvOpportunity);
            this.srvManufacturer = SamsaraAppContext.Resolve<IManufacturerService>();
            Assert.IsNotNull(srvManufacturer);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            // Asesor
            AsesorParameters pmtAsesor = new AsesorParameters();
            IList<Asesor> lstAsesors = srvAsesor.GetListByParameters(pmtAsesor);

            WindowsFormsUtil.LoadCombo<Asesor>(this.frmOpportunity.uceSchAsesor,
                lstAsesors, "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmOpportunity.uceDetAsesor,
                lstAsesors, "AsesorId", "Name");

            // OpportunityStatus
            OpportunityStatusParameters pmtOpportunityStatus = new OpportunityStatusParameters();
            IList<OpportunityStatus> lstOpportunityStatuses = 
                srvOpportunity.GetOpportunityStatusesByParameters(pmtOpportunityStatus);

            WindowsFormsUtil.LoadCombo<OpportunityStatus>(this.frmOpportunity.uceSchOpportunityStatus,
                lstOpportunityStatuses, "OpportunityStatusId", "Name");
            WindowsFormsUtil.LoadCombo<OpportunityStatus>(this.frmOpportunity.uceDetOpportunityStatus,
                lstOpportunityStatuses, "OpportunityStatusId", "Name");

            // Organization
            OrganizationParameters pmtOrganization = new OrganizationParameters();
            IList<Organization> lstOrganizations = srvOrganization.GetListByParameters(pmtOrganization);

            WindowsFormsUtil.LoadCombo<Organization>(this.frmOpportunity.uceSchOrganization,
                lstOrganizations, "OrganizationId", "Name");
            WindowsFormsUtil.LoadCombo<Organization>(this.frmOpportunity.uceDetOrganization,
                lstOrganizations, "OrganizationId", "Name");

            
            this.frmOpportunity.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmOpportunity.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmOpportunity.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmOpportunity.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmOpportunity.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmOpportunity.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);
            this.frmOpportunity.btnSchClear.Click += new EventHandler(btnSchClear_Click);

            this.hiddenOpportunityDetailTab = this.frmOpportunity.tabDetDetail.TabPages["OpportunityDetails"];
            this.frmOpportunity.uosSchDates.Value = -1;
            this.frmOpportunity.HiddenDetail(true);

            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmOpportunity.HiddenDetail(!show);
            if (show)
                this.frmOpportunity.tabPrincipal.SelectedTab = this.frmOpportunity.tabPrincipal.TabPages["New"];
            else
                this.frmOpportunity.tabPrincipal.SelectedTab = this.frmOpportunity.tabPrincipal.TabPages["Search"];
            this.frmOpportunity.tabDetDetail.SelectedTab = this.frmOpportunity.tabDetDetail.TabPages["Principal"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmOpportunity.uceDetOrganization.Value == null ||
                Convert.ToInt32(this.frmOpportunity.uceDetOrganization.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Organización.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOpportunity.tabDetDetail.SelectedTab =
                    this.frmOpportunity.tabDetDetail.TabPages["Principal"];
                this.frmOpportunity.uceDetOrganization.Focus();
                return false;
            }

            if (this.frmOpportunity.txtDetOpportunityName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Oportunidad.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOpportunity.tabDetDetail.SelectedTab =
                    this.frmOpportunity.tabDetDetail.TabPages["Principal"];
                this.frmOpportunity.txtDetOpportunityName.Focus();
                return false;
            }
            
            return true;
        }

        private void LoadEntity()
        {
            if (Convert.ToInt32(this.frmOpportunity.uceDetOrganization.Value) > 0)
            {
                Organization organization = srvOrganization.GetById(
                    Convert.ToInt32(this.frmOpportunity.uceDetOrganization.Value));
                Assert.IsNotNull(organization);
                this.Opportunity.Organization = organization;
            }

            if (Convert.ToInt32(this.frmOpportunity.uceDetAsesor.Value) > 0)
            {
                Asesor asesor = srvAsesor.GetById(
                    Convert.ToInt32(this.frmOpportunity.uceDetAsesor.Value));
                Assert.IsNotNull(asesor);
                this.Opportunity.Asesor = asesor;
            }

            this.Opportunity.Deadline = (Nullable<DateTime>)this.frmOpportunity.dteDetDeadline.Value;
            this.Opportunity.PreRevisionDate = (Nullable<DateTime>)this.frmOpportunity.dteDetPrerevisionDate.Value;
            this.Opportunity.RegistrationDate = (Nullable<DateTime>)this.frmOpportunity.dteDetRegistrationDate.Value;
            this.Opportunity.AcquisitionReason = this.frmOpportunity.txtDetAcquisitionReason.Text;
            this.Opportunity.Name = this.frmOpportunity.txtDetOpportunityName.Text;

            this.Opportunity.Activated = true;
            this.Opportunity.Deleted = false;
        }
        
        private void ClearDetailControls()
        {
            this.frmOpportunity.uceDetAsesor.Value = -1;
            this.frmOpportunity.uceDetOrganization.Value = -1;
            this.frmOpportunity.uceDetOpportunityStatus.Value = -1;
            this.frmOpportunity.txtDetAcquisitionReason.Text = string.Empty;
            this.frmOpportunity.txtDetOpportunityName.Text = string.Empty;
            this.frmOpportunity.dteDetDeadline.Value = null;
            this.frmOpportunity.dteDetPrerevisionDate.Value = null;
            this.frmOpportunity.dteDetRegistrationDate.Value = null;
        }

        private void ClearSearchControls()
        {
            this.frmOpportunity.txtSchOpportunityName.Text = string.Empty;
            this.frmOpportunity.uceSchAsesor.Value = -1;
            this.frmOpportunity.uceSchOrganization.Value = -1;
            this.frmOpportunity.uceSchOpportunityStatus.Value = -1;
            this.frmOpportunity.uosSchDates.Value = -1;
            this.frmOpportunity.dteSchMaxDate.DateTime = DateTime.Now;
            this.frmOpportunity.dteSchMinDate.DateTime = DateTime.Now;
        }

        private void SaveOpportunity()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Licitación?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvOpportunity.SaveOrUpdate(this.Opportunity);
                this.frmOpportunity.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditOpportunity(int OpportunityId)
        {
            this.Opportunity = this.srvOpportunity.GetById(OpportunityId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmOpportunity.HiddenDetail(false);
            this.ShowDetail(true);
            this.Search();
        }

        private void LoadFormFromEntity()
        {
            this.frmOpportunity.uceDetAsesor.Value =
                this.Opportunity.Asesor == null ? -1 : this.Opportunity.Asesor.AsesorId;
            this.frmOpportunity.uceDetOpportunityStatus.Value =
                this.Opportunity.OpportunityStatus == null ? -1 : this.Opportunity.OpportunityStatus.OpportunityStatusId;
            this.frmOpportunity.txtDetAcquisitionReason.Text = this.Opportunity.AcquisitionReason;
            this.frmOpportunity.txtDetOpportunityName.Text = this.Opportunity.Name;
            if (this.Opportunity.Deadline.HasValue)
                this.frmOpportunity.dteDetDeadline.Value = this.Opportunity.Deadline.Value;
            if (this.Opportunity.PreRevisionDate.HasValue)
                this.frmOpportunity.dteDetPrerevisionDate.Value = this.Opportunity.PreRevisionDate.Value;
            if (this.Opportunity.RegistrationDate.HasValue)
                this.frmOpportunity.dteDetRegistrationDate.Value = this.Opportunity.RegistrationDate.Value;
        }

        private void DeleteEntity(int OpportunityId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Licitación?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            this.Opportunity = this.srvOpportunity.GetById(OpportunityId);
            this.Opportunity.Activated = false;
            this.Opportunity.Deleted = true;
            this.srvOpportunity.SaveOrUpdate(this.Opportunity);
            this.Search();
        }

        private void Search()
        {
            OpportunityParameters pmtOpportunity = new OpportunityParameters();

            pmtOpportunity.MinDate = (DateTime)this.frmOpportunity.dteSchMinDate.Value;
            pmtOpportunity.MaxDate = (DateTime)this.frmOpportunity.dteSchMaxDate.Value;
            pmtOpportunity.AsesorId = (int)this.frmOpportunity.uceSchAsesor.Value;
            pmtOpportunity.OrganizationId = (int)this.frmOpportunity.uceSchOrganization.Value;
            pmtOpportunity.OpportunityStatusId = (int)this.frmOpportunity.uceSchOpportunityStatus.Value;
            pmtOpportunity.OpportunityName = "%" + this.frmOpportunity.txtSchOpportunityName.Text + "%";
            pmtOpportunity.DateTypeSearchId = (DateTypeSearchEnum)this.frmOpportunity.uosSchDates.Value;

            DataTable dtOpportunitys = srvOpportunity.SearchByParameters(pmtOpportunity);

            this.frmOpportunity.grdSchSearch.DataSource = null;
            this.frmOpportunity.grdSchSearch.DataSource = dtOpportunitys;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.Opportunity = new Opportunity();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveOpportunity();
        }
        
        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmOpportunity.HiddenDetail(true);
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOpportunity.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditOpportunity(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOpportunity.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        #endregion Events
    }
}
