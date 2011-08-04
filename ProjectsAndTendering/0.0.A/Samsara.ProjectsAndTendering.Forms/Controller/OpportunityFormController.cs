
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
        private Opportunity opportunity;
        private Tender tender;
        private IBidderService srvBidder;
        private IDependencyService srvDependency;
        private IEndUserService srvEndUser;
        private IOrganizationService srvOrganization;
        private IAsesorService srvAsesor;
        private ITenderService srvTender;
        private IOpportunityService srvOpportunity;
        private IOpportunityTypeService srvOpportunityType;
        private IOpportunityStatusService srvOpportunityStatus;
        private IManufacturerService srvManufacturer;
        private TabPage hiddenOpportunityDetailTab;

        #endregion Attributes

        #region Constructor

        public OpportunityFormController(OpportunityForm instance)
        {
            this.frmOpportunity = instance;
            this.srvOrganization = SamsaraAppContext.Resolve<IOrganizationService>();
            Assert.IsNotNull(srvOrganization);
            this.srvBidder = SamsaraAppContext.Resolve<IBidderService>();
            Assert.IsNotNull(srvBidder);
            this.srvDependency = SamsaraAppContext.Resolve<IDependencyService>();
            Assert.IsNotNull(srvDependency);
            this.srvEndUser = SamsaraAppContext.Resolve<IEndUserService>();
            Assert.IsNotNull(srvEndUser);
            this.srvAsesor = SamsaraAppContext.Resolve<IAsesorService>();
            Assert.IsNotNull(srvAsesor);
            this.srvTender = SamsaraAppContext.Resolve<ITenderService>();
            Assert.IsNotNull(srvTender);
            this.srvOpportunity = SamsaraAppContext.Resolve<IOpportunityService>();
            Assert.IsNotNull(srvOpportunity);
            this.srvOpportunityType = SamsaraAppContext.Resolve<IOpportunityTypeService>();
            Assert.IsNotNull(srvOpportunityType);
            this.srvOpportunityStatus = SamsaraAppContext.Resolve<IOpportunityStatusService>();
            Assert.IsNotNull(srvOpportunityStatus);
            this.srvManufacturer = SamsaraAppContext.Resolve<IManufacturerService>();
            Assert.IsNotNull(srvManufacturer);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            // OpportunityType
            OpportunityTypeParameters pmtOpportunityType = new OpportunityTypeParameters();
            IList<OpportunityType> lstOpportunityType = 
                this.srvOpportunityType.GetListByParameters(pmtOpportunityType);

            WindowsFormsUtil.LoadCombo<OpportunityType>(this.frmOpportunity.uceSchOpportunityType,
                lstOpportunityType, "OpportunityTypeId", "Name");
            WindowsFormsUtil.LoadCombo<OpportunityType>(this.frmOpportunity.uceDetOpportunityType,
                lstOpportunityType, "OpportunityTypeId", "Name");

            // Bidder
            BidderParameters pmtBidder = new BidderParameters();
            IList<Bidder> lstBidders = srvBidder.GetListByParameters(pmtBidder);

            WindowsFormsUtil.LoadCombo<Bidder>(this.frmOpportunity.uceSchBidder,
                lstBidders, "BidderId", "Name");
            WindowsFormsUtil.LoadCombo<Bidder>(this.frmOpportunity.uceDetBidder,
                lstBidders, "BidderId", "Name");

            this.frmOpportunity.uceSchBidder.ValueChanged += new EventHandler(uceSchBidder_ValueChanged);
            this.frmOpportunity.uceDetBidder.ValueChanged += new EventHandler(uceDetBidder_ValueChanged);

            // Dependency
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = ParameterConstants.IntNone;
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmOpportunity.uceSchDependency,
                lstDependencies, "DependencyId", "Name");
            WindowsFormsUtil.LoadCombo<Dependency>(this.frmOpportunity.uceDetDependency,
                lstDependencies, "DependencyId", "Name");

            this.frmOpportunity.uceSchDependency.ValueChanged += new EventHandler(uceSchDependency_ValueChanged);
            this.frmOpportunity.uceDetDependency.ValueChanged += new EventHandler(uceDetDependency_ValueChanged);

            // EndUser
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = ParameterConstants.IntNone;
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmOpportunity.uceSchEndUser,
                lstEndUsers, "EndUserId", "Name");
            WindowsFormsUtil.LoadCombo<EndUser>(this.frmOpportunity.uceDetEndUser,
                lstEndUsers, "EndUserId", "Name");

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
                srvOpportunityStatus.GetListByParameters(pmtOpportunityStatus);

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
            this.frmOpportunity.ubtnDetGenerateTender.Click += new EventHandler(ubtnDetGenerateTender_Click);

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
                this.opportunity.Organization = organization;
            }
            if (Convert.ToInt32(this.frmOpportunity.uceDetBidder.Value) > 0)
            {
                Bidder bidder = srvBidder.GetById(
                    Convert.ToInt32(this.frmOpportunity.uceDetBidder.Value));
                Assert.IsNotNull(bidder);
                this.opportunity.Bidder = bidder;
            }
            if (Convert.ToInt32(this.frmOpportunity.uceDetDependency.Value) > 0)
            {
                Dependency dependency = srvDependency.GetById(
                    Convert.ToInt32(this.frmOpportunity.uceDetDependency.Value));
                Assert.IsNotNull(dependency);
                this.opportunity.Dependency = dependency;
            }

            if (Convert.ToInt32(this.frmOpportunity.uceDetEndUser.Value) > 0)
            {
                EndUser endUser = srvEndUser.GetById(
                    Convert.ToInt32(this.frmOpportunity.uceDetEndUser.Value));
                Assert.IsNotNull(endUser);
                this.opportunity.EndUser = endUser;
            }

            if (Convert.ToInt32(this.frmOpportunity.uceDetAsesor.Value) > 0)
            {
                Asesor asesor = srvAsesor.GetById(
                    Convert.ToInt32(this.frmOpportunity.uceDetAsesor.Value));
                Assert.IsNotNull(asesor);
                this.opportunity.Asesor = asesor;
            }

            if (Convert.ToInt32(this.frmOpportunity.uceDetOpportunityStatus.Value) > 0)
            {
                OpportunityStatus opportunityStatus = this.srvOpportunityStatus.GetById(
                    Convert.ToInt32(this.frmOpportunity.uceDetOpportunityStatus.Value));
                Assert.IsNotNull(opportunityStatus);
                this.opportunity.OpportunityStatus = opportunityStatus;
            }

            this.opportunity.Deadline = (Nullable<DateTime>)this.frmOpportunity.dteDetDeadline.Value;
            this.opportunity.PreRevisionDate = (Nullable<DateTime>)this.frmOpportunity.dteDetPrerevisionDate.Value;
            this.opportunity.RegistrationDate = (Nullable<DateTime>)this.frmOpportunity.dteDetRegistrationDate.Value;
            this.opportunity.AcquisitionReason = this.frmOpportunity.txtDetAcquisitionReason.Text;
            this.opportunity.Name = this.frmOpportunity.txtDetOpportunityName.Text;

            this.opportunity.Activated = true;
            this.opportunity.Deleted = false;
        }
        
        private void ClearDetailControls()
        {
            this.frmOpportunity.uceDetAsesor.Value = -1;
            this.frmOpportunity.uceDetBidder.Value = -1;
            this.frmOpportunity.uceDetDependency.Value = -1;
            this.frmOpportunity.uceDetEndUser.Value = -1;
            this.frmOpportunity.uceDetOrganization.Value = -1;
            this.frmOpportunity.uceDetOpportunityStatus.Value = -1;
            this.frmOpportunity.txtDetAcquisitionReason.Text = string.Empty;
            this.frmOpportunity.txtDetOpportunityName.Text = string.Empty;
            this.frmOpportunity.dteDetDeadline.Value = null;
            this.frmOpportunity.dteDetPrerevisionDate.Value = null;
            this.frmOpportunity.dteDetRegistrationDate.Value = null;
            this.frmOpportunity.txtDetRelatedTender.Text = string.Empty;
            this.frmOpportunity.ubtnDetGenerateTender.Visible = false;
            this.frmOpportunity.gbxDetRelatedTender.Visible = false;
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
                if (MessageBox.Show("¿Esta seguro de guardar la Oportunidad?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvOpportunity.SaveOrUpdate(this.opportunity);
                this.frmOpportunity.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditOpportunity(int OpportunityId)
        {
            this.opportunity = this.srvOpportunity.GetById(OpportunityId);

            TenderParameters pmtTender = new TenderParameters();
            pmtTender.OpportunityId = OpportunityId;
            this.tender = this.srvTender.GetByParameters(pmtTender);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmOpportunity.HiddenDetail(false);
            this.ShowDetail(true);
            this.Search();
        }

        private void LoadFormFromEntity()
        {
            this.frmOpportunity.uceDetAsesor.Value =
                this.opportunity.Asesor == null ? -1 : this.opportunity.Asesor.AsesorId;
            this.frmOpportunity.uceDetBidder.Value =
                this.opportunity.Bidder == null ? -1 : this.tender.Bidder.BidderId;
            this.frmOpportunity.uceDetDependency.Value =
                this.opportunity.Dependency == null ? -1 : this.tender.Dependency.DependencyId;
            this.frmOpportunity.uceDetEndUser.Value =
                this.opportunity.EndUser == null ? -1 : this.tender.EndUser.EndUserId;
            this.frmOpportunity.uceDetOrganization.Value = 
                this.opportunity.Organization == null ? -1 : this.opportunity.Organization.OrganizationId;
            this.frmOpportunity.uceDetOpportunityStatus.Value =
                this.opportunity.OpportunityStatus == null ? -1 : this.opportunity.OpportunityStatus.OpportunityStatusId;
            this.frmOpportunity.txtDetAcquisitionReason.Text = this.opportunity.AcquisitionReason;
            this.frmOpportunity.txtDetOpportunityName.Text = this.opportunity.Name;
            if (this.opportunity.Deadline.HasValue)
                this.frmOpportunity.dteDetDeadline.Value = this.opportunity.Deadline.Value;
            if (this.opportunity.PreRevisionDate.HasValue)
                this.frmOpportunity.dteDetPrerevisionDate.Value = this.opportunity.PreRevisionDate.Value;
            if (this.opportunity.RegistrationDate.HasValue)
                this.frmOpportunity.dteDetRegistrationDate.Value = this.opportunity.RegistrationDate.Value;
            if (tender == null)
                this.frmOpportunity.ubtnDetGenerateTender.Visible = true;
            else
                this.frmOpportunity.txtDetRelatedTender.Text = this.tender.Name;
            this.frmOpportunity.gbxDetRelatedTender.Visible = true;
        }

        private void DeleteEntity(int OpportunityId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Oportunidad?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            this.opportunity = this.srvOpportunity.GetById(OpportunityId);
            this.opportunity.Activated = false;
            this.opportunity.Deleted = true;
            this.srvOpportunity.SaveOrUpdate(this.opportunity);
            this.Search();
        }

        private void Search()
        {
            OpportunityParameters pmtOpportunity = new OpportunityParameters();

            pmtOpportunity.MinDate = (DateTime)this.frmOpportunity.dteSchMinDate.Value;
            pmtOpportunity.MaxDate = (DateTime)this.frmOpportunity.dteSchMaxDate.Value;
            pmtOpportunity.AsesorId = (int)this.frmOpportunity.uceSchAsesor.Value;
            pmtOpportunity.OrganizationId = (int)this.frmOpportunity.uceSchOrganization.Value;
            pmtOpportunity.BidderId = (int)this.frmOpportunity.uceSchBidder.Value;
            pmtOpportunity.DependencyId = (int)this.frmOpportunity.uceSchDependency.Value;
            pmtOpportunity.EndUserId = (int)this.frmOpportunity.uceSchEndUser.Value;
            pmtOpportunity.OpportunityStatusId = (int)this.frmOpportunity.uceSchOpportunityStatus.Value;
            pmtOpportunity.OpportunityName = "%" + this.frmOpportunity.txtSchOpportunityName.Text + "%";
            pmtOpportunity.DateTypeSearchId = (DateTypeSearchEnum)this.frmOpportunity.uosSchDates.Value;

            DataTable dtOpportunitys = srvOpportunity.SearchByParameters(pmtOpportunity);

            this.frmOpportunity.grdSchSearch.DataSource = null;
            this.frmOpportunity.grdSchSearch.DataSource = dtOpportunitys;
        }

        private void GenerateTender()
        {
            throw new NotImplementedException();
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.opportunity = new Opportunity();
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

        private void uceSchBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = Convert.ToInt32(this.frmOpportunity.uceSchBidder.Value);
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmOpportunity.uceSchDependency,
                lstDependencies, "DependencyId", "Name");
        }

        private void uceDetBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = Convert.ToInt32(this.frmOpportunity.uceDetBidder.Value);
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmOpportunity.uceDetDependency,
                lstDependencies, "DependencyId", "Name");
        }

        private void uceSchDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = Convert.ToInt32(this.frmOpportunity.uceSchDependency.Value);
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmOpportunity.uceSchEndUser,
                lstEndUsers, "EndUserId", "Name");
        }

        private void uceDetDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = Convert.ToInt32(this.frmOpportunity.uceDetDependency.Value);
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmOpportunity.uceDetEndUser,
                lstEndUsers, "EndUserId", "Name");
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

        private void ubtnDetGenerateTender_Click(object sender, EventArgs e)
        {
            this.GenerateTender();
        }

        #endregion Events
    }
}
