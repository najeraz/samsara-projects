
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Controls.EventsHandlers;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Forms;
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

            this.frmOpportunity.otcSchOpportunityType.Parameters = pmtOpportunityType;
            this.frmOpportunity.otcSchOpportunityType.Refresh();

            this.frmOpportunity.otcDetOpportunityType.Parameters = pmtOpportunityType;
            this.frmOpportunity.otcDetOpportunityType.Refresh();

            this.frmOpportunity.otcDetOpportunityType.ValueChanged +=
                new SamsaraEntityChooserValueChangedEventHandler<OpportunityType>(otcDetOpportunityType_ValueChanged);
            this.frmOpportunity.otcSchOpportunityType.ValueChanged 
                += new SamsaraEntityChooserValueChangedEventHandler<OpportunityType>(otcSchOpportunityType_ValueChanged);

            this.otcDetOpportunityType_ValueChanged(null, null);
            this.otcSchOpportunityType_ValueChanged(null, null);

            // Bidder
            BidderParameters pmtBidder = new BidderParameters();

            this.frmOpportunity.bcDetBidder.Parameters = pmtBidder;
            this.frmOpportunity.bcDetBidder.Refresh();

            this.frmOpportunity.bcSchBidder.Parameters = pmtBidder;
            this.frmOpportunity.bcSchBidder.Refresh();

            this.frmOpportunity.bcSchBidder.ValueChanged 
                += new SamsaraEntityChooserValueChangedEventHandler<Bidder>(bcSchBidder_ValueChanged);
            this.frmOpportunity.bcDetBidder.ValueChanged
                += new SamsaraEntityChooserValueChangedEventHandler<Bidder>(bcDetBidder_ValueChanged);

            // Dependency
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = ParameterConstants.IntNone;

            this.frmOpportunity.dcSchDependency.Parameters = pmtDependency;
            this.frmOpportunity.dcSchDependency.Refresh();

            this.frmOpportunity.dcDetDependency.Parameters = pmtDependency;
            this.frmOpportunity.dcDetDependency.Refresh();

            this.frmOpportunity.dcSchDependency.ValueChanged 
                += new SamsaraEntityChooserValueChangedEventHandler<Dependency>(dcSchDependency_ValueChanged);
            this.frmOpportunity.dcDetDependency.ValueChanged 
                += new SamsaraEntityChooserValueChangedEventHandler<Dependency>(dcDetDependency_ValueChanged);

            // EndUser
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = ParameterConstants.IntNone;

            this.frmOpportunity.eucSchEndUser.Parameters = pmtEndUser;
            this.frmOpportunity.eucSchEndUser.Refresh();

            this.frmOpportunity.eucDetEndUser.Parameters = pmtEndUser;
            this.frmOpportunity.eucDetEndUser.Refresh();

            // Asesor
            AsesorParameters pmtAsesor = new AsesorParameters();

            this.frmOpportunity.acDetAsesor.Parameters = pmtAsesor;
            this.frmOpportunity.acDetAsesor.Refresh();

            this.frmOpportunity.acSchAsesor.Parameters = pmtAsesor;
            this.frmOpportunity.acSchAsesor.Refresh();

            // OpportunityStatus
            OpportunityStatusParameters pmtOpportunityStatus = new OpportunityStatusParameters();

            this.frmOpportunity.osDetOpportunityStatus.Parameters = pmtOpportunityStatus;
            this.frmOpportunity.osDetOpportunityStatus.Refresh();

            this.frmOpportunity.oscSchOpportunityStatus.Parameters = pmtOpportunityStatus;
            this.frmOpportunity.oscSchOpportunityStatus.Refresh();

            // Organization
            OrganizationParameters pmtOrganization = new OrganizationParameters();

            this.frmOpportunity.ocDetOrganization.Parameters = pmtOrganization;
            this.frmOpportunity.ocDetOrganization.Refresh();

            this.frmOpportunity.ocSchOrganization.Parameters = pmtOrganization;
            this.frmOpportunity.ocSchOrganization.Refresh();

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
            if ((int)this.frmOpportunity.otcDetOpportunityType.Value.OpportunityTypeId == (int)OpportunityTypeEnum.PublicSector
                && (this.frmOpportunity.bcDetBidder.Value == null))
            {
                MessageBox.Show("Favor de seleccionar el Licitante.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOpportunity.tabDetDetail.SelectedTab =
                    this.frmOpportunity.tabDetDetail.TabPages["Principal"];
                this.frmOpportunity.bcDetBidder.Focus();
                return false;
            }

            if ((int)this.frmOpportunity.otcDetOpportunityType.Value.OpportunityTypeId == (int)OpportunityTypeEnum.PublicSector
                && (this.frmOpportunity.ocDetOrganization.Value == null))
            {
                MessageBox.Show("Favor de seleccionar la Organización.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOpportunity.tabDetDetail.SelectedTab =
                    this.frmOpportunity.tabDetDetail.TabPages["Principal"];
                this.frmOpportunity.ocDetOrganization.Focus();
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
            this.opportunity.OpportunityType = this.frmOpportunity.otcDetOpportunityType.Value;
            this.opportunity.Organization = this.frmOpportunity.ocDetOrganization.Value;
            this.opportunity.Bidder = this.frmOpportunity.bcDetBidder.Value;
            this.opportunity.Dependency = this.frmOpportunity.dcDetDependency.Value;
            this.opportunity.EndUser = this.frmOpportunity.eucDetEndUser.Value;
            this.opportunity.Asesor = this.frmOpportunity.acDetAsesor.Value;
            this.opportunity.OpportunityStatus = this.frmOpportunity.osDetOpportunityStatus.Value;

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
            this.frmOpportunity.otcDetOpportunityType.Value = null;
            this.frmOpportunity.acDetAsesor.Value = null;
            this.frmOpportunity.bcDetBidder.Value = null;
            this.frmOpportunity.dcDetDependency.Value = null;
            this.frmOpportunity.eucDetEndUser.Value = null;
            this.frmOpportunity.ocDetOrganization.Value = null;
            this.frmOpportunity.osDetOpportunityStatus.Value = null;
            this.frmOpportunity.txtDetAcquisitionReason.Text = string.Empty;
            this.frmOpportunity.txtDetOpportunityName.Text = string.Empty;
            this.frmOpportunity.dteDetDeadline.Value = null;
            this.frmOpportunity.dteDetPrerevisionDate.Value = null;
            this.frmOpportunity.dteDetRegistrationDate.Value = null;
            this.frmOpportunity.txtDetRelatedTender.Text = string.Empty;
            this.frmOpportunity.ubtnDetGenerateTender.Visible = false;
            this.frmOpportunity.gbxDetRelatedTender.Visible = false;
            this.frmOpportunity.otcDetOpportunityType.ReadOnly = false;
            this.frmOpportunity.uchkDetIsLOR.Checked = false;
            this.dtOpportunityLog.Rows.Clear();
        }

        private void ClearSearchControls()
        {
            this.frmOpportunity.txtSchOpportunityName.Text = string.Empty;
            this.frmOpportunity.otcSchOpportunityType.Value = null;
            this.frmOpportunity.bcSchBidder.Value = null;
            this.frmOpportunity.dcSchDependency.Value = null;
            this.frmOpportunity.eucSchEndUser.Value = null;
            this.frmOpportunity.ocSchOrganization.Value = null;
            this.frmOpportunity.acSchAsesor.Value = null;
            this.frmOpportunity.oscSchOpportunityStatus.Value = null;
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
                try
                {
                    this.frmOpportunity.Cursor = Cursors.WaitCursor;
                    this.LoadEntity();
                    this.srvOpportunity.SaveOrUpdate(this.opportunity);
                    this.EditOpportunity(this.opportunity.OpportunityId);
                }
                finally
                {
                    this.frmOpportunity.Cursor = Cursors.Default;
                }
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
            this.frmOpportunity.otcDetOpportunityType.Value = this.opportunity.OpportunityType;
            this.frmOpportunity.bcDetBidder.Value = this.opportunity.Bidder;
            this.frmOpportunity.dcDetDependency.Value = this.opportunity.Dependency;
            this.frmOpportunity.eucDetEndUser.Value = this.opportunity.EndUser;
            this.frmOpportunity.acDetAsesor.Value = this.opportunity.Asesor;
            this.frmOpportunity.ocDetOrganization.Value = this.opportunity.Organization;
            this.frmOpportunity.osDetOpportunityStatus.Value = this.opportunity.OpportunityStatus;
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
                    this.frmOpportunity.otcDetOpportunityType.Value != null &&
                    this.frmOpportunity.otcDetOpportunityType.Value.OpportunityTypeId
                    == (int)OpportunityTypeEnum.PublicSector
                    && this.frmOpportunity.uchkDetIsLOR.Checked == false;
                this.frmOpportunity.gbxDetRelatedTender.Visible = false;
            }
            else
            {
                this.frmOpportunity.txtDetRelatedTender.Text = this.tender.Name;
                this.frmOpportunity.ubtnDetGenerateTender.Visible = false;
                this.frmOpportunity.gbxDetRelatedTender.Visible = true;
                this.frmOpportunity.otcDetOpportunityType.ReadOnly = true;
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
            pmtOpportunity.OpportunityTypeId = this.frmOpportunity.otcSchOpportunityType.Value == null ?
                -1 : this.frmOpportunity.otcSchOpportunityType.Value.OpportunityTypeId;
            pmtOpportunity.OrganizationId = this.frmOpportunity.ocSchOrganization.Value == null ?
                -1 : this.frmOpportunity.ocSchOrganization.Value.OrganizationId;
            pmtOpportunity.BidderId = this.frmOpportunity.bcSchBidder.Value == null ?
                -1 : this.frmOpportunity.bcSchBidder.Value.BidderId;
            pmtOpportunity.DependencyId = this.frmOpportunity.dcSchDependency.Value == null ?
                -1 : this.frmOpportunity.dcSchDependency.Value.DependencyId;
            pmtOpportunity.EndUserId = this.frmOpportunity.eucSchEndUser.Value == null ?
                -1 : this.frmOpportunity.eucSchEndUser.Value.EndUserId;
            pmtOpportunity.AsesorId = this.frmOpportunity.acSchAsesor.Value == null ?
                -1 : this.frmOpportunity.acSchAsesor.Value.AsesorId;
            pmtOpportunity.OpportunityStatusId = this.frmOpportunity.oscSchOpportunityStatus.Value == null ?
                -1 : this.frmOpportunity.oscSchOpportunityStatus.Value.OpportunityStatusId;
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
            this.tender.Bidder = this.frmOpportunity.bcDetBidder.Value;
            this.tender.Dependency = this.frmOpportunity.dcDetDependency.Value;
            this.tender.EndUser = this.frmOpportunity.eucDetEndUser.Value;
            this.tender.Asesor = this.frmOpportunity.acDetAsesor.Value;

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

        private void bcSchBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = this.frmOpportunity.bcSchBidder.Value == null ?
                -1 : this.frmOpportunity.bcSchBidder.Value.BidderId;

            this.frmOpportunity.dcSchDependency.Parameters = pmtDependency;
            this.frmOpportunity.dcSchDependency.Refresh();
        }

        private void bcDetBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = this.frmOpportunity.bcDetBidder.Value == null ?
                -1 : this.frmOpportunity.bcDetBidder.Value.BidderId;

            this.frmOpportunity.dcDetDependency.Parameters = pmtDependency;
            this.frmOpportunity.dcDetDependency.Refresh();
        }

        private void dcSchDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = this.frmOpportunity.dcSchDependency.Value == null ?
                -1 : this.frmOpportunity.dcSchDependency.Value.DependencyId;

            this.frmOpportunity.eucSchEndUser.Parameters = pmtEndUser;
            this.frmOpportunity.eucSchEndUser.Refresh();
        }

        private void dcDetDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = this.frmOpportunity.dcDetDependency.Value == null ?
                -1 : this.frmOpportunity.dcDetDependency.Value.DependencyId;

            this.frmOpportunity.eucDetEndUser.Parameters = pmtEndUser;
            this.frmOpportunity.eucDetEndUser.Refresh();
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

        private void otcDetOpportunityType_ValueChanged(object sender, EventArgs e)
        {
            this.frmOpportunity.bcDetBidder.Value = null;
            this.frmOpportunity.ocDetOrganization.Value = null;

            int type = this.frmOpportunity.otcDetOpportunityType.Value == null ?
                -1 : this.frmOpportunity.otcDetOpportunityType.Value.OpportunityTypeId;
            
            if (type == (int)OpportunityTypeEnum.PublicSector ||
                type == (int)OpportunityTypeEnum.PrivateSector)
            {
                bool flag = (int)OpportunityTypeEnum.PublicSector == type;

                this.frmOpportunity.lblDetBidder.Visible = flag;
                this.frmOpportunity.lblDetDependency.Visible = flag;
                this.frmOpportunity.lblDetEndUser.Visible = flag;
                this.frmOpportunity.lblDetOrganization.Visible = !flag;
                this.frmOpportunity.bcDetBidder.Visible = flag;
                this.frmOpportunity.dcDetDependency.Visible = flag;
                this.frmOpportunity.eucDetEndUser.Visible = flag;
                this.frmOpportunity.ocDetOrganization.Visible = !flag;
            }
            else
            {
                this.frmOpportunity.lblDetBidder.Visible = false;
                this.frmOpportunity.lblDetDependency.Visible = false;
                this.frmOpportunity.lblDetEndUser.Visible = false;
                this.frmOpportunity.lblDetOrganization.Visible = false;
                this.frmOpportunity.bcDetBidder.Visible = false;
                this.frmOpportunity.dcDetDependency.Visible = false;
                this.frmOpportunity.eucDetEndUser.Visible = false;
                this.frmOpportunity.ocDetOrganization.Visible = false;
            }

            this.ShowHideGenerateTenderButton();
        }

        private void otcSchOpportunityType_ValueChanged(object sender, EventArgs e)
        {
            this.frmOpportunity.bcSchBidder.Value = null;
            this.frmOpportunity.ocSchOrganization.Value = null;

            int type = this.frmOpportunity.otcSchOpportunityType.Value == null ?
                -1 : this.frmOpportunity.otcSchOpportunityType.Value.OpportunityTypeId;

            if (type == (int)OpportunityTypeEnum.PublicSector ||
                type == (int)OpportunityTypeEnum.PrivateSector)
            {
                bool flag = (int)OpportunityTypeEnum.PublicSector == type;

                this.frmOpportunity.lblSchBidder.Visible = flag;
                this.frmOpportunity.lblSchDependency.Visible = flag;
                this.frmOpportunity.lblSchEndUser.Visible = flag;
                this.frmOpportunity.lblSchOrganization.Visible = !flag;
                this.frmOpportunity.bcSchBidder.Visible = flag;
                this.frmOpportunity.dcSchDependency.Visible = flag;
                this.frmOpportunity.eucSchEndUser.Visible = flag;
                this.frmOpportunity.ocSchOrganization.Visible = !flag;
            }
            else
            {
                this.frmOpportunity.lblSchBidder.Visible = false;
                this.frmOpportunity.lblSchDependency.Visible = false;
                this.frmOpportunity.lblSchEndUser.Visible = false;
                this.frmOpportunity.lblSchOrganization.Visible = false;
                this.frmOpportunity.bcSchBidder.Visible = false;
                this.frmOpportunity.dcSchDependency.Visible = false;
                this.frmOpportunity.eucSchEndUser.Visible = false;
                this.frmOpportunity.ocSchOrganization.Visible = false;
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
