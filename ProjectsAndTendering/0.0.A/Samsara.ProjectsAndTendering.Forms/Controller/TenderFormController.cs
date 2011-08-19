
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

        private int priceComparisonExtraColumnsLength;
        private int tenderLineIndexer;

        private Tender tender;
        private TenderForm frmTender;
        private Currency defaultCurrency;
        private TabPage hiddenTenderDetailTab;

        private IBidderService srvBidder;
        private IAsesorService srvAsesor;
        private ITenderService srvTender;
        private IEndUserService srvEndUser;
        private ITenderLogService srvTenderLog;
        private ICurrencyService srvCurrency;
        private ICompetitorService srvCompetitor;
        private IWholesalerService srvWholesaler;
        private ITenderLineService srvTenderLine;
        private IDependencyService srvDependency;
        private ITenderStatusService srvTenderStatus;
        private IManufacturerService srvManufacturer;
        private IPricingStrategyService srvPricingStrategy;
        private ITenderCompetitorService srvTenderCompetitor;
        private ITenderWholesalerService srvTenderWholesaler;
        private ITenderManufacturerService srvTenderManufacturer;
        private ITenderExchangeRateService srvTenderExchangeRate;

        private DataTable dtTenderLog;
        private DataTable dtPreresults;
        private DataTable dtTenderLines;
        private DataTable dtPriceComparison;
        private DataTable dtPricingStrategy;
        private DataTable dtTenderCompetitors;
        private DataTable dtTenderWholesalers;
        private DataTable dtTenderManufacturers;
        private DataTable dtTenderExchangeRates;
        
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
            this.srvCurrency = SamsaraAppContext.Resolve<ICurrencyService>();
            Assert.IsNotNull(this.srvWholesaler);
            this.srvTenderExchangeRate = SamsaraAppContext.Resolve<ITenderExchangeRateService>();
            Assert.IsNotNull(this.srvTenderExchangeRate);
            this.srvPricingStrategy = SamsaraAppContext.Resolve<IPricingStrategyService>();
            Assert.IsNotNull(this.srvPricingStrategy);

            CurrencyParameters pmtCurrency = new CurrencyParameters();
            pmtCurrency.IsDefault = true;
            this.defaultCurrency = this.srvCurrency.GetByParameters(pmtCurrency);

            if (this.defaultCurrency == null)
            {
                MessageBox.Show("No existe una moneda default, favor de configurar una en el catálogo.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTender.Close();
            }

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
            this.frmTender.grdDetTenderLines.AfterCellUpdate 
                += new CellEventHandler(grdDetTenderLines_AfterCellUpdate);
            TenderLineParameters pmtTenderLine = new TenderLineParameters();
            pmtTenderLine.TenderId = ParameterConstants.IntNone;
            this.dtTenderLines = this.srvTenderLine.SearchByParameters(pmtTenderLine);
            this.frmTender.grdDetTenderLines.DataSource = null;
            this.frmTender.grdDetTenderLines.DataSource = dtTenderLines;

            //grdDetTenderCompetitors
            this.frmTender.grdDetExchangeRates.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetExchangeRates_InitializeLayout);
            this.frmTender.grdDetExchangeRates.BeforeCellUpdate +=
                new BeforeCellUpdateEventHandler(grdDetExchangeRates_BeforeCellUpdate);
            TenderExchangeRateParameters pmtTenderExchangeRate = new TenderExchangeRateParameters();
            pmtTenderExchangeRate.TenderId = ParameterConstants.IntNone;
            this.dtTenderExchangeRates = this.srvTenderExchangeRate.CustomSearchByParameters(
                "TenderExchangeRate.SearchByParameters", pmtTenderExchangeRate, true);
            this.frmTender.grdDetExchangeRates.DataSource = null;
            this.frmTender.grdDetExchangeRates.DataSource = dtTenderExchangeRates;

            //grdDetTenderCompetitors
            this.frmTender.grdDetTenderCompetitors.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderCompetitors_InitializeLayout);
            this.frmTender.grdDetTenderCompetitors.AfterCellUpdate 
                += new CellEventHandler(grdDetTenderCompetitors_AfterCellUpdate);
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
            this.frmTender.grdDetTenderManufacturers.AfterCellUpdate 
                += new CellEventHandler(grdDetTenderManufacturers_AfterCellUpdate);
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
            this.frmTender.grdDetPriceComparison.ClickCellButton
                += new CellEventHandler(grdDetPriceComparison_ClickCellButton);
            this.frmTender.grdDetPriceComparison.AfterCellUpdate +=
                new CellEventHandler(grdDetPriceComparison_AfterCellUpdate);

            //grdDetPricingStrategy
            this.frmTender.grdDetPricingStrategy.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetPricingStrategy_InitializeLayout);
            PricingStrategyParameters pmtPricingStrategy = new PricingStrategyParameters();
            this.dtPricingStrategy = this.srvPricingStrategy.SearchByParameters(pmtPricingStrategy);
            this.dtPricingStrategy.Columns.Add(new DataColumn("TenderLineName", typeof(string)));
            this.frmTender.grdDetPricingStrategy.DataSource = null;
            this.frmTender.grdDetPricingStrategy.DataSource = dtPricingStrategy;

            //grdDetPreresults
            this.frmTender.grdDetPreresults.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetPreresults_InitializeLayout);
            this.frmTender.grdDetPreresults.BeforeCellUpdate +=
                new BeforeCellUpdateEventHandler(grdDetPreresults_BeforeCellUpdate);

            //grdDetLog
            this.frmTender.grdDetLog.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetLog_InitializeLayout);
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
            this.LoadPricingEstrategy();
            this.LoadTenderWholesalers();
            this.LoadTenderCompetitors();
            this.LoadTenderLogs();
            this.LoadTenderExchangeRates();

            this.tender.Activated = true;
            this.tender.Deleted = false;
        }

        private void LoadPricingEstrategy()
        {
            foreach (DataRow row in this.dtPricingStrategy.AsEnumerable())
            {
                TenderLine tenderLine = this.tender.TenderLines
                    .Single(x => x.TenderLineId == Convert.ToInt32((row["TenderLineId"])));
                PricingStrategy pricingStrategy = tenderLine.PricingStrategy;

                if (pricingStrategy == null)
                {
                    pricingStrategy = new PricingStrategy();
                    tenderLine.PricingStrategy = pricingStrategy;
                }

                pricingStrategy.TenderLine = tenderLine;
                pricingStrategy.ProfitMargin = Convert.ToDecimal(row["ProfitMargin"]);
                pricingStrategy.SelectedPrice = Convert.ToDecimal(row["SelectedPrice"]);
                pricingStrategy.TenderLineProfit = Convert.ToDecimal(row["TenderLineProfit"]);
                pricingStrategy.TotalPriceAfterTax = Convert.ToDecimal(row["TotalPriceAfterTax"]);
                pricingStrategy.TotalPriceBeforeTax = Convert.ToDecimal(row["TotalPriceBeforeTax"]);
                pricingStrategy.UnitPriceAfterTax = Convert.ToDecimal(row["UnitPriceAfterTax"]);
                pricingStrategy.UnitPriceBeforeTax = Convert.ToDecimal(row["UnitPriceBeforeTax"]);
                pricingStrategy.UnitProfit = Convert.ToDecimal(row["UnitProfit"]);

                if (row["ManufacturerId"] != DBNull.Value)
                    pricingStrategy.Manufacturer = this.GetManufacturer(Convert.ToInt32((row["ManufacturerId"])));
                else
                    pricingStrategy.Manufacturer = null;

                if (row["WholesalerId"] != DBNull.Value)
                    pricingStrategy.Wholesaler = this.GetWholesaler(Convert.ToInt32((row["WholesalerId"])));
                else
                    pricingStrategy.Wholesaler = null;
            }
        }

        private void LoadTenderExchangeRates()
        {
            foreach (DataRow row in this.dtTenderExchangeRates.Rows)
            {
                TenderExchangeRate tenderExchangeRate = this.tender.TenderExchangeRates
                    .SingleOrDefault(x => x.SourceCurrency.CurrencyId == Convert.ToInt32(row["SourceCurrency.CurrencyId"])
                    && x.DestinyCurrency.CurrencyId == Convert.ToInt32(row["DestinyCurrency.CurrencyId"]));

                if (tenderExchangeRate == null)
                {
                    tenderExchangeRate = new TenderExchangeRate();
                    this.tender.TenderExchangeRates.Add(tenderExchangeRate);
                }

                tenderExchangeRate.Activated = true;
                tenderExchangeRate.Deleted = false;
                tenderExchangeRate.ExchangeRate = null;
                tenderExchangeRate.Rate = Convert.ToDecimal(row["Rate"]);
                tenderExchangeRate.DestinyCurrency = this.GetCurrency(Convert.ToInt32(row["DestinyCurrency.CurrencyId"]));
                tenderExchangeRate.SourceCurrency = this.GetCurrency(Convert.ToInt32(row["SourceCurrency.CurrencyId"]));
                tenderExchangeRate.Tender = this.tender;
            }

            IEnumerable<int> ieCurrencies = this.tender.TenderLines.SelectMany(x => x.TenderLineWholesalers)
                .Select(x => x.Currency.CurrencyId);

            foreach (TenderExchangeRate tenderExchangeRate in this.tender.TenderExchangeRates)
            {
                if (!ieCurrencies.Contains(tenderExchangeRate.SourceCurrency.CurrencyId))
                {
                    tenderExchangeRate.Deleted = true;
                    tenderExchangeRate.Activated = false;
                }
            }
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
                    tenderLine.TenderLineId = Convert.ToInt32(row["TenderLineId"]);
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
            this.dtPricingStrategy.Rows.Clear();
            this.frmTender.grdDetPriceComparison.DataSource = null;
            this.dtTenderExchangeRates.Clear();
            this.tenderLineIndexer = -1;
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

            foreach (TenderLog tenderLog in this.tender.TenderLogs.OrderByDescending(x => x.LogDate))
            {
                DataRow row = this.dtTenderLog.NewRow();
                this.dtTenderLog.Rows.Add(row);

                row["Description"] = tenderLog.Description;
                row["LogDate"] = tenderLog.LogDate;
                row["TenderLogId"] = tenderLog.TenderLogId;
                row["TenderId"] = tenderLog.Tender.TenderId;
            }

            foreach (TenderExchangeRate tenderExchangeRate in this.tender.TenderExchangeRates)
            {
                DataRow row = this.dtTenderExchangeRates.NewRow();
                this.dtTenderExchangeRates.Rows.Add(row);

                row["SourceCurrency.CurrencyId"] = tenderExchangeRate.SourceCurrency.CurrencyId;
                row["DestinyCurrency.CurrencyId"] = tenderExchangeRate.DestinyCurrency.CurrencyId;
                row["Rate"] = tenderExchangeRate.Rate;
            }

            this.UpdatePricingStrategyGrid();
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
            bool createdFlag = false;
            int intColumnName;

            if (this.dtPriceComparison == null)
            {
                this.dtPriceComparison = new DataTable();
                createdFlag = true;
                priceComparisonExtraColumnsLength = 0;
            }

            if (!this.dtPriceComparison.Columns.Contains("TenderLineId"))
            {
                DataColumn dc = new DataColumn("TenderLineId", typeof(int));
                this.dtPriceComparison.Columns.Add(dc);
            }

            if (!this.dtPriceComparison.Columns.Contains("TenderLineName"))
            {
                DataColumn dc = new DataColumn("TenderLineName", typeof(string));
                this.dtPriceComparison.Columns.Add(dc);
            }

            if (!this.dtPriceComparison.Columns.Contains("SelectedWholesalerId"))
            {
                DataColumn dc = new DataColumn("SelectedWholesalerId", typeof(int));
                this.dtPriceComparison.Columns.Add(dc);
                if (createdFlag)
                    priceComparisonExtraColumnsLength++;
            }

            if (!this.dtPriceComparison.Columns.Contains("SelectBestChoise"))
            {
                DataColumn dc = new DataColumn("SelectBestChoise", typeof(string));
                this.dtPriceComparison.Columns.Add(dc);
                if (createdFlag)
                    priceComparisonExtraColumnsLength++;
            }

            if (!this.dtPriceComparison.Columns.Contains("BestPrice"))
            {
                DataColumn dc = new DataColumn("BestPrice", typeof(decimal));
                this.dtPriceComparison.Columns.Add(dc);
                if (createdFlag)
                    priceComparisonExtraColumnsLength++;
            }

            if (!this.dtPriceComparison.Columns.Contains("BestPriceCurrencyId"))
            {
                DataColumn dc = new DataColumn("BestPriceCurrencyId", typeof(int));
                this.dtPriceComparison.Columns.Add(dc);
                if (createdFlag)
                    priceComparisonExtraColumnsLength++;
            }

            foreach (int wholesalerId in this.dtTenderWholesalers.AsEnumerable()
                .Select(x => Convert.ToInt32(x["WholesalerId"])))
            {
                if (!this.dtPriceComparison.Columns.Contains(wholesalerId.ToString()))
                {
                    DataColumn dcWholesaler = new DataColumn(wholesalerId.ToString(), typeof(decimal));
                    this.dtPriceComparison.Columns.Add(dcWholesaler);
                    this.dtPriceComparison.Columns[wholesalerId.ToString()]
                        .SetOrdinal(this.dtPriceComparison.Columns.Count - priceComparisonExtraColumnsLength - 1);
                    DataColumn dcWholesalerCurrency = new DataColumn(wholesalerId.ToString() + "C", typeof(int));
                    this.dtPriceComparison.Columns.Add(dcWholesalerCurrency);
                    this.dtPriceComparison.Columns[wholesalerId.ToString() + "C"]
                        .SetOrdinal(this.dtPriceComparison.Columns.Count - priceComparisonExtraColumnsLength - 1);
                }
            }

            IEnumerable<string> columnNames = this.dtPriceComparison.Copy().Columns
                .Cast<DataColumn>().Select(x => x.ColumnName);

            foreach (string strColumnName in columnNames.Where(x => int.TryParse(x, out intColumnName)))
            {
                if (!this.dtTenderWholesalers.AsEnumerable()
                    .Select(x => x["WholesalerId"].ToString()).Contains(strColumnName))
                {
                    foreach (TenderLineWholesaler tenderLineWholesaler in
                        this.tender.TenderLines.SelectMany(x => x.TenderLineWholesalers)
                        .Where(x => x.Wholesaler.WholesalerId == Convert.ToInt32(strColumnName)))
                    {
                        tenderLineWholesaler.Activated = false;
                        tenderLineWholesaler.Deleted = true;
                    }
                    this.dtPriceComparison.Columns.Remove(strColumnName);
                    this.dtPriceComparison.Columns.Remove(strColumnName + "C");
                }
            }

            foreach (DataRow row in this.dtTenderLines.AsEnumerable())
            {
                if (Convert.ToInt32(row["TenderLineId"]) > 0 && !this.dtPriceComparison.Rows.Cast<DataRow>()
                    .Select(x => x["TenderLineId"].ToString()).Contains(row["TenderLineId"].ToString()))
                {
                    DataRow rowPC = this.dtPriceComparison.NewRow();
                    rowPC["TenderLineId"] = row["TenderLineId"];
                    rowPC["BestPriceCurrencyId"] = this.defaultCurrency.CurrencyId;
                    rowPC["SelectedWholesalerId"] = -1;
                    rowPC["TenderLineName"] = row["Name"];
                    rowPC["SelectBestChoise"] = "Seleccionar";
                    this.dtPriceComparison.Rows.Add(rowPC);
                }
            }

            foreach (DataRow row in this.dtPriceComparison.AsEnumerable())
            {
                foreach (DataColumn column in this.dtPriceComparison.Columns.Cast<DataColumn>()
                    .Where(x => x.ColumnName.EndsWith("C")))
                {
                    if (row[column.ColumnName] == DBNull.Value)
                        row[column.ColumnName] = this.defaultCurrency.CurrencyId;
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
                {
                    if (tenderLineWholesaler.Price != null)
                        row[tenderLineWholesaler.Wholesaler.WholesalerId.ToString()] = tenderLineWholesaler.Price;
                    else
                        row[tenderLineWholesaler.Wholesaler.WholesalerId.ToString()] = DBNull.Value;

                    if (tenderLineWholesaler.Currency != null)
                        row[tenderLineWholesaler.Wholesaler.WholesalerId.ToString() + "C"] = tenderLineWholesaler.Currency.CurrencyId;
                    else
                        row[tenderLineWholesaler.Wholesaler.WholesalerId.ToString() + "C"] = this.defaultCurrency.CurrencyId;
                }
            }

            foreach (TenderLine tenderLine in this.tender.TenderLines)
            {
                if (tenderLine.Wholesaler != null)
                {
                    DataRow row = this.dtPriceComparison.AsEnumerable().SingleOrDefault(x =>
                        Convert.ToInt32(x["TenderLineId"]) == tenderLine.TenderLineId);
                    TenderLineWholesaler tenderLineWholesaler = tenderLine.TenderLineWholesalers
                        .SingleOrDefault(x => x.Wholesaler.WholesalerId == tenderLine.Wholesaler.WholesalerId);

                    if (tenderLineWholesaler != null && tenderLineWholesaler.Price != null)
                        row["BestPrice"] = tenderLineWholesaler.Price;
                    else
                        row["BestPrice"] = DBNull.Value;

                    row["SelectedWholesalerId"] = tenderLine.Wholesaler.WholesalerId;
                }
            }

            this.dtPriceComparison.AcceptChanges();

            this.frmTender.grdDetPriceComparison.DataSource = null;
            this.frmTender.grdDetPriceComparison.DataSource = dtPriceComparison;
        }

        private void UpdatePricingStrategyGrid()
        {
            foreach (TenderLine tenderLine in this.tender.TenderLines)
            {
                PricingStrategy pricingStrategy = tenderLine.PricingStrategy;

                if (pricingStrategy == null)
                {
                    pricingStrategy = new PricingStrategy();
                    tenderLine.PricingStrategy = pricingStrategy;

                    pricingStrategy.ProfitMargin = 5;
                }

                if (tenderLine.Wholesaler != null)
                    pricingStrategy.SelectedPrice = tenderLine.TenderLineWholesalers
                        .Single(x => x.Wholesaler.WholesalerId
                            == tenderLine.Wholesaler.WholesalerId).Price.Value;
                else
                    pricingStrategy.SelectedPrice = 0.00M;
                pricingStrategy.TenderLine = tenderLine;
                pricingStrategy.UnitPriceBeforeTax = pricingStrategy.SelectedPrice
                    / (1 - pricingStrategy.ProfitMargin / 100M);
                pricingStrategy.UnitProfit = pricingStrategy.UnitPriceBeforeTax
                    - pricingStrategy.SelectedPrice;
                pricingStrategy.TenderLineProfit = pricingStrategy.TenderLineProfit
                    * tenderLine.Quantity;
                pricingStrategy.UnitPriceAfterTax = pricingStrategy.UnitPriceBeforeTax
                    * TaxesUtil.GetTaxPercent(TaxEnum.IVA);
                pricingStrategy.TotalPriceBeforeTax = pricingStrategy.UnitPriceBeforeTax
                    * tenderLine.Quantity;
                pricingStrategy.TotalPriceAfterTax = pricingStrategy.UnitPriceAfterTax
                    * TaxesUtil.GetTaxPercent(TaxEnum.IVA);
                if (tenderLine.Wholesaler != null)
                    pricingStrategy.Wholesaler = tenderLine.Wholesaler;

                DataRow row = this.dtPricingStrategy.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["TenderLineId"]) == tenderLine.TenderLineId);

                if (row == null)
                {
                    row = this.dtPricingStrategy.NewRow();
                    this.dtPricingStrategy.Rows.Add(row);
                    row["TenderLineId"] = pricingStrategy.TenderLine.TenderLineId;
                }

                row["TenderLineName"] = tenderLine.Name;
                row["ProfitMargin"] = pricingStrategy.ProfitMargin;
                row["SelectedPrice"] = pricingStrategy.SelectedPrice;
                row["TenderLineProfit"] = pricingStrategy.TenderLineProfit;
                row["PricingStrategyId"] = pricingStrategy.PricingStrategyId;
                row["TotalPriceAfterTax"] = pricingStrategy.TotalPriceAfterTax;
                row["TotalPriceBeforeTax"] = pricingStrategy.TotalPriceBeforeTax;
                row["UnitPriceAfterTax"] = pricingStrategy.UnitPriceAfterTax;
                row["UnitPriceBeforeTax"] = pricingStrategy.UnitPriceBeforeTax;
                row["UnitProfit"] = pricingStrategy.UnitProfit;
                if (tenderLine.Wholesaler != null)
                {
                    if (pricingStrategy.Wholesaler != null)
                        row["WholesalerId"] = pricingStrategy.Wholesaler.WholesalerId;
                    else
                        row["WholesalerId"] = -1;

                    row["ManufacturerId"] = DBNull.Value;
                }
                else
                {
                    if (pricingStrategy.Manufacturer != null)
                        row["ManufacturerId"] = pricingStrategy.Manufacturer.ManufacturerId;
                    else
                        row["ManufacturerId"] = -1;

                    row["WholesalerId"] = DBNull.Value;
                }
            }
            this.dtPricingStrategy.AcceptChanges();

            foreach (UltraGridRow row in this.frmTender.grdDetPricingStrategy.Rows)
            {
                if (row.Cells["WholesalerId"].Value == DBNull.Value)
                    row.Cells["WholesalerId"].Activation = Activation.ActivateOnly;
                else
                    row.Cells["WholesalerId"].Activation = Activation.AllowEdit;

                if (row.Cells["ManufacturerId"].Value == DBNull.Value)
                    row.Cells["ManufacturerId"].Activation = Activation.ActivateOnly;
                else
                    row.Cells["ManufacturerId"].Activation = Activation.AllowEdit;
            }
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

        private Currency GetCurrency(int currencyId)
        {
            if (this.defaultCurrency.CurrencyId == currencyId)
                return defaultCurrency;

            return this.srvCurrency.GetById(currencyId);
        }

        private decimal GetExchangeRate(int sourceCurrencyId)
        {
            if (sourceCurrencyId == this.defaultCurrency.CurrencyId)
                return 1;
            else
                return Convert.ToDecimal(this.dtTenderExchangeRates.AsEnumerable().Single(x => 
                    Convert.ToInt32(x["SourceCurrency.CurrencyId"]) == sourceCurrencyId
                    && Convert.ToInt32(x["DestinyCurrency.CurrencyId"]) == this.defaultCurrency.CurrencyId)
                    ["Rate"]);
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
                availableManufacturers, band.Columns["ManufacturerId"], "ManufacturerId", "Name", "Seleccione");
        }

        private void grdDetTenderLines_AfterCellUpdate(object sender, EventArgs e)
        {
            UltraGridCell activeCell = this.frmTender.grdDetTenderLines.ActiveCell;

            if (activeCell == null)
                return;

            activeCell.Row.PerformAutoSize();
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
                band.Columns["ManufacturerId"], "ManufacturerId", "Name", "Seleccione");
        }

        private void grdDetTenderManufacturers_AfterCellUpdate(object sender, EventArgs e)
        {
            UltraGridCell activeCell = this.frmTender.grdDetTenderManufacturers.ActiveCell;

            if (activeCell == null)
                return;

            activeCell.Row.PerformAutoSize();
        }

        private void grdDetTenderManufacturers_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
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
            newRow["TenderLineId"] = this.tenderLineIndexer--;
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
            if (this.frmTender.txtDetLog.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe escribir un momentario para agregarlo a la bitácora.", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataRow newRow = this.dtTenderLog.NewRow();
            this.dtTenderLog.Rows.InsertAt(newRow, 0);
            newRow["Description"] = this.frmTender.txtDetLog.Text;
            newRow["LogDate"] = DateTime.Now;
            this.frmTender.txtDetLog.Text = string.Empty;
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

            this.frmTender.grdDetLog.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;
        }

        private void grdDetLog_AfterCellUpdate(object sender, EventArgs e)
        {
            UltraGridCell activeCell = this.frmTender.grdDetLog.ActiveCell;

            if (activeCell == null)
                return;

            activeCell.Row.PerformAutoSize();
        }

        private void grdDetTenderCompetitors_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
                lstCompetitors, band.Columns["CompetitorId"], "CompetitorId", "Name", "Seleccione");
        }

        private void grdDetTenderCompetitors_AfterCellUpdate(object sender, EventArgs e)
        {
            UltraGridCell activeCell = this.frmTender.grdDetTenderCompetitors.ActiveCell;

            if (activeCell == null)
                return;

            activeCell.Row.PerformAutoSize();
        }

        private void grdDetTenderCompetitors_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
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

        private void grdDetTenderWholesalers_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
                lstWholesalers, band.Columns["WholesalerId"], "WholesalerId", "Name", "Seleccione");
        }

        private void grdDetTenderWholesalers_AfterCellUpdate(object sender, EventArgs e)
        {
            this.UpdatePriceComparisonGrid();

            UltraGridCell activeCell = this.frmTender.grdDetTenderWholesalers.ActiveCell;

            if (activeCell == null)
                return;

            activeCell.Row.PerformAutoSize();
        }

        private void grdDetTenderWholesalers_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
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
            band.Columns["SelectedWholesalerId"].Header.Caption = "Seleccionado";
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["BestPrice"], 
                WindowsFormsUtil.GridCellFormat.Currency);
            band.Columns["BestPrice"].Header.Caption = "Mejor Precio";
            band.Columns["BestPrice"].CellActivation = Activation.ActivateOnly;
            band.Columns["SelectBestChoise"].Header.Caption = "Mejor Opción";
            band.Columns["SelectBestChoise"].Style = 
                Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            band.Columns["SelectBestChoise"].ButtonDisplayStyle = 
                Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            band.Columns["BestPriceCurrencyId"].CellActivation = Activation.ActivateOnly;
            band.Columns["BestPriceCurrencyId"].Header.Caption = "Moneda";
            
            CurrencyParameters pmtCurrency = new CurrencyParameters();
            IList<Currency> lstCurrencies = this.srvCurrency.GetListByParameters(pmtCurrency);

            foreach (UltraGridColumn column in band.Columns.Cast<UltraGridColumn>()
                .Where(x => x.Key.EndsWith("C") || x.Key == "BestPriceCurrencyId"))
            {
                WindowsFormsUtil.SetUltraGridValueList<Currency>(layout, lstCurrencies,
                        column, "CurrencyId", "Code", null);
                column.Editor.SelectionChanged
                    += new EventHandler(CurrencyEditor_SelectionChanged);
            }

            band.Columns["BestPriceCurrencyId"].ButtonDisplayStyle =
                Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;

            WholesalerParameters pmtWholesaler = new WholesalerParameters();
            IEnumerable<Wholesaler> ieWholesalers = this.srvWholesaler.GetListByParameters(pmtWholesaler)
                .Where(x => this.dtTenderWholesalers.AsEnumerable()
                    .Select(y => Convert.ToInt32(y["WholesalerId"]))
                    .Contains(x.WholesalerId));

            WindowsFormsUtil.SetUltraGridValueList<Wholesaler>(layout, ieWholesalers,
                    band.Columns["SelectedWholesalerId"], "WholesalerId", "Name", "[Fabricante]");

            foreach (DataColumn col in this.dtPriceComparison.Columns.Cast<DataColumn>()
                .Where(x => int.TryParse(x.ColumnName, out columnName)))
            {
                band.Columns[col.ColumnName + "C"].Header.Caption = "Moneda";
                WindowsFormsUtil.SetUltraColumnFormat(band.Columns[col.ColumnName],
                    WindowsFormsUtil.GridCellFormat.Currency);
                band.Columns[col.ColumnName].Header.Caption
                    = this.GetWholesaler(Convert.ToInt32(col.ColumnName)).Name;
            }

            foreach (UltraGridRow row in this.frmTender.grdDetPriceComparison.Rows)
            {
                if (!ieWholesalers.Select(x => x.WholesalerId)
                    .Contains(Convert.ToInt32(row.Cells["SelectedWholesalerId"].Value)))
                {
                    row.Cells["SelectedWholesalerId"].Value = -1;
                    row.Cells["BestPrice"].Value = DBNull.Value;
                }
            }

            band.Columns["SelectedWholesalerId"].Editor.SelectionChanged
                += new EventHandler(SelectedWholesalerEditor_SelectionChanged);
        }

        private void grdDetPriceComparison_AfterCellUpdate(object sender, EventArgs e)
        {
            UltraGridCell activeCell = this.frmTender.grdDetPriceComparison.ActiveCell;
            int columnName;

            if (activeCell == null)
                return;

            string strColumnName = activeCell.Column.Key;

            if (activeCell.Column.Key.EndsWith("C"))
                strColumnName = strColumnName.Replace("C", "");

            if ((Convert.ToInt32(activeCell.Row.Cells["TenderLineId"].Value) > 0
                && int.TryParse(activeCell.Column.Key, out columnName) ||
                Convert.ToInt32(activeCell.Row.Cells["TenderLineId"].Value) > 0
                && activeCell.Column.Key.EndsWith("C") )&&
                activeCell.Row.Cells[strColumnName].Column.Key == activeCell.Row.Cells["SelectedWholesalerId"].Value.ToString())
            {
                if (activeCell.Row.Cells[strColumnName].Value == DBNull.Value)
                {
                    activeCell.Row.Cells["BestPrice"].Value = DBNull.Value;
                    activeCell.Row.Cells["SelectedWholesalerId"].Value = -1;
                }
                else
                    activeCell.Row.Cells["BestPrice"].Value = Convert.ToDecimal(activeCell.Row.Cells[strColumnName].Value) *
                        this.GetExchangeRate(Convert.ToInt32(activeCell.Row.Cells[strColumnName + "C"].Value));
            }
        }

        private void grdDetPriceComparison_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            int columnName;

            if (Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value) > 0
                && int.TryParse(e.Cell.Column.Key, out columnName) ||
                Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value) > 0
                && e.Cell.Column.Key.EndsWith("C"))
            {
                string strColumnName = e.Cell.Column.Key;

                if (e.Cell.Column.Key.EndsWith("C"))
                    strColumnName = strColumnName.Replace("C", "");

                TenderLineWholesaler tenderLineWholesaler = this.tender.TenderLines.SelectMany(x => x.TenderLineWholesalers)
                    .SingleOrDefault(x => x.TenderLine.TenderLineId == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value)
                    && x.Wholesaler.WholesalerId.ToString() == strColumnName);

                if (tenderLineWholesaler == null)
                {
                    tenderLineWholesaler = new TenderLineWholesaler();
                    TenderLine tenderLine = this.tender.TenderLines
                        .Single(x => x.TenderLineId == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value));
                    tenderLine.TenderLineWholesalers.Add(tenderLineWholesaler);
                    tenderLineWholesaler.Currency
                        = this.GetCurrency(Convert.ToInt32(e.Cell.Row.Cells[strColumnName + "C"].Value));
                    tenderLineWholesaler.TenderLine = tenderLine;
                    tenderLineWholesaler.Wholesaler = this.GetWholesaler(Convert.ToInt32(strColumnName));
                    tenderLineWholesaler.Activated = true;
                    tenderLineWholesaler.Deleted = false;
                }

                if (e.Cell.Column.Key.EndsWith("C"))
                    tenderLineWholesaler.Currency = this.GetCurrency(Convert.ToInt32(e.NewValue));
                else
                    tenderLineWholesaler.Price = e.NewValue.ToString().Trim() == string.Empty ?
                        null : (Nullable<Decimal>)Convert.ToDecimal(e.NewValue) * 
                        this.GetExchangeRate(Convert.ToInt32(e.Cell.Row.Cells[strColumnName + "C"].Value));
            }

            if (e.Cell.Column.Key == "SelectedWholesalerId")
            {
                this.tender.TenderLines.Single(x => x.TenderLineId == 
                    Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value)).Wholesaler
                    = this.GetWholesaler(Convert.ToInt32(e.NewValue));
            }
        }

        private void grdDetPriceComparison_ClickCellButton(object sender, CellEventArgs e)
        {
            int columnName;

            if (e.Cell.Row.Cells.Cast<UltraGridCell>().Where(x => x.Column.Key.EndsWith("C"))
                .Count(x => Convert.ToInt32(x.Value) == -1) > 0)
            {
                MessageBox.Show("Debe seleccionar todas las monedas para la partida seleccionada.", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UltraGridCell minPriceCell = e.Cell.Row.Cells.Cast<UltraGridCell>()
                .Where(x => x.Value != DBNull.Value && int.TryParse(x.Column.Key, out columnName))
                .OrderBy(x => Convert.ToDecimal(x.Value) * this.GetExchangeRate(
                   Convert.ToInt32(x.Row.Cells[x.Column.Key + "C"].Value))).FirstOrDefault();

            if (minPriceCell != null)
            {
                e.Cell.Row.Cells["BestPrice"].Value = Convert.ToDecimal(minPriceCell.Value) *
                        this.GetExchangeRate(Convert.ToInt32(e.Cell.Row.Cells[minPriceCell.Column.Key + "C"].Value));
                e.Cell.Row.Cells["SelectedWholesalerId"].Value = Convert.ToInt32(minPriceCell.Column.Key);
            }
            else
            {
                e.Cell.Row.Cells["BestPrice"].Value = DBNull.Value;
                e.Cell.Row.Cells["SelectedWholesalerId"].Value = -1;
            }
        }

        private void grdDetPreresults_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void grdDetPreresults_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
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
        
        private void SelectedWholesalerEditor_SelectionChanged(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetPriceComparison.ActiveRow;
            EditorWithCombo editor = sender as EditorWithCombo;

            if (activeRow == null)
                return;
            if (Convert.ToInt32(editor.Value) > 0)
                if (activeRow.Cells[editor.Value.ToString()].Value == DBNull.Value)
                    activeRow.Cells["BestPrice"].Value = DBNull.Value;
                else 
                    activeRow.Cells["BestPrice"].Value = Convert.ToDecimal(activeRow.Cells[editor.Value.ToString()].Value)
                        * this.GetExchangeRate(Convert.ToInt32(activeRow.Cells[editor.Value + "C"].Value));
            else
                activeRow.Cells["BestPrice"].Value = DBNull.Value;
        }

        private void CurrencyEditor_SelectionChanged(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetPriceComparison.ActiveRow;
            EditorWithCombo editor = sender as EditorWithCombo;

            if (activeRow == null)
                return;
            if (Convert.ToInt32(editor.Value) > 0 && Convert.ToInt32(editor.Value) != this.defaultCurrency.CurrencyId)
            {
                DataRow drTenderExchangeRate = this.dtTenderExchangeRates.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["SourceCurrency.CurrencyId"]) == Convert.ToInt32(editor.Value)
                        && Convert.ToInt32(x["DestinyCurrency.CurrencyId"]) == this.defaultCurrency.CurrencyId);
                
                if (drTenderExchangeRate == null)
                {
                    drTenderExchangeRate = this.dtTenderExchangeRates.NewRow();
                    this.dtTenderExchangeRates.Rows.Add(drTenderExchangeRate);

                    drTenderExchangeRate["SourceCurrency.CurrencyId"] = Convert.ToInt32(editor.Value);
                    drTenderExchangeRate["DestinyCurrency.CurrencyId"] = this.defaultCurrency.CurrencyId;
                    drTenderExchangeRate["Rate"] = 0.00;

                    this.dtTenderExchangeRates.AcceptChanges();
                }
            }
        }

        private void grdDetExchangeRates_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetExchangeRates.DisplayLayout;
            UltraGridBand band = layout.Bands[0];

            band.Override.MinRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["DestinyCurrency.CurrencyId"].CellActivation = Activation.ActivateOnly;
            band.Columns["SourceCurrency.CurrencyId"].CellActivation = Activation.ActivateOnly;
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["Rate"], WindowsFormsUtil.GridCellFormat.Rate);
            
            CurrencyParameters pmtCurrency = new CurrencyParameters();
            IList<Currency> lstCurrencies = this.srvCurrency.GetListByParameters(pmtCurrency);

            WindowsFormsUtil.SetUltraGridValueList<Currency>(layout, lstCurrencies,
                    band.Columns["DestinyCurrency.CurrencyId"], "CurrencyId", "Code", "Seleccione");
            WindowsFormsUtil.SetUltraGridValueList<Currency>(layout, lstCurrencies,
                    band.Columns["SourceCurrency.CurrencyId"], "CurrencyId", "Code", "Seleccione");
        }

        private void grdDetExchangeRates_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.NewValue == DBNull.Value || Convert.ToDecimal(e.NewValue) <= 0)
            {
                MessageBox.Show("Debe poner una cantidad correcta en el tipo de cambio.", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        public void grdDetPricingStrategy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetPricingStrategy.DisplayLayout;
            UltraGridBand band = layout.Bands[0];

            this.frmTender.grdDetLog.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            
            WholesalerParameters pmtWholesaler = new WholesalerParameters();
            IEnumerable<Wholesaler> ieWholesalers = this.srvWholesaler.GetListByParameters(pmtWholesaler);
            WindowsFormsUtil.SetUltraGridValueList<Wholesaler>(layout, ieWholesalers, band.Columns["WholesalerId"],
                "WholesalerId", "Name", "Seleccione");
            band.Columns["WholesalerId"].CellActivation = Activation.AllowEdit;

            ManufacturerParameters pmtManufacturer = new ManufacturerParameters();
            IEnumerable<Manufacturer> ieManufacturers = this.srvManufacturer.GetListByParameters(pmtManufacturer);
            WindowsFormsUtil.SetUltraGridValueList<Manufacturer>(layout, ieManufacturers, band.Columns["ManufacturerId"],
                "ManufacturerId", "Name", "Seleccione");
            band.Columns["ManufacturerId"].CellActivation = Activation.AllowEdit;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["ProfitMargin"],
                WindowsFormsUtil.GridCellFormat.NoLimitPercentage);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["SelectedPrice"],
                WindowsFormsUtil.GridCellFormat.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["TenderLineProfit"],
                WindowsFormsUtil.GridCellFormat.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["TotalPriceAfterTax"],
                WindowsFormsUtil.GridCellFormat.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["TotalPriceBeforeTax"],
                WindowsFormsUtil.GridCellFormat.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["TotalPriceBeforeTax"],
                WindowsFormsUtil.GridCellFormat.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["UnitPriceAfterTax"],
                WindowsFormsUtil.GridCellFormat.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["UnitPriceBeforeTax"],
                WindowsFormsUtil.GridCellFormat.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["UnitProfit"],
                WindowsFormsUtil.GridCellFormat.Currency);
        }

        #endregion Events
    }
}
