
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Enums;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.Support.Util;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class TenderFormController
    {
        #region Attributes

        private Tender tender;
        private TenderForm frmTender;
        private TabPage hiddenTenderDetailTab;

        private IBidderService srvBidder;
        private IAsesorService srvAsesor;
        private ITenderService srvTender;
        private IEndUserService srvEndUser;
        private ITenderLogService srvTenderLog;
        private ICompetitorService srvCompetitor;
        private IWholesalerService srvWholesaler;
        private ITenderLineService srvTenderLine;
        private IDependencyService srvDependency;
        private ITenderStatusService srvTenderStatus;
        private IManufacturerService srvManufacturer;
        private ITenderCompetitorService srvTenderCompetitor;
        private ITenderWholesalerService srvTenderWholesaler;
        private ITenderManufacturerService srvTenderManufacturer;

        private DataTable dtTenderLog;
        private DataTable dtTenderLines;
        private DataTable dtTenderManufacturers;
        private DataTable dtTenderCompetitors;
        private DataTable dtTenderWholesalers;
        private DataTable dtPriceComparison;
        private DataTable dtPricingStrategy;
        private DataTable dtPreresults;

        #endregion Attributes

        #region Constructor

        public TenderFormController(TenderForm instance)
        {
            this.frmTender = instance;
            this.srvBidder = SamsaraAppContext.Resolve<IBidderService>();
            Assert.IsNotNull(this.srvBidder);
            this.srvDependency = SamsaraAppContext.Resolve<IDependencyService>();
            Assert.IsNotNull(this.srvDependency);
            this.srvEndUser = SamsaraAppContext.Resolve<IEndUserService>();
            Assert.IsNotNull(this.srvEndUser);
            this.srvAsesor = SamsaraAppContext.Resolve<IAsesorService>();
            Assert.IsNotNull(this.srvAsesor);
            this.srvTenderStatus = SamsaraAppContext.Resolve<ITenderStatusService>();
            Assert.IsNotNull(this.srvTenderStatus);
            this.srvTender = SamsaraAppContext.Resolve<ITenderService>();
            Assert.IsNotNull(this.srvTender);
            this.srvTenderLine = SamsaraAppContext.Resolve<ITenderLineService>();
            Assert.IsNotNull(this.srvTenderLine);
            this.srvTenderLog = SamsaraAppContext.Resolve<ITenderLogService>();
            Assert.IsNotNull(this.srvTenderLog);
            this.srvTenderCompetitor = SamsaraAppContext.Resolve<ITenderCompetitorService>();
            Assert.IsNotNull(this.srvTenderCompetitor);
            this.srvTenderWholesaler = SamsaraAppContext.Resolve<ITenderWholesalerService>();
            Assert.IsNotNull(this.srvTenderWholesaler);
            this.srvTenderManufacturer = SamsaraAppContext.Resolve<ITenderManufacturerService>();
            Assert.IsNotNull(this.srvTenderManufacturer);
            this.srvManufacturer = SamsaraAppContext.Resolve<IManufacturerService>();
            Assert.IsNotNull(this.srvManufacturer);
            this.srvCompetitor = SamsaraAppContext.Resolve<ICompetitorService>();
            Assert.IsNotNull(this.srvCompetitor);
            this.srvWholesaler = SamsaraAppContext.Resolve<IWholesalerService>();
            Assert.IsNotNull(this.srvWholesaler);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            // Asesor
            AsesorParameters pmtAsesor = new AsesorParameters();
            IList<Asesor> lstAsesors = srvAsesor.GetListByParameters(pmtAsesor);

            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTender.uceSchAsesor,
                lstAsesors, "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTender.uceDetAsesor,
                lstAsesors, "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTender.uceDetApprovedBy,
                lstAsesors.Where(x => x.CanApprove == true), "AsesorId", "Name");

            // TenderStatus
            TenderStatusParameters pmtTenderStatus = new TenderStatusParameters();
            IList<TenderStatus> lstTenderStatuses = srvTenderStatus.GetListByParameters(pmtTenderStatus);

            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTender.uceSchTenderStatus,
                lstTenderStatuses, "TenderStatusId", "Name");
            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTender.uceDetTenderStatus,
                lstTenderStatuses, "TenderStatusId", "Name");

            // Bidder
            BidderParameters pmtBidder = new BidderParameters();
            IList<Bidder> lstBidders = srvBidder.GetListByParameters(pmtBidder);

            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTender.uceSchBidder,
                lstBidders, "BidderId", "Name");
            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTender.uceDetBidder,
                lstBidders, "BidderId", "Name");

            this.frmTender.uceSchBidder.ValueChanged += new EventHandler(uceSchBidder_ValueChanged);
            this.frmTender.uceDetBidder.ValueChanged += new EventHandler(uceDetBidder_ValueChanged);

            // Dependency
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = ParameterConstants.IntNone;
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTender.uceSchDependency,
                lstDependencies, "DependencyId", "Name");
            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTender.uceDetDependency,
                lstDependencies, "DependencyId", "Name");

            this.frmTender.uceSchDependency.ValueChanged += new EventHandler(uceSchDependency_ValueChanged);
            this.frmTender.uceDetDependency.ValueChanged += new EventHandler(uceDetDependency_ValueChanged);

            // EndUser
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = ParameterConstants.IntNone;
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTender.uceSchEndUser,
                lstEndUsers, "EndUserId", "Name");
            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTender.uceDetEndUser,
                lstEndUsers, "EndUserId", "Name");

            //grdTenderLines
            this.frmTender.grdDetTenderLines.InitializeLayout
                += new InitializeLayoutEventHandler(grdTenderLines_InitializeLayout);
            this.frmTender.grdDetTenderLines.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdTenderLines_BeforeCellUpdate);
            TenderLineParameters pmtTenderLine = new TenderLineParameters();
            pmtTenderLine.TenderId = ParameterConstants.IntNone;
            this.dtTenderLines = this.srvTenderLine.SearchByParameters(pmtTenderLine);
            this.frmTender.grdDetTenderLines.DataSource = null;
            this.frmTender.grdDetTenderLines.DataSource = dtTenderLines;

            //grdDetTenderCompetitors
            this.frmTender.grdDetTenderCompetitors.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderCompetitors_InitializeLayout);
            this.frmTender.grdDetTenderCompetitors.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdDetTenderCompetitors_BeforeCellUpdate);
            TenderCompetitorParameters pmtTenderCompetitor = new TenderCompetitorParameters();
            pmtTenderCompetitor.TenderId = ParameterConstants.IntNone;
            this.dtTenderCompetitors = this.srvTenderCompetitor.SearchByParameters(pmtTenderCompetitor);
            this.frmTender.grdDetTenderCompetitors.DataSource = null;
            this.frmTender.grdDetTenderCompetitors.DataSource = dtTenderCompetitors;

            //grdDetTenderWholesalers
            this.frmTender.grdDetTenderWholesalers.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderWholesalers_InitializeLayout);
            this.frmTender.grdDetTenderWholesalers.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdDetTenderWholesalers_BeforeCellUpdate);
            this.frmTender.grdDetTenderWholesalers.AfterCellUpdate += 
                new CellEventHandler(grdDetTenderWholesalers_AfterCellUpdate);
            TenderWholesalerParameters pmtTenderWholesaler = new TenderWholesalerParameters();
            pmtTenderWholesaler.TenderId = ParameterConstants.IntNone;
            this.dtTenderWholesalers = this.srvTenderWholesaler.SearchByParameters(pmtTenderWholesaler);
            this.frmTender.grdDetTenderWholesalers.DataSource = null;
            this.frmTender.grdDetTenderWholesalers.DataSource = dtTenderWholesalers;

            //grdDetTenderManufacturers
            this.frmTender.grdDetTenderManufacturers.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderManufacturers_InitializeLayout);
            this.frmTender.grdDetTenderManufacturers.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdDetTenderManufacturers_BeforeCellUpdate);
            TenderManufacturerParameters pmtSearchTenderManufacturers
                = new TenderManufacturerParameters();
            pmtSearchTenderManufacturers.TenderId = ParameterConstants.IntDefault;
            this.dtTenderManufacturers =
                this.srvTenderManufacturer.SearchByParameters(pmtSearchTenderManufacturers);
            this.frmTender.grdDetTenderManufacturers.DataSource = null;
            this.frmTender.grdDetTenderManufacturers.DataSource = dtTenderManufacturers;

            //grdDetPriceComparison
            this.frmTender.grdDetPriceComparison.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetPriceComparison_InitializeLayout);
            this.frmTender.grdDetPriceComparison.BeforeCellUpdate +=
                new BeforeCellUpdateEventHandler(grdDetPriceComparison_BeforeCellUpdate);

            //grdDetPriceComparison
            this.frmTender.grdDetPreresults.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetPreresults_InitializeLayout);
            this.frmTender.grdDetPreresults.BeforeCellUpdate +=
                new BeforeCellUpdateEventHandler(grdDetPreresults_BeforeCellUpdate);

            //grdDetLog
            this.frmTender.grdDetLog.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetLog_InitializeLayout);
            this.frmTender.grdDetLog.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdDetLog_BeforeCellUpdate);
            TenderLogParameters pmtTenderLog = new TenderLogParameters();
            pmtTenderLog.TenderLogId = ParameterConstants.IntNone;
            this.dtTenderLog = this.srvTenderLog.SearchByParameters(pmtTenderLog);
            this.frmTender.grdDetLog.DataSource = null;
            this.frmTender.grdDetLog.DataSource = this.dtTenderLog;

            this.frmTender.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmTender.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmTender.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmTender.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmTender.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmTender.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);
            this.frmTender.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmTender.ubtnDetDeleteManufacturer.Click += new EventHandler(ubtnDetDeleteManufacturer_Click);
            this.frmTender.ubtnDetCreateManufacturer.Click += new EventHandler(ubtnDetCreateManufacturer_Click);
            this.frmTender.ubtnDetCreateLine.Click += new EventHandler(ubtnDetCreateLine_Click);
            this.frmTender.ubtnDetDeleteLine.Click += new EventHandler(ubtnDetDeleteLine_Click);
            this.frmTender.ubtnDetCreateLog.Click += new EventHandler(ubtnDetCreateLog_Click);
            this.frmTender.ubtnDetDeleteLog.Click += new EventHandler(ubtnDetDeleteLog_Click);
            this.frmTender.ubtnDetCreateCompetitor.Click += new EventHandler(ubtnDetCreateCompetitor_Click);
            this.frmTender.ubtnDetDeleteCompetitor.Click += new EventHandler(ubtnDetDeleteCompetitor_Click);
            this.frmTender.ubtnDetCreateWholesaler.Click += new EventHandler(ubtnDetCreateWholesaler_Click);
            this.frmTender.ubtnDetDeleteWholesaler.Click += new EventHandler(ubtnDetDeleteWholesaler_Click);

            this.hiddenTenderDetailTab = this.frmTender.tabDetDetail.TabPages["TenderDetails"];
            this.frmTender.uosSchDates.Value = -1;
            this.frmTender.HiddenDetail(true);

            this.frmTender.tscPreviousTender.DisplayMember = "Name";
            this.frmTender.tscPreviousTender.SearchForm = this.frmTender;
            this.frmTender.oscDetRelatedOpportunity.DisplayMember = "Name";
            this.frmTender.oscDetRelatedOpportunity.SearchForm = new OpportunityForm();
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmTender.HiddenDetail(!show);
            if (show)
                this.frmTender.tabPrincipal.SelectedTab = this.frmTender.tabPrincipal.TabPages["New"];
            else
                this.frmTender.tabPrincipal.SelectedTab = this.frmTender.tabPrincipal.TabPages["Search"];
            this.frmTender.tabDetDetail.SelectedTab = this.frmTender.tabDetDetail.TabPages["Principal"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmTender.uceDetBidder.Value == null ||
                Convert.ToInt32(this.frmTender.uceDetBidder.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Licitante.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTender.tabDetDetail.SelectedTab = 
                    this.frmTender.tabDetDetail.TabPages["Principal"];
                this.frmTender.uceDetBidder.Focus();
                return false;
            }

            if (this.frmTender.txtDetTenderName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Licitación.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTender.tabDetDetail.SelectedTab = 
                    this.frmTender.tabDetDetail.TabPages["Principal"];
                this.frmTender.txtDetTenderName.Focus();
                return false;
            }

            foreach (DataRow row in this.dtTenderLines.Rows)
            {
                if (Convert.ToInt32(row["ManufacturerId"]) == -1)
                {
                    MessageBox.Show("Debe seleccionar un fabricante por partida.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTender.tabDetDetail.SelectedTab =
                        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTender.tcDetTextControls.SelectedTab =
                        this.frmTender.tcDetTextControls.TabPages["TenderLines"];
                    return false;
                }

                if (row["Quantity"].ToString().Trim() == string.Empty 
                    || Convert.ToDecimal(row["Quantity"]) <= 0)
                {
                    MessageBox.Show(
                        "Debe poner una cantidad correcta por partida.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTender.tabDetDetail.SelectedTab =
                        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTender.tcDetTextControls.SelectedTab =
                        this.frmTender.tcDetTextControls.TabPages["TenderLines"];
                    return false;
                }
            }

            foreach (DataRow row in this.dtTenderCompetitors.Rows)
            {
                if (Convert.ToInt32(row["CompetitorId"]) == -1)
                {
                    MessageBox.Show(
                        "Debe seleccionar un competidor por renglón en la lista de competidores.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTender.tabDetDetail.SelectedTab =
                        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTender.tcDetTextControls.SelectedTab =
                        this.frmTender.tcDetTextControls.TabPages["Competitors"];
                    return false;
                }
            }

            foreach (DataRow row in this.dtTenderWholesalers.Rows)
            {
                if (Convert.ToInt32(row["WholesalerId"]) == -1)
                {
                    MessageBox.Show(
                        "Debe seleccionar un mayorista por renglón en la lista de mayoristas.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTender.tabDetDetail.SelectedTab =
                        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTender.tcDetTextControls.SelectedTab =
                        this.frmTender.tcDetTextControls.TabPages["Mayoristas"];
                    return false;
                }
            }

            foreach (DataRow row in this.dtTenderManufacturers.Rows)
            {
                if (Convert.ToInt32(row["ManufacturerId"]) == -1)
                {
                    MessageBox.Show(
                        "Debe seleccionar un fabricante por renglón en la lista de fabricantes.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTender.tabDetDetail.SelectedTab =
                        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTender.tcDetTextControls.SelectedTab =
                        this.frmTender.tcDetTextControls.TabPages["Manufacturers"];
                    return false;
                }
            }

            return true;
        }

        private void LoadEntity()
        {
            this.tender.Bidder = srvBidder.GetById(Convert.ToInt32(this.frmTender.uceDetBidder.Value));
            this.tender.Dependency = srvDependency.GetById(Convert.ToInt32(this.frmTender.uceDetDependency.Value));
            this.tender.EndUser = srvEndUser.GetById(Convert.ToInt32(this.frmTender.uceDetEndUser.Value));
            this.tender.Asesor = srvAsesor.GetById(Convert.ToInt32(this.frmTender.uceDetAsesor.Value));
            this.tender.ApprovedBy = srvAsesor.GetById(Convert.ToInt32(this.frmTender.uceDetApprovedBy.Value));
            this.tender.TenderStatus = srvTenderStatus.GetById(Convert.ToInt32(this.frmTender.uceDetTenderStatus.Value));

            this.tender.ClarificationDate = (Nullable<DateTime>)this.frmTender.dteDetClarificationDate.Value;
            this.tender.Deadline = (Nullable<DateTime>)this.frmTender.dteDetDeadline.Value;
            this.tender.PreRevisionDate = (Nullable<DateTime>)this.frmTender.dteDetPrerevisionDate.Value;
            this.tender.RegistrationDate = (Nullable<DateTime>)this.frmTender.dteDetRegistrationDate.Value;
            this.tender.VerdictDate = (Nullable<DateTime>)this.frmTender.dteDetVeredictDate.Value;
            this.tender.Address = this.frmTender.txtDetAddress.Text;
            this.tender.AcquisitionReason = this.frmTender.txtDetAcquisitionReason.Text;
            this.tender.PricingStrategy = this.frmTender.txtDetPricingStrategy.Text;
            this.tender.Results = this.frmTender.txtDetResults.Text;
            //this.tender.PreResults = this.frmTender.txtDetPreResults.Text;
            this.tender.Name = this.frmTender.txtDetTenderName.Text;
            this.tender.PreviousTender = this.frmTender.tscPreviousTender.Value;
            this.tender.Opportunity = this.frmTender.oscDetRelatedOpportunity.Value;
            this.tender.PriceComparison = this.frmTender.txtDetPriceComparison.Text;

            this.LoadTenderManufacturers();
            this.LoadTenderLines();
            this.LoadTenderWholesalers();
            this.LoadTenderCompetitors();
            this.LoadTenderLogs();

            this.tender.Activated = true;
            this.tender.Deleted = false;
        }

        private void LoadTenderWholesalers()
        {
            foreach (TenderWholesaler tenderWholesaler in this.tender.TenderWholesalers)
            {
                tenderWholesaler.Deleted = true;
                tenderWholesaler.Activated = false;
            }

            foreach (DataRow row in this.dtTenderWholesalers.Rows)
            {
                TenderWholesaler tenderWholesaler = this.tender.TenderWholesalers
                    .SingleOrDefault(x => row["TenderWholesalerId"] != DBNull.Value &&
                        x.TenderWholesalerId == Convert.ToInt32(row["TenderWholesalerId"]) &&
                        Convert.ToInt32(row["TenderWholesalerId"]) > 0);

                if (tenderWholesaler == null)
                {
                    tenderWholesaler = new TenderWholesaler();
                    this.tender.TenderWholesalers.Add(tenderWholesaler);
                }

                tenderWholesaler.Tender = this.tender;
                tenderWholesaler.Description = row["Description"].ToString();
                tenderWholesaler.Wholesaler = this.srvWholesaler.GetById(Convert.ToInt32(row["WholesalerId"]));
                tenderWholesaler.Activated = true;
                tenderWholesaler.Deleted = false;
            }
        }

        private void LoadTenderCompetitors()
        {
            foreach (TenderCompetitor tenderCompetitor in this.tender.TenderCompetitors)
            {
                tenderCompetitor.Deleted = true;
                tenderCompetitor.Activated = false;
            }

            foreach (DataRow row in this.dtTenderCompetitors.Rows)
            {
                TenderCompetitor tenderCompetitor = this.tender.TenderCompetitors
                    .SingleOrDefault(x => row["TenderCompetitorId"] != DBNull.Value &&
                        x.TenderCompetitorId == Convert.ToInt32(row["TenderCompetitorId"]) &&
                        Convert.ToInt32(row["TenderCompetitorId"]) > 0);

                if (tenderCompetitor == null)
                {
                    tenderCompetitor = new TenderCompetitor();
                    this.tender.TenderCompetitors.Add(tenderCompetitor);
                }

                tenderCompetitor.Tender = this.tender;
                tenderCompetitor.Description = row["Description"].ToString();
                tenderCompetitor.CompetitorId = Convert.ToInt32(row["CompetitorId"]);
                tenderCompetitor.Activated = true;
                tenderCompetitor.Deleted = false;
            }
        }

        private void LoadTenderLines()
        {
            foreach (TenderLine tenderLine in this.tender.TenderLines)
            {
                tenderLine.Deleted = true;
                tenderLine.Activated = false;
            }

            foreach (DataRow row in this.dtTenderLines.Rows)
            {
                TenderLine tenderLine = this.tender.TenderLines
                    .SingleOrDefault(x => row["TenderLineId"] != DBNull.Value &&
                        x.TenderLineId == Convert.ToInt32(row["TenderLineId"]) &&
                        Convert.ToInt32(row["TenderLineId"]) > 0);

                if (tenderLine == null)
                {
                    tenderLine = new TenderLine();
                    this.tender.TenderLines.Add(tenderLine);
                }

                tenderLine.Tender = this.tender;
                tenderLine.Description = row["Description"].ToString();
                tenderLine.Manufacturer = this.srvManufacturer.GetById(Convert.ToInt32(row["ManufacturerId"]));
                tenderLine.Name = row["Name"].ToString();
                tenderLine.Quantity = Convert.ToDecimal(row["Quantity"]);
                tenderLine.Activated = true;
                tenderLine.Deleted = false;
            }
        }

        private void LoadTenderManufacturers()
        {
            foreach (TenderManufacturer tenderManufacturer in this.tender.TenderManufacturers)
            {
                tenderManufacturer.Deleted = true;
                tenderManufacturer.Activated = false;
            }

            foreach (DataRow row in this.dtTenderManufacturers.Rows)
            {
                TenderManufacturer tenderManufacturer = this.tender.TenderManufacturers
                    .SingleOrDefault(x => x.Manufacturer.ManufacturerId == Convert.ToInt32(row["ManufacturerId"])
                    && Convert.ToInt32(row["ManufacturerId"]) > 0);

                if (tenderManufacturer == null)
                {
                    tenderManufacturer = new TenderManufacturer();
                    this.tender.TenderManufacturers.Add(tenderManufacturer);
                }

                tenderManufacturer.Tender = this.tender;
                tenderManufacturer.FolioReference = row["FolioReference"].ToString();
                tenderManufacturer.Manufacturer = this.srvManufacturer.GetById(Convert.ToInt32(row["ManufacturerId"]));
                tenderManufacturer.ManufacturerSupport = row["ManufacturerSupport"].ToString();
                tenderManufacturer.Deleted = false;
                tenderManufacturer.Activated = true;
            }
        }

        private void LoadTenderLogs()
        {
            foreach (TenderLog tenderLog in this.tender.TenderLogs)
            {
                tenderLog.Deleted = true;
                tenderLog.Activated = false;
            }

            foreach (DataRow row in this.dtTenderLog.Rows)
            {
                TenderLog tenderLog = this.tender.TenderLogs
                    .SingleOrDefault(x => row["TenderLogId"] != DBNull.Value &&
                        x.TenderLogId == Convert.ToInt32(row["TenderLogId"]) &&
                        Convert.ToInt32(row["TenderLogId"]) > 0);

                if (tenderLog == null)
                {
                    tenderLog = new TenderLog();
                    if (row["Description"].ToString().Trim() != string.Empty)
                        this.tender.TenderLogs.Add(tenderLog);
                }

                tenderLog.Tender = this.tender;
                tenderLog.Description = row["Description"].ToString();
                tenderLog.LogDate = Convert.ToDateTime(row["LogDate"]);
                tenderLog.Activated = true;
                tenderLog.Deleted = false;
            }
        }

        private void ClearDetailControls()
        {
            this.frmTender.uceDetApprovedBy.Value = -1;
            this.frmTender.uceDetAsesor.Value = -1;
            this.frmTender.uceDetBidder.Value = -1;
            this.frmTender.uceDetDependency.Value = -1;
            this.frmTender.uceDetEndUser.Value = -1;
            this.frmTender.uceDetTenderStatus.Value = -1;
            this.frmTender.txtDetAcquisitionReason.Text = string.Empty;
            this.frmTender.txtDetAddress.Text = string.Empty;
            //this.frmTender.txtDetPreResults.Text = string.Empty;
            this.frmTender.txtDetPriceComparison.Text = string.Empty;
            this.frmTender.txtDetPricingStrategy.Text = string.Empty;
            this.frmTender.txtDetResults.Text = string.Empty;
            this.frmTender.txtDetTenderName.Text = string.Empty;
            this.frmTender.dteDetClarificationDate.Value = null;
            this.frmTender.dteDetDeadline.Value = null;
            this.frmTender.dteDetPrerevisionDate.Value = null;
            this.frmTender.dteDetRegistrationDate.Value = null;
            this.frmTender.dteDetVeredictDate.Value = null;
            this.frmTender.oscDetRelatedOpportunity.Clear();
            this.frmTender.tscPreviousTender.Clear();
            this.dtTenderManufacturers.Rows.Clear();
            this.dtTenderLines.Rows.Clear();
            this.dtTenderCompetitors.Rows.Clear();
            this.dtTenderWholesalers.Rows.Clear();
            this.dtTenderLog.Rows.Clear();
            this.dtPriceComparison = null;
            this.frmTender.grdDetPriceComparison.DataSource = null;
        }

        private void ClearSearchControls()
        {
            this.frmTender.txtSchTenderName.Text = string.Empty;
            this.frmTender.uceSchAsesor.Value = -1;
            this.frmTender.uceSchBidder.Value = -1;
            this.frmTender.uceSchDependency.Value = -1;
            this.frmTender.uceSchEndUser.Value = -1;
            this.frmTender.uceSchTenderStatus.Value = -1;
            this.frmTender.uosSchDates.Value = -1;
            this.frmTender.dteSchMaxDate.DateTime = DateTime.Now;
            this.frmTender.dteSchMinDate.DateTime = DateTime.Now;
        }

        private void SaveTender()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Licitación?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvTender.SaveOrUpdate(this.tender);
                this.frmTender.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditTender(int tenderId)
        {
            this.tender = this.srvTender.GetById(tenderId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmTender.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmTender.uceDetApprovedBy.Value = 
                this.tender.ApprovedBy == null ? -1 : this.tender.ApprovedBy.AsesorId;
            this.frmTender.uceDetAsesor.Value =
                this.tender.Asesor == null ? -1 : this.tender.Asesor.AsesorId;
            this.frmTender.uceDetBidder.Value =
                this.tender.Bidder == null ? -1 : this.tender.Bidder.BidderId;
            this.frmTender.uceDetDependency.Value =
                this.tender.Dependency == null ? -1 : this.tender.Dependency.DependencyId;
            this.frmTender.uceDetEndUser.Value =
                this.tender.EndUser == null ? -1 : this.tender.EndUser.EndUserId;
            this.frmTender.uceDetTenderStatus.Value =
                this.tender.TenderStatus == null ? -1 : this.tender.TenderStatus.TenderStatusId;
            this.frmTender.txtDetAcquisitionReason.Text = this.tender.AcquisitionReason;
            this.frmTender.txtDetAddress.Text = this.tender.Address;
            //this.frmTender.txtDetPreResults.Text = this.tender.PreResults;
            this.frmTender.txtDetPriceComparison.Text = this.tender.PriceComparison;
            this.frmTender.txtDetPricingStrategy.Text = this.tender.PricingStrategy;
            this.frmTender.txtDetResults.Text = this.tender.Results;
            this.frmTender.txtDetTenderName.Text = this.tender.Name;
            if (this.tender.ClarificationDate.HasValue)
                this.frmTender.dteDetClarificationDate.Value =  this.tender.ClarificationDate.Value;
            if (this.tender.Deadline.HasValue)
                this.frmTender.dteDetDeadline.Value = this.tender.Deadline.Value;
            if (this.tender.PreRevisionDate.HasValue)
                this.frmTender.dteDetPrerevisionDate.Value = this.tender.PreRevisionDate.Value;
            if (this.tender.RegistrationDate.HasValue)
                this.frmTender.dteDetRegistrationDate.Value = this.tender.RegistrationDate.Value;
            if (this.tender.VerdictDate.HasValue)
                this.frmTender.dteDetVeredictDate.Value = this.tender.VerdictDate.Value;
            this.frmTender.tscPreviousTender.Value = this.tender.PreviousTender;
            this.frmTender.oscDetRelatedOpportunity.Value = this.tender.Opportunity;

            foreach (TenderCompetitor tenderCompetitor in this.tender.TenderCompetitors)
            {
                DataRow row = this.dtTenderCompetitors.NewRow();
                this.dtTenderCompetitors.Rows.Add(row);

                row["Description"] = tenderCompetitor.Description;
                row["CompetitorId"] = tenderCompetitor.CompetitorId;
                row["TenderCompetitorId"] = tenderCompetitor.TenderCompetitorId;
            }

            foreach (TenderWholesaler tenderWholesaler in this.tender.TenderWholesalers)
            {
                DataRow row = this.dtTenderWholesalers.NewRow();
                this.dtTenderWholesalers.Rows.Add(row);

                row["Description"] = tenderWholesaler.Description;
                row["TenderId"] = tenderWholesaler.Tender.TenderId;
                row["WholesalerId"] = tenderWholesaler.Wholesaler.WholesalerId;
                row["TenderWholesalerId"] = tenderWholesaler.TenderWholesalerId;
            }

            foreach (TenderLine tenderLine in this.tender.TenderLines)
            {
                DataRow row = this.dtTenderLines.NewRow();
                this.dtTenderLines.Rows.Add(row);

                row["Description"] = tenderLine.Description;
                row["ManufacturerId"] = tenderLine.Manufacturer.ManufacturerId;
                row["Name"] = tenderLine.Name;
                row["Quantity"] = tenderLine.Quantity;
                row["TenderId"] = tenderLine.Tender.TenderId;
                row["TenderLineId"] = tenderLine.TenderLineId;
            }
            this.grdTenderLines_InitializeLayout(null, null);

            foreach (TenderManufacturer tenderManufacturer in this.tender.TenderManufacturers)
            {
                DataRow row = this.dtTenderManufacturers.NewRow();
                this.dtTenderManufacturers.Rows.Add(row);

                row["FolioReference"] = tenderManufacturer.FolioReference;
                row["ManufacturerId"] = tenderManufacturer.Manufacturer.ManufacturerId;
                row["ManufacturerSupport"] = tenderManufacturer.ManufacturerSupport;
                row["TenderId"] = tenderManufacturer.Tender.TenderId;
                row["TenderManufacturerId"] = tenderManufacturer.TenderManufacturerId;
            }

            foreach (TenderLog tenderLog in this.tender.TenderLogs)
            {
                DataRow row = this.dtTenderLog.NewRow();
                this.dtTenderLog.Rows.Add(row);

                row["Description"] = tenderLog.Description;
                row["LogDate"] = tenderLog.LogDate;
                row["TenderLogId"] = tenderLog.TenderLogId;
                row["TenderId"] = tenderLog.Tender.TenderId;
            }

            this.UpdatePriceComparisonGrid();
        }

        private void DeleteEntity(int tenderId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Licitación?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            this.tender = this.srvTender.GetById(tenderId);
            this.tender.Activated = false;
            this.tender.Deleted = true;
            this.srvTender.SaveOrUpdate(this.tender);
            this.Search();
        }

        private void Search()
        {
            TenderParameters pmtTender = new TenderParameters();

            pmtTender.MinDate = (DateTime)this.frmTender.dteSchMinDate.Value;
            pmtTender.MaxDate = (DateTime)this.frmTender.dteSchMaxDate.Value;
            pmtTender.AsesorId = (int)this.frmTender.uceSchAsesor.Value;
            pmtTender.BidderId = (int)this.frmTender.uceSchBidder.Value;
            pmtTender.DependencyId = (int)this.frmTender.uceSchDependency.Value;
            pmtTender.EndUserId = (int)this.frmTender.uceSchEndUser.Value;
            pmtTender.TenderStatusId = (int)this.frmTender.uceSchTenderStatus.Value;
            pmtTender.Name = "%" + this.frmTender.txtSchTenderName.Text + "%";
            pmtTender.DateTypeSearchId = (DateTypeSearchEnum)this.frmTender.uosSchDates.Value;

            DataTable dtTenders = srvTender.SearchByParameters(pmtTender);

            this.frmTender.grdSchSearch.DataSource = null;
            this.frmTender.grdSchSearch.DataSource = dtTenders;
        }

        private void UpdatePriceComparisonGrid()
        {
            if (this.dtPriceComparison == null)
                this.dtPriceComparison = new DataTable();

            if (!this.dtPriceComparison.Columns.Contains("TenderLineId"))
            {
                DataColumn dcTenderLine = new DataColumn("TenderLineId", typeof(int));
                this.dtPriceComparison.Columns.Add(dcTenderLine);
            }

            if (!this.dtPriceComparison.Columns.Contains("TenderLineName"))
            {
                DataColumn dcTenderLine = new DataColumn("TenderLineName", typeof(string));
                this.dtPriceComparison.Columns.Add(dcTenderLine);
            }

            if (!this.dtPriceComparison.Columns.Contains("SelectedWholesalerId"))
            {
                DataColumn dcTenderLine = new DataColumn("SelectedWholesalerId", typeof(int));
                this.dtPriceComparison.Columns.Add(dcTenderLine);
            }

            if (!this.dtPriceComparison.Columns.Contains("BestPrice"))
            {
                DataColumn dcTenderLine = new DataColumn("BestPrice", typeof(decimal));
                this.dtPriceComparison.Columns.Add(dcTenderLine);
            }

            foreach (int wholesalerId in this.dtTenderWholesalers.AsEnumerable()
                .Select(x => Convert.ToInt32(x["WholesalerId"])))
            {
                if (!this.dtPriceComparison.Columns.Contains(wholesalerId.ToString()))
                {
                    DataColumn dcWholesaler = new DataColumn(wholesalerId.ToString(), typeof(decimal));
                    this.dtPriceComparison.Columns.Add(dcWholesaler);
                    this.dtPriceComparison.Columns[wholesalerId.ToString()]
                        .SetOrdinal(this.dtPriceComparison.Columns.Count - 3);
                }
            }

            IEnumerable<string> columnNames = this.dtPriceComparison.Copy().Columns
                .Cast<DataColumn>().Select(x => x.ColumnName);

            foreach (string columnName in columnNames
                .Where(x => x != "TenderLineName" && x != "TenderLineId" 
                    && x != "BestPrice" && x != "SelectedWholesalerId"))
            {
                if (!this.dtTenderWholesalers.AsEnumerable()
                    .Select(x => x["WholesalerId"].ToString()).Contains(columnName))
                {
                    foreach (TenderLineWholesaler tenderLineWholesaler in
                        this.tender.TenderLines.SelectMany(x => x.TenderLineWholesalers)
                        .Where(x => x.Wholesaler.WholesalerId == Convert.ToInt32(columnName)))
                    {
                        tenderLineWholesaler.Activated = false;
                        tenderLineWholesaler.Deleted = true;
                    }
                    this.dtPriceComparison.Columns.Remove(columnName);
                }
            }

            foreach (DataRow row in this.dtTenderLines.AsEnumerable())
            {
                if (Convert.ToInt32(row["TenderLineId"]) > 0 && !this.dtPriceComparison.Rows.Cast<DataRow>()
                    .Select(x => x["TenderLineId"].ToString()).Contains(row["TenderLineId"].ToString()))
                {
                    DataRow drWholesaler = this.dtPriceComparison.NewRow();
                    drWholesaler["TenderLineId"] = row["TenderLineId"];
                    drWholesaler["SelectedWholesalerId"] = -1;
                    drWholesaler["TenderLineName"] = row["Name"];
                    this.dtPriceComparison.Rows.Add(drWholesaler);
                }
            }

            IEnumerable<DataRow> rows = this.dtPriceComparison.Copy().AsEnumerable();

            foreach (DataRow drTenderLine in rows)
            {
                string tenderLineName = drTenderLine["TenderLineName"].ToString();

                if (!this.dtTenderLines.AsEnumerable()
                    .Select(x => x["Name"].ToString()).Contains(tenderLineName))
                {
                    foreach (TenderLineWholesaler tenderLineWholesaler in
                        this.tender.TenderLines.SelectMany(x => x.TenderLineWholesalers)
                        .Where(x => x.TenderLine.TenderLineId == Convert.ToInt32(drTenderLine["TenderLineId"])))
                    {
                        tenderLineWholesaler.Activated = false;
                        tenderLineWholesaler.Deleted = true;
                    }
                    this.dtPriceComparison.Rows.Remove(this.dtPriceComparison.AsEnumerable()
                        .Single(x => Convert.ToInt32(x["TenderLineId"]) == Convert.ToInt32(drTenderLine["TenderLineId"])));
                }
            }

            foreach (TenderLineWholesaler tenderLineWholesaler in
                this.tender.TenderLines.SelectMany(x => x.TenderLineWholesalers)
                .Where(x => x.Activated && !x.Deleted))
            {
                DataRow row = this.dtPriceComparison.AsEnumerable().SingleOrDefault(x => 
                    Convert.ToInt32(x["TenderLineId"]) == tenderLineWholesaler.TenderLine.TenderLineId);

                if (row != null)
                    if (tenderLineWholesaler.Price != null)
                        row[tenderLineWholesaler.Wholesaler.WholesalerId.ToString()]= tenderLineWholesaler.Price;
                    else
                        row[tenderLineWholesaler.Wholesaler.WholesalerId.ToString()] = DBNull.Value;
            }

            foreach (TenderLine tenderLine in this.tender.TenderLines)
            {
                if (tenderLine.Wholesaler != null)
                {
                    DataRow row = this.dtPriceComparison.AsEnumerable().SingleOrDefault(x =>
                        Convert.ToInt32(x["TenderLineId"]) == tenderLine.TenderLineId);
                    TenderLineWholesaler tenderLineWholesaler = tenderLine.TenderLineWholesalers
                        .Single(x => x.Wholesaler.WholesalerId == tenderLine.Wholesaler.WholesalerId);

                    row["SelectedWholesalerId"] = tenderLine.Wholesaler.WholesalerId;
                    if (tenderLineWholesaler.Price != null)
                        row["BestPrice"] = tenderLineWholesaler.Price;
                    else
                        row["BestPrice"] = DBNull.Value;
                }
            }

            this.dtPriceComparison.AcceptChanges();

            this.frmTender.grdDetPriceComparison.DataSource = null;
            this.frmTender.grdDetPriceComparison.DataSource = dtPriceComparison;
        }

        private Manufacturer GetManufacturer(int manufacturerId)
        {
            Manufacturer manufacturer = null;
            TenderManufacturer tenderManufacturer = this.tender.TenderManufacturers
                .SingleOrDefault(x => x.Manufacturer.ManufacturerId == manufacturerId);

            if (tenderManufacturer != null)
                manufacturer = tenderManufacturer.Manufacturer;
            else
                manufacturer = this.srvManufacturer.GetById(manufacturerId);

            return manufacturer;
        }

        private Wholesaler GetWholesaler(int wholesalerId)
        {
            Wholesaler wholesaler = null;
            TenderWholesaler tenderWholesaler = this.tender.TenderWholesalers
                .SingleOrDefault(x => x.Wholesaler.WholesalerId == wholesalerId);

            if (tenderWholesaler != null)
                wholesaler = tenderWholesaler.Wholesaler;
            else
                wholesaler = this.srvWholesaler.GetById(wholesalerId);

            return wholesaler;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.tender = new Tender();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveTender();
        }
        
        private void grdTenderLines_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetTenderLines.DisplayLayout;
            UltraGridBand band = layout.Bands[0];
            ManufacturerParameters pmtManufacturer = new ManufacturerParameters();
            IList<Manufacturer> lstManufacturers = this.srvManufacturer.GetListByParameters(pmtManufacturer);

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["TenderLineId"].CellActivation = Activation.ActivateOnly;
            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;

            IEnumerable<Manufacturer> availableManufacturers = this.tender == null || 
                this.tender.TenderManufacturers == null ? lstManufacturers.Where(x => false) : 
                lstManufacturers.Where(x => this.tender.TenderManufacturers
                    .Select(y => y.Manufacturer.ManufacturerId).Contains(x.ManufacturerId));

            WindowsFormsUtil.SetUltraGridValueList<Manufacturer>(layout,
                availableManufacturers, band.Columns["ManufacturerId"], "ManufacturerId", "Name");
        }

        private void grdTenderLines_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            e.Cell.Row.PerformAutoSize();
        }

        private void grdDetTenderManufacturers_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetTenderManufacturers.DisplayLayout;
            UltraGridBand band = layout.Bands[0];

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["ManufacturerSupport"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["ManufacturerSupport"].VertScrollBar = true;
            ManufacturerParameters pmtManufacturer = new ManufacturerParameters();
            IList<Manufacturer> lstManufacturers = this.srvManufacturer.GetListByParameters(pmtManufacturer);

            WindowsFormsUtil.SetUltraGridValueList<Manufacturer>(layout, lstManufacturers,
                band.Columns["ManufacturerId"], "ManufacturerId", "Name");
        }

        private void grdDetTenderManufacturers_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            e.Cell.Row.PerformAutoSize();

            if (e.Cell.Column.Key == "ManufacturerId" && Convert.ToInt32(e.NewValue) != -1)
            {
                if (this.dtTenderManufacturers.AsEnumerable().SingleOrDefault(x =>
                    Convert.ToInt32(x["ManufacturerId"]) == Convert.ToInt32(e.NewValue)) != null)
                {
                    e.Cancel = true;
                    MessageBox.Show("Ya se encuentra ese Fabricante en esta Licitación!", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ubtnDetCreateManufacturer_Click(object sender, EventArgs e)
        {
            DataRow newRow = this.dtTenderManufacturers.NewRow();
            this.dtTenderManufacturers.Rows.Add(newRow);
            newRow["ManufacturerId"] = -1;
            this.dtTenderManufacturers.AcceptChanges();
        }

        private void ubtnDetDeleteManufacturer_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderManufacturers.ActiveRow;

            if (activeRow == null) return;
                        
            if (activeRow.Cells["ManufacturerId"].Value != DBNull.Value &&
                Convert.ToInt32(activeRow.Cells["ManufacturerId"].Value) > 0)
            {
                int manufacturerId = Convert.ToInt32(activeRow.Cells["ManufacturerId"].Value);

                if (this.dtTenderLines.AsEnumerable()
                    .Count(x => Convert.ToInt32(x["ManufacturerId"]) == manufacturerId) > 0)
                {
                    MessageBox.Show(
                        "No puede borrar el registro debido a que existen Partidas con ese Fabricante.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            this.dtTenderManufacturers.Rows.Remove(((DataRowView)activeRow.ListObject).Row);
        }

        private void ubtnDetCreateLine_Click(object sender, EventArgs e)
        {
            this.grdTenderLines_InitializeLayout(null, null);
            DataRow newRow = this.dtTenderLines.NewRow();
            this.dtTenderLines.Rows.Add(newRow);
            newRow["ManufacturerId"] = -1;
            newRow["TenderLineId"] = -1;
            this.dtTenderLines.AcceptChanges();
            this.UpdatePriceComparisonGrid();
        }

        private void ubtnDetDeleteLine_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderLines.ActiveRow;

            if (activeRow == null) return;

            this.dtTenderLines.Rows.Remove(((DataRowView)activeRow.ListObject).Row);

            this.UpdatePriceComparisonGrid();
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmTender.HiddenDetail(true);
        }

        private void uceSchBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = Convert.ToInt32(this.frmTender.uceSchBidder.Value);
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTender.uceSchDependency,
                lstDependencies, "DependencyId", "Name");
        }

        private void uceDetBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = Convert.ToInt32(this.frmTender.uceDetBidder.Value);
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTender.uceDetDependency,
                lstDependencies, "DependencyId", "Name");
        }

        private void uceSchDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = Convert.ToInt32(this.frmTender.uceSchDependency.Value);
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTender.uceSchEndUser,
                lstEndUsers, "EndUserId", "Name");
        }
        
        private void uceDetDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = Convert.ToInt32(this.frmTender.uceDetDependency.Value);
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTender.uceDetEndUser,
                lstEndUsers, "EndUserId", "Name");
        }

        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditTender(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void ubtnDetDeleteLog_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetLog.ActiveRow;

            if (activeRow == null) return;

            this.dtTenderLog.Rows.Remove(((DataRowView)activeRow.ListObject).Row);
        }

        private void ubtnDetCreateLog_Click(object sender, EventArgs e)
        {
            DataRow newRow = this.dtTenderLog.NewRow();
            this.dtTenderLog.Rows.Add(newRow);
            newRow["LogDate"] = DateTime.Now;
            this.dtTenderLog.AcceptChanges();
        }

        private void grdDetLog_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetLog.DisplayLayout;
            UltraGridBand band = layout.Bands[0];

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.DefaultRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFree;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;
            band.Columns["TenderLogId"].CellActivation = Activation.ActivateOnly;
            band.Columns["LogDate"].CellActivation = Activation.ActivateOnly;
        }

        private void grdDetLog_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            e.Cell.Row.PerformAutoSize();
        }

        public void grdDetTenderCompetitors_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetTenderCompetitors.DisplayLayout;
            UltraGridBand band = layout.Bands[0];
            CompetitorParameters pmtCompetitor = new CompetitorParameters();
            IList<Competitor> lstCompetitors = this.srvCompetitor.GetListByParameters(pmtCompetitor);

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["TenderCompetitorId"].CellActivation = Activation.ActivateOnly;
            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;

            WindowsFormsUtil.SetUltraGridValueList<Competitor>(layout,
                lstCompetitors, band.Columns["CompetitorId"], "CompetitorId", "Name");
        }

        public void grdDetTenderCompetitors_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            e.Cell.Row.PerformAutoSize();

            if (e.Cell.Column.Key == "CompetitorId" && Convert.ToInt32(e.NewValue) != -1)
            {
                if (this.dtTenderCompetitors.AsEnumerable().SingleOrDefault(x =>
                    Convert.ToInt32(x["CompetitorId"]) == Convert.ToInt32(e.NewValue)) != null)
                {
                    e.Cancel = true;
                    MessageBox.Show("Ya se encuentra esa Competencia en esta Licitación!", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void grdDetTenderWholesalers_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetTenderWholesalers.DisplayLayout;
            UltraGridBand band = layout.Bands[0];
            WholesalerParameters pmtWholesaler = new WholesalerParameters();
            IList<Wholesaler> lstWholesalers = this.srvWholesaler.GetListByParameters(pmtWholesaler);

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["TenderWholesalerId"].CellActivation = Activation.ActivateOnly;
            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;

            WindowsFormsUtil.SetUltraGridValueList<Wholesaler>(layout,
                lstWholesalers, band.Columns["WholesalerId"], "WholesalerId", "Name");
        }

        public void grdDetTenderWholesalers_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            e.Cell.Row.PerformAutoSize();

            if (e.Cell.Column.Key == "WholesalerId" && Convert.ToInt32(e.NewValue) != -1)
            {
                if (this.dtTenderWholesalers.AsEnumerable().SingleOrDefault(x =>
                    Convert.ToInt32(x["WholesalerId"]) == Convert.ToInt32(e.NewValue)) != null)
                {
                    e.Cancel = true;
                    MessageBox.Show("Ya se encuentra esa Competencia en esta Licitación!", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void grdDetTenderWholesalers_AfterCellUpdate(object sender, EventArgs e)
        {
            this.UpdatePriceComparisonGrid();
        }

        private void ubtnDetDeleteCompetitor_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderCompetitors.ActiveRow;

            if (activeRow == null) return;

            this.dtTenderCompetitors.Rows.Remove(((DataRowView)activeRow.ListObject).Row);
        }

        private void ubtnDetCreateCompetitor_Click(object sender, EventArgs e)
        {
            DataRow newRow = this.dtTenderCompetitors.NewRow();
            this.dtTenderCompetitors.Rows.Add(newRow);
            newRow["CompetitorId"] = -1;
            this.dtTenderCompetitors.AcceptChanges();
        }

        private void ubtnDetDeleteWholesaler_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderWholesalers.ActiveRow;

            if (activeRow == null) return;

            this.dtTenderWholesalers.Rows.Remove(((DataRowView)activeRow.ListObject).Row);

            this.UpdatePriceComparisonGrid();
        }

        private void ubtnDetCreateWholesaler_Click(object sender, EventArgs e)
        {
            DataRow newRow = this.dtTenderWholesalers.NewRow();
            this.dtTenderWholesalers.Rows.Add(newRow);
            newRow["WholesalerId"] = -1;
            this.dtTenderWholesalers.AcceptChanges();
        }

        private void grdDetPriceComparison_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetPriceComparison.DisplayLayout;
            UltraGridBand band = layout.Bands[0];
            int columnName;

            band.Columns["TenderLineId"].Hidden = true;
            band.Columns["TenderLineName"].CellActivation = Activation.ActivateOnly;
            band.Columns["TenderLineName"].Header.Caption = "Partida";
            band.Columns["SelectedWholesalerId"].Header.Caption = "Elegido";
            band.Columns["BestPrice"].Header.Caption = "Mejor Precio";
            band.Columns["BestPrice"].CellActivation = Activation.ActivateOnly;

            WholesalerParameters pmtWholesaler = new WholesalerParameters();
            IList<Wholesaler> lstWholesalers = this.srvWholesaler.GetListByParameters(pmtWholesaler);

            WindowsFormsUtil.SetUltraGridValueList<Wholesaler>(layout, lstWholesalers
                .Where(x => this.tender.TenderWholesalers.Where(y => x.Activated && !y.Deleted)
                .Select(y => y.Wholesaler.WholesalerId).Contains(x.WholesalerId)),
                band.Columns["SelectedWholesalerId"], "WholesalerId", "Name");

            foreach (DataColumn col in this.dtPriceComparison.Columns.Cast<DataColumn>()
                .Where(x => int.TryParse(x.ColumnName, out columnName)))
            {
                band.Columns[col.ColumnName].Header.Caption 
                    = this.GetWholesaler(Convert.ToInt32(col.ColumnName)).Name;
            }

            band.Columns["SelectedWholesalerId"].Editor.SelectionChanged
                += new EventHandler(SelectedWholesalerEditor_SelectionChanged);
        }

        private void grdDetPriceComparison_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            int columnName;

            if (Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value) > 0 &&
                int.TryParse(e.Cell.Column.Key, out columnName))
            {
                TenderLineWholesaler tenderLineWholesaler = this.tender.TenderLines.SelectMany(x => x.TenderLineWholesalers)
                    .SingleOrDefault(x => x.TenderLine.TenderLineId == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value)
                    && x.Wholesaler.WholesalerId.ToString() == e.Cell.Column.Key);

                if (tenderLineWholesaler == null)
                {
                    tenderLineWholesaler = new TenderLineWholesaler();
                    TenderLine tenderLine = this.tender.TenderLines
                        .Single(x => x.TenderLineId == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value));
                    tenderLine.TenderLineWholesalers.Add(tenderLineWholesaler);
                    tenderLineWholesaler.TenderLine = tenderLine;
                    tenderLineWholesaler.Wholesaler = this.GetWholesaler(Convert.ToInt32(e.Cell.Column.Key));
                    tenderLineWholesaler.Activated = true;
                    tenderLineWholesaler.Deleted = false;
                }

                tenderLineWholesaler.Price = e.NewValue.ToString().Trim() == string.Empty ?
                    null : (Nullable<Decimal>)Convert.ToDecimal(e.NewValue);
            }

            if (e.Cell.Column.Key == "SelectedWholesalerId")
            {
                this.tender.TenderLines.Single(x => x.TenderLineId == 
                    Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value)).Wholesaler
                    = this.GetWholesaler(Convert.ToInt32(e.NewValue));
            }
        }

        public void grdDetPreresults_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        public void grdDetPreresults_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            TenderLineManufacturer tenderLineManufacturer = this.tender.TenderLines.SelectMany(x => x.TenderLineManufacturers)
                .SingleOrDefault(x => x.TenderLine.TenderLineId == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value)
                && x.TenderLine.Manufacturer.ManufacturerId.ToString() == e.Cell.Column.Key);

            if (tenderLineManufacturer == null)
            {
                tenderLineManufacturer = new TenderLineManufacturer();
                TenderLine tenderLine = this.tender.TenderLines
                    .Single(x => x.TenderLineId == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value));
                tenderLine.TenderLineManufacturers.Add(tenderLineManufacturer);
                tenderLineManufacturer.TenderLine = tenderLine;
                tenderLineManufacturer.Manufacturer = this.GetManufacturer(Convert.ToInt32(e.Cell.Column.Key));
            }

            tenderLineManufacturer.Price = e.NewValue.ToString().Trim() == string.Empty ?
                null : (Nullable<Decimal>)Convert.ToDecimal(e.NewValue);
        }

        public void SelectedWholesalerEditor_SelectionChanged(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetPriceComparison.ActiveRow;

            if (activeRow == null)
                return;

            EditorWithCombo editor = sender as EditorWithCombo;

            activeRow.Cells["BestPrice"].Value = activeRow.Cells[editor.Value.ToString()].Value;
        }

        #endregion Events
    }
}
