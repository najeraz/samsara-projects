
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Forms.Forms;
using Samsara.Common.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Enums;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces;
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
        private IOpportunityLogService srvOpportunityLog;
        private IOpportunityTypeService srvOpportunityType;
        private IOpportunityStatusService srvOpportunityStatus;
        private IManufacturerService srvManufacturer;
        private TabPage hiddenOpportunityDetailTab;
        private DataTable dtOpportunityLog;

        #endregion Attributes

        #region Constructor

        public OpportunityFormController(OpportunityForm instance)
        {
            this.frmOpportunity = instance;
            this.srvOrganization = SamsaraAppContext.Resolve<IOrganizationService>();
            Assert.IsNotNull(this.srvOrganization);
            this.srvBidder = SamsaraAppContext.Resolve<IBidderService>();
            Assert.IsNotNull(this.srvBidder);
            this.srvDependency = SamsaraAppContext.Resolve<IDependencyService>();
            Assert.IsNotNull(this.srvDependency);
            this.srvEndUser = SamsaraAppContext.Resolve<IEndUserService>();
            Assert.IsNotNull(this.srvEndUser);
            this.srvAsesor = SamsaraAppContext.Resolve<IAsesorService>();
            Assert.IsNotNull(this.srvAsesor);
            this.srvTender = SamsaraAppContext.Resolve<ITenderService>();
            Assert.IsNotNull(this.srvTender);
            this.srvOpportunity = SamsaraAppContext.Resolve<IOpportunityService>();
            Assert.IsNotNull(this.srvOpportunity);
            this.srvOpportunityType = SamsaraAppContext.Resolve<IOpportunityTypeService>();
            Assert.IsNotNull(this.srvOpportunityType);
            this.srvOpportunityStatus = SamsaraAppContext.Resolve<IOpportunityStatusService>();
            Assert.IsNotNull(this.srvOpportunityStatus);
            this.srvManufacturer = SamsaraAppContext.Resolve<IManufacturerService>();
            Assert.IsNotNull(this.srvManufacturer);
            this.srvOpportunityLog = SamsaraAppContext.Resolve<IOpportunityLogService>();
            Assert.IsNotNull(this.srvOpportunityLog);
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
                lstOpportunityType, "OpportunityTypeId", "Name", "Seleccione");
            WindowsFormsUtil.LoadCombo<OpportunityType>(this.frmOpportunity.uceDetOpportunityType,
                lstOpportunityType, "OpportunityTypeId", "Name", "Seleccione");

            this.frmOpportunity.uceDetOpportunityType.ValueChanged +=
                new EventHandler(uceDetOpportunityType_ValueChanged);
            this.frmOpportunity.uceSchOpportunityType.ValueChanged +=
                new EventHandler(uceSchOpportunityType_ValueChanged);

            this.uceDetOpportunityType_ValueChanged(null, null);
            this.uceSchOpportunityType_ValueChanged(null, null);

            // Bidder
            BidderParameters pmtBidder = new BidderParameters();
            IList<Bidder> lstBidders = srvBidder.GetListByParameters(pmtBidder);

            WindowsFormsUtil.LoadCombo<Bidder>(this.frmOpportunity.uceSchBidder,
                lstBidders, "BidderId", "Name", "Seleccione");
            WindowsFormsUtil.LoadCombo<Bidder>(this.frmOpportunity.uceDetBidder,
                lstBidders, "BidderId", "Name", "Seleccione");

            this.frmOpportunity.uceSchBidder.ValueChanged += new EventHandler(uceSchBidder_ValueChanged);
            this.frmOpportunity.uceDetBidder.ValueChanged += new EventHandler(uceDetBidder_ValueChanged);

            // Dependency
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = ParameterConstants.IntNone;
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmOpportunity.uceSchDependency,
                lstDependencies, "DependencyId", "Name", "Seleccione");
            WindowsFormsUtil.LoadCombo<Dependency>(this.frmOpportunity.uceDetDependency,
                lstDependencies, "DependencyId", "Name", "Seleccione");

            this.frmOpportunity.uceSchDependency.ValueChanged += new EventHandler(uceSchDependency_ValueChanged);
            this.frmOpportunity.uceDetDependency.ValueChanged += new EventHandler(uceDetDependency_ValueChanged);

            // EndUser
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = ParameterConstants.IntNone;
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmOpportunity.uceSchEndUser,
                lstEndUsers, "EndUserId", "Name", "Seleccione");
            WindowsFormsUtil.LoadCombo<EndUser>(this.frmOpportunity.uceDetEndUser,
                lstEndUsers, "EndUserId", "Name", "Seleccione");

            // Asesor
            AsesorParameters pmtAsesor = new AsesorParameters();
            IList<Asesor> lstAsesors = srvAsesor.GetListByParameters(pmtAsesor);

            WindowsFormsUtil.LoadCombo<Asesor>(this.frmOpportunity.uceSchAsesor,
                lstAsesors, "AsesorId", "Name", "Seleccione");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmOpportunity.uceDetAsesor,
                lstAsesors, "AsesorId", "Name", "Seleccione");

            // OpportunityStatus
            OpportunityStatusParameters pmtOpportunityStatus = new OpportunityStatusParameters();
            IList<OpportunityStatus> lstOpportunityStatuses =
                srvOpportunityStatus.GetListByParameters(pmtOpportunityStatus);

            WindowsFormsUtil.LoadCombo<OpportunityStatus>(this.frmOpportunity.uceSchOpportunityStatus,
                lstOpportunityStatuses, "OpportunityStatusId", "Name", "Seleccione");
            WindowsFormsUtil.LoadCombo<OpportunityStatus>(this.frmOpportunity.uceDetOpportunityStatus,
                lstOpportunityStatuses, "OpportunityStatusId", "Name", "Seleccione");

            // Organization
            OrganizationParameters pmtOrganization = new OrganizationParameters();
            IList<Organization> lstOrganizations = srvOrganization.GetListByParameters(pmtOrganization);

            WindowsFormsUtil.LoadCombo<Organization>(this.frmOpportunity.uceSchOrganization,
                lstOrganizations, "OrganizationId", "Name", "Seleccione");
            WindowsFormsUtil.LoadCombo<Organization>(this.frmOpportunity.uceDetOrganization,
                lstOrganizations, "OrganizationId", "Name", "Seleccione");

            //grdDetLog
            this.frmOpportunity.grdDetLog.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetLog_InitializeLayout);
            this.frmOpportunity.grdDetLog.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdDetLog_BeforeCellUpdate);
            OpportunityLogParameters pmtOpportunityLog = new OpportunityLogParameters();
            pmtOpportunityLog.OpportunityLogId = ParameterConstants.IntNone;
            this.dtOpportunityLog = this.srvOpportunityLog.SearchByParameters(pmtOpportunityLog);
            this.frmOpportunity.grdDetLog.DataSource = null;
            this.frmOpportunity.grdDetLog.DataSource = this.dtOpportunityLog;
            
            this.frmOpportunity.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmOpportunity.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmOpportunity.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmOpportunity.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmOpportunity.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmOpportunity.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);
            this.frmOpportunity.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmOpportunity.ubtnDetGenerateTender.Click += new EventHandler(ubtnDetGenerateTender_Click);
            this.frmOpportunity.ubtnDetCreateLog.Click += new EventHandler(ubtnDetCreateLog_Click);

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
            if ((int)this.frmOpportunity.uceDetOpportunityType.Value == (int)OpportunityTypeEnum.PublicSector
                && (this.frmOpportunity.uceDetBidder.Value == null ||
                Convert.ToInt32(this.frmOpportunity.uceDetBidder.Value) <= 0))
            {
                MessageBox.Show("Favor de seleccionar el Licitante.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOpportunity.tabDetDetail.SelectedTab =
                    this.frmOpportunity.tabDetDetail.TabPages["Principal"];
                this.frmOpportunity.uceDetBidder.Focus();
                return false;
            }

            if ((int)this.frmOpportunity.uceDetOpportunityType.Value == (int)OpportunityTypeEnum.PrivateSector
                && (this.frmOpportunity.uceDetOrganization.Value == null ||
                Convert.ToInt32(this.frmOpportunity.uceDetOrganization.Value) <= 0))
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
            this.opportunity.OpportunityType = this.srvOpportunityType.GetById(
                Convert.ToInt32(this.frmOpportunity.uceDetOpportunityType.Value));
            this.opportunity.Organization = srvOrganization.GetById(Convert.ToInt32(this.frmOpportunity.uceDetOrganization.Value));
            this.opportunity.Bidder = srvBidder.GetById(Convert.ToInt32(this.frmOpportunity.uceDetBidder.Value));
            this.opportunity.Dependency = srvDependency.GetById(Convert.ToInt32(this.frmOpportunity.uceDetDependency.Value));
            this.opportunity.EndUser = srvEndUser.GetById(Convert.ToInt32(this.frmOpportunity.uceDetEndUser.Value));
            this.opportunity.Asesor = srvAsesor.GetById(Convert.ToInt32(this.frmOpportunity.uceDetAsesor.Value));
            this.opportunity.OpportunityStatus = this.srvOpportunityStatus.GetById(
                Convert.ToInt32(this.frmOpportunity.uceDetOpportunityStatus.Value));

            this.opportunity.IsLOR = this.frmOpportunity.uchkDetIsLOR.Checked;
            this.opportunity.Deadline = (Nullable<DateTime>)this.frmOpportunity.dteDetDeadline.Value;
            this.opportunity.PreRevisionDate = (Nullable<DateTime>)this.frmOpportunity.dteDetPrerevisionDate.Value;
            this.opportunity.RegistrationDate = (Nullable<DateTime>)this.frmOpportunity.dteDetRegistrationDate.Value;
            this.opportunity.AcquisitionReason = this.frmOpportunity.txtDetAcquisitionReason.Text;
            this.opportunity.Name = this.frmOpportunity.txtDetOpportunityName.Text;

            this.LoadOpportunityLogs();

            this.opportunity.Activated = true;
            this.opportunity.Deleted = false;
        }
        
        private void ClearDetailControls()
        {
            this.frmOpportunity.uceDetOpportunityType.Value = -1;
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
            this.frmOpportunity.uceDetOpportunityType.ReadOnly = false;
            this.frmOpportunity.uchkDetIsLOR.Checked = false;
            this.dtOpportunityLog.Rows.Clear();
        }

        private void ClearSearchControls()
        {
            this.frmOpportunity.txtSchOpportunityName.Text = string.Empty;
            this.frmOpportunity.uceSchOpportunityType.Value = -1;
            this.frmOpportunity.uceSchBidder.Value = -1;
            this.frmOpportunity.uceSchDependency.Value = -1;
            this.frmOpportunity.uceSchEndUser.Value = -1;
            this.frmOpportunity.uceSchOrganization.Value = -1;
            this.frmOpportunity.uceSchAsesor.Value = -1;
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
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
        }

        private void LoadFormFromEntity()
        {
            this.frmOpportunity.uceDetOpportunityType.Value
                = this.opportunity.OpportunityType == null ? -1 : this.opportunity.OpportunityType.OpportunityTypeId;
            this.frmOpportunity.uceDetBidder.Value =
                this.opportunity.Bidder == null ? -1 : this.opportunity.Bidder.BidderId;
            this.frmOpportunity.uceDetDependency.Value =
                this.opportunity.Dependency == null ? -1 : this.opportunity.Dependency.DependencyId;
            this.frmOpportunity.uceDetEndUser.Value =
                this.opportunity.EndUser == null ? -1 : this.opportunity.EndUser.EndUserId;
            this.frmOpportunity.uceDetAsesor.Value =
                this.opportunity.Asesor == null ? -1 : this.opportunity.Asesor.AsesorId;
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
            this.frmOpportunity.uchkDetIsLOR.Checked = this.opportunity.IsLOR;

            this.ShowHideGenerateTenderButton();

            foreach (OpportunityLog opportunityLog in this.opportunity.OpportunityLogs.OrderByDescending(x => x.LogDate))
            {
                DataRow row = this.dtOpportunityLog.NewRow();
                this.dtOpportunityLog.Rows.Add(row);

                row["Description"] = opportunityLog.Description;
                row["LogDate"] = opportunityLog.LogDate;
                row["OpportunityLogId"] = opportunityLog.OpportunityLogId;
            }
        }

        private void ShowHideGenerateTenderButton()
        {
            if (tender == null)
            {
                this.frmOpportunity.ubtnDetGenerateTender.Visible = 
                    Convert.ToInt32(this.frmOpportunity.uceDetOpportunityType.Value)
                    == (int)OpportunityTypeEnum.PublicSector
                    && this.frmOpportunity.uchkDetIsLOR.Checked == false;
                this.frmOpportunity.gbxDetRelatedTender.Visible = false;
            }
            else
            {
                this.frmOpportunity.txtDetRelatedTender.Text = this.tender.Name;
                this.frmOpportunity.ubtnDetGenerateTender.Visible = false;
                this.frmOpportunity.gbxDetRelatedTender.Visible = true;
                this.frmOpportunity.uceDetOpportunityType.ReadOnly = true;
            }
        }

        private void DeleteEntity(int OpportunityId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Oportunidad?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
            pmtOpportunity.OpportunityTypeId = (int)this.frmOpportunity.uceSchOpportunityType.Value;
            pmtOpportunity.OrganizationId = (int)this.frmOpportunity.uceSchOrganization.Value;
            pmtOpportunity.BidderId = (int)this.frmOpportunity.uceSchBidder.Value;
            pmtOpportunity.DependencyId = (int)this.frmOpportunity.uceSchDependency.Value;
            pmtOpportunity.EndUserId = (int)this.frmOpportunity.uceSchEndUser.Value;
            pmtOpportunity.AsesorId = (int)this.frmOpportunity.uceSchAsesor.Value;
            pmtOpportunity.OpportunityStatusId = (int)this.frmOpportunity.uceSchOpportunityStatus.Value;
            pmtOpportunity.Name = "%" + this.frmOpportunity.txtSchOpportunityName.Text + "%";
            pmtOpportunity.DateTypeSearchId = (DateTypeSearchEnum)this.frmOpportunity.uosSchDates.Value;
            pmtOpportunity.OnlyNotRelatedToTenders = ((GenericSearchForm<Opportunity>)
                this.frmOpportunity).ParentSearchForm != null;

            DataTable dtOpportunitys = srvOpportunity.SearchByParameters(pmtOpportunity);

            this.frmOpportunity.grdSchSearch.DataSource = null;
            this.frmOpportunity.grdSchSearch.DataSource = dtOpportunitys;
        }

        private void GenerateTender()
        {
            this.tender = new Tender();

            this.tender.Opportunity = this.opportunity;
            this.tender.Bidder = srvBidder.GetById(Convert.ToInt32(this.frmOpportunity.uceDetBidder.Value));
            this.tender.Dependency = srvDependency.GetById(Convert.ToInt32(this.frmOpportunity.uceDetDependency.Value));
            this.tender.EndUser = srvEndUser.GetById(Convert.ToInt32(this.frmOpportunity.uceDetEndUser.Value));
            this.tender.Asesor = srvAsesor.GetById(Convert.ToInt32(this.frmOpportunity.uceDetAsesor.Value));

            this.tender.Deadline = (Nullable<DateTime>)this.frmOpportunity.dteDetDeadline.Value;
            this.tender.PreRevisionDate = (Nullable<DateTime>)this.frmOpportunity.dteDetPrerevisionDate.Value;
            this.tender.RegistrationDate = (Nullable<DateTime>)this.frmOpportunity.dteDetRegistrationDate.Value;
            this.tender.AcquisitionReason = this.frmOpportunity.txtDetAcquisitionReason.Text;
            this.tender.Name = this.frmOpportunity.txtDetOpportunityName.Text;

            this.tender.Activated = true;
            this.tender.Deleted = false;


            foreach (OpportunityLog opportunityLog in 
                this.opportunity.OpportunityLogs.Where(x => x.Activated && !x.Deleted))
            {
                TenderLog tenderLog = new TenderLog();
                ObjectsUtil.CopyProperties(tenderLog, opportunityLog);
                tenderLog.Tender = this.tender;
                this.tender.TenderLogs.Add(tenderLog);
            }

            this.srvTender.Save(this.tender);

            this.frmOpportunity.txtDetRelatedTender.Text = this.tender.Name;
            this.frmOpportunity.gbxDetRelatedTender.Visible = true;
            this.frmOpportunity.ubtnDetGenerateTender.Visible = false;
        }

        private void LoadOpportunityLogs()
        {
            foreach (OpportunityLog opportunityLog in this.opportunity.OpportunityLogs)
            {
                opportunityLog.Deleted = true;
                opportunityLog.Activated = false;
            }

            foreach (DataRow row in this.dtOpportunityLog.Rows)
            {
                OpportunityLog opportunityLog = this.opportunity.OpportunityLogs
                    .SingleOrDefault(x => row["OpportunityLogId"] != DBNull.Value &&
                        x.OpportunityLogId == Convert.ToInt32(row["OpportunityLogId"]));

                if (opportunityLog == null)
                {
                    opportunityLog = new OpportunityLog();
                    this.opportunity.OpportunityLogs.Add(opportunityLog);
                }

                opportunityLog.Opportunity = this.opportunity;
                opportunityLog.Description = row["Description"].ToString();
                opportunityLog.LogDate = Convert.ToDateTime(row["LogDate"]);
                opportunityLog.Activated = true;
                opportunityLog.Deleted = false;
            }
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
                lstDependencies, "DependencyId", "Name", "Seleccione");
        }

        private void uceDetBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = Convert.ToInt32(this.frmOpportunity.uceDetBidder.Value);
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmOpportunity.uceDetDependency,
                lstDependencies, "DependencyId", "Name", "Seleccione");
        }

        private void uceSchDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = Convert.ToInt32(this.frmOpportunity.uceSchDependency.Value);
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmOpportunity.uceSchEndUser,
                lstEndUsers, "EndUserId", "Name", "Seleccione");
        }

        private void uceDetDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = Convert.ToInt32(this.frmOpportunity.uceDetDependency.Value);
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmOpportunity.uceDetEndUser,
                lstEndUsers, "EndUserId", "Name", "Seleccione");
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
            if (this.ValidateFormInformation())
            {
                this.SaveOpportunity();
                this.GenerateTender();
            }
        }

        private void uceDetOpportunityType_ValueChanged(object sender, EventArgs e)
        {
            this.frmOpportunity.uceDetBidder.Value = -1;
            this.frmOpportunity.uceDetOrganization.Value = -1; 
            
            int type = (int)this.frmOpportunity.uceDetOpportunityType.Value;
            
            if (type == (int)OpportunityTypeEnum.PublicSector ||
                type == (int)OpportunityTypeEnum.PrivateSector)
            {
                bool flag = (int)OpportunityTypeEnum.PublicSector == type;

                this.frmOpportunity.lblDetBidder.Visible = flag;
                this.frmOpportunity.lblDetDependency.Visible = flag;
                this.frmOpportunity.lblDetEndUser.Visible = flag;
                this.frmOpportunity.lblDetOrganization.Visible = !flag;
                this.frmOpportunity.uceDetBidder.Visible = flag;
                this.frmOpportunity.uceDetDependency.Visible = flag;
                this.frmOpportunity.uceDetEndUser.Visible = flag;
                this.frmOpportunity.uceDetOrganization.Visible = !flag;
            }
            else
            {
                this.frmOpportunity.lblDetBidder.Visible = false;
                this.frmOpportunity.lblDetDependency.Visible = false;
                this.frmOpportunity.lblDetEndUser.Visible = false;
                this.frmOpportunity.lblDetOrganization.Visible = false;
                this.frmOpportunity.uceDetBidder.Visible = false;
                this.frmOpportunity.uceDetDependency.Visible = false;
                this.frmOpportunity.uceDetEndUser.Visible = false;
                this.frmOpportunity.uceDetOrganization.Visible = false;
            }

            this.ShowHideGenerateTenderButton();
        }

        private void uceSchOpportunityType_ValueChanged(object sender, EventArgs e)
        {
            this.frmOpportunity.uceSchBidder.Value = -1;
            this.frmOpportunity.uceSchOrganization.Value = -1;

            int type = (int)this.frmOpportunity.uceSchOpportunityType.Value;

            if (type == (int)OpportunityTypeEnum.PublicSector ||
                type == (int)OpportunityTypeEnum.PrivateSector)
            {
                bool flag = (int)OpportunityTypeEnum.PublicSector == type;

                this.frmOpportunity.lblSchBidder.Visible = flag;
                this.frmOpportunity.lblSchDependency.Visible = flag;
                this.frmOpportunity.lblSchEndUser.Visible = flag;
                this.frmOpportunity.lblSchOrganization.Visible = !flag;
                this.frmOpportunity.uceSchBidder.Visible = flag;
                this.frmOpportunity.uceSchDependency.Visible = flag;
                this.frmOpportunity.uceSchEndUser.Visible = flag;
                this.frmOpportunity.uceSchOrganization.Visible = !flag;
            }
            else
            {
                this.frmOpportunity.lblSchBidder.Visible = false;
                this.frmOpportunity.lblSchDependency.Visible = false;
                this.frmOpportunity.lblSchEndUser.Visible = false;
                this.frmOpportunity.lblSchOrganization.Visible = false;
                this.frmOpportunity.uceSchBidder.Visible = false;
                this.frmOpportunity.uceSchDependency.Visible = false;
                this.frmOpportunity.uceSchEndUser.Visible = false;
                this.frmOpportunity.uceSchOrganization.Visible = false;
            }
        }

        private void ubtnDetCreateLog_Click(object sender, EventArgs e)
        {
            if (this.frmOpportunity.txtDetLog.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe escribir un momentario para agregarlo a la bitácora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataRow newRow = this.dtOpportunityLog.NewRow();
            this.dtOpportunityLog.Rows.InsertAt(newRow, 0);
            newRow["Description"] = this.frmOpportunity.txtDetLog.Text;
            newRow["LogDate"] = DateTime.Now;
            this.frmOpportunity.txtDetLog.Text = string.Empty;
            this.dtOpportunityLog.AcceptChanges();
        }

        private void grdDetLog_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmOpportunity.grdDetLog.DisplayLayout;
            UltraGridBand band = layout.Bands[0];

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.DefaultRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFree;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;
            band.Columns["OpportunityLogId"].CellActivation = Activation.ActivateOnly;
            band.Columns["LogDate"].CellActivation = Activation.ActivateOnly;
        }

        private void grdDetLog_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            e.Cell.Row.PerformAutoSize();
        }

        #endregion Events
    }
}
