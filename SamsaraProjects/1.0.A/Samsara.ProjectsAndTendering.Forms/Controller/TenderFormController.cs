﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Controls.EventsHandlers;
using Samsara.Base.Core.Context;
using Samsara.Base.Core.Enums;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Service.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Enums;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class TenderFormController
    {
        #region Attributes

        private int priceComparisonExtraColumnsLength;

        private Tender tender;
        private TenderForm frmTender;
        private Currency defaultCurrency;
        private TabPage hiddenTenderDetailTab;
        private TenderLineCompetitor tenderLineCompetitor;

        private IBidderService srvBidder;
        private IAsesorService srvAsesor;
        private ITenderService srvTender;
        private IEndUserService srvEndUser;
        private ICurrencyService srvCurrency;
        private ITenderLogService srvTenderLog;
        private ICompetitorService srvCompetitor;
        private IWholesalerService srvWholesaler;
        private ITenderLineService srvTenderLine;
        private IDependencyService srvDependency;
        private ITenderFileService srvTenderFile;
        private ITenderStatusService srvTenderStatus;
        private IManufacturerService srvManufacturer;
        private IWarrantyTypeService srvWarrantyType;
        private ITenderWarrantyService srvTenderWarranty;
        private IPricingStrategyService srvPricingStrategy;
        private ITenderCompetitorService srvTenderCompetitor;
        private ITenderWholesalerService srvTenderWholesaler;
        private ITenderManufacturerService srvTenderManufacturer;
        private ITenderLineExtraCostService srvTenderLineExtraCost;
        private ITenderExchangeRateService srvTenderExchangeRate;
        private IDocumentTypeWarrantyService srvDocumentTypeWarranty;

        private DataTable dtTenderLog;
        private DataTable dtPreresults;
        private DataTable dtTenderLines;
        private DataTable dtTenderFiles;
        private DataTable dtPriceComparison;
        private DataTable dtPricingStrategy;
        private DataTable dtTenderWarranties;
        private DataTable dtTenderCompetitors;
        private DataTable dtTenderWholesalers;
        private DataTable dtTenderManufacturers;
        private DataTable dtTenderLineExtraCosts;
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
            this.srvTenderWarranty = SamsaraAppContext.Resolve<ITenderWarrantyService>();
            Assert.IsNotNull(this.srvTenderWarranty);
            this.srvWarrantyType = SamsaraAppContext.Resolve<IWarrantyTypeService>();
            Assert.IsNotNull(this.srvWarrantyType);
            this.srvDocumentTypeWarranty = SamsaraAppContext.Resolve<IDocumentTypeWarrantyService>();
            Assert.IsNotNull(this.srvDocumentTypeWarranty);
            this.srvTenderFile = SamsaraAppContext.Resolve<ITenderFileService>();
            Assert.IsNotNull(this.srvTenderFile);
            this.srvTenderLineExtraCost = SamsaraAppContext.Resolve<ITenderLineExtraCostService>();
            Assert.IsNotNull(this.srvTenderLineExtraCost);

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

            this.frmTender.acSchAsesor.Parameters = pmtAsesor;
            this.frmTender.acSchAsesor.Refresh();

            this.frmTender.acDetAsesor.Parameters = pmtAsesor;
            this.frmTender.acDetAsesor.Refresh();

            // TenderStatus
            TenderStatusParameters pmtTenderStatus = new TenderStatusParameters();

            this.frmTender.tscDetTenderStatus.Parameters = pmtTenderStatus;
            this.frmTender.tscDetTenderStatus.Refresh();
            this.frmTender.tscDetTenderStatus.ReadOnly = true;

            this.frmTender.tscSchTenderStatus.Parameters = pmtTenderStatus;
            this.frmTender.tscSchTenderStatus.Refresh();

            // TenderSubstatus
            TenderSubstatusParameters pmtTenderSubstatus = new TenderSubstatusParameters();

            this.frmTender.tscDetTenderSubstatus.Parameters = pmtTenderSubstatus;
            this.frmTender.tscDetTenderSubstatus.Refresh();
            this.frmTender.tscDetTenderSubstatus.ReadOnly = true;

            this.frmTender.tscSchTenderSubstatus.Parameters = pmtTenderSubstatus;
            this.frmTender.tscSchTenderSubstatus.Refresh();

            // Bidder
            BidderParameters pmtBidder = new BidderParameters();

            this.frmTender.bcDetBidder.Parameters = pmtBidder;
            this.frmTender.bcDetBidder.Refresh();

            this.frmTender.bcSchBidder.Parameters = pmtBidder;
            this.frmTender.bcSchBidder.Refresh();

            this.frmTender.bcSchBidder.ValueChanged += new 
                SamsaraEntityChooserValueChangedEventHandler<Bidder>(bcSchBidder_ValueChanged);
            this.frmTender.bcDetBidder.ValueChanged += new 
                SamsaraEntityChooserValueChangedEventHandler<Bidder>(bcDetBidder_ValueChanged);

            // Dependency
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = ParameterConstants.IntNone;

            this.frmTender.dcDetDependency.Parameters = pmtDependency;
            this.frmTender.dcDetDependency.Refresh();

            this.frmTender.dcSchDependency.Parameters = pmtDependency;
            this.frmTender.dcSchDependency.Refresh();

            this.frmTender.dcSchDependency.ValueChanged += new 
                SamsaraEntityChooserValueChangedEventHandler<Dependency>(dcSchDependency_ValueChanged);
            this.frmTender.dcDetDependency.ValueChanged += new 
                SamsaraEntityChooserValueChangedEventHandler<Dependency>(dcDetDependency_ValueChanged);

            // EndUser
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = ParameterConstants.IntNone;

            // Currency            
            CurrencyParameters pmtCurrency = new CurrencyParameters();
            IList<Currency> lstCurrencies = this.srvCurrency.GetListByParameters(pmtCurrency);
            WindowsFormsUtil.LoadCombo<Currency>(this.frmTender.uceDetPreresultCurrency,
                lstCurrencies, "CurrencyId", "Code", null);

            //grdDetTenderLines
            this.frmTender.grdDetTenderLines.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderLines_InitializeLayout);
            this.frmTender.grdDetTenderLines.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdDetTenderLines_BeforeCellUpdate);
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
            this.frmTender.grdDetExchangeRates.AfterCellUpdate
                += new CellEventHandler(grdDetExchangeRates_AfterCellUpdate);
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

            //grdDetTenderWarranties
            this.frmTender.grdDetTenderWarranties.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderWarranties_InitializeLayout);
            this.frmTender.grdDetTenderWarranties.AfterCellUpdate +=
                new CellEventHandler(grdDetTenderWarranties_AfterCellUpdate);
            TenderWarrantyParameters pmtTenderWarranty = new TenderWarrantyParameters();
            pmtTenderWarranty.TenderId = ParameterConstants.IntNone;
            this.dtTenderWarranties = this.srvTenderWarranty.SearchByParameters(pmtTenderWarranty);
            this.frmTender.grdDetTenderWarranties.DataSource = null;
            this.frmTender.grdDetTenderWarranties.DataSource = dtTenderWarranties;

            //grdDetTenderFiles
            this.frmTender.grdDetTenderFiles.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderFiles_InitializeLayout);
            TenderFileParameters pmtTenderFile = new TenderFileParameters();
            pmtTenderFile.TenderId = ParameterConstants.IntNone;
            this.dtTenderFiles = this.srvTenderFile.SearchByParameters(pmtTenderFile);
            this.frmTender.grdDetTenderFiles.DataSource = null;
            this.frmTender.grdDetTenderFiles.DataSource = this.dtTenderFiles;

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
            this.frmTender.grdDetPricingStrategy.AfterCellUpdate
                += new CellEventHandler(grdDetPricingStrategy_AfterCellUpdate);
            PricingStrategyParameters pmtPricingStrategy = new PricingStrategyParameters();
            pmtPricingStrategy.PricingStrategyId = ParameterConstants.IntNone;
            this.dtPricingStrategy = this.srvPricingStrategy.SearchByParameters(pmtPricingStrategy);
            this.dtPricingStrategy.Columns.Add(new DataColumn("TenderLineName", typeof(string)));
            this.dtPricingStrategy.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
            this.dtPricingStrategy.Columns.Add(new DataColumn("Warranties", typeof(decimal)));
            this.dtPricingStrategy.Columns.Add(new DataColumn("ExtraCosts", typeof(decimal)));
            this.frmTender.grdDetPricingStrategy.DataSource = null;
            this.frmTender.grdDetPricingStrategy.DataSource = dtPricingStrategy;

            //grdDetTenderLinesExtraCosts
            this.frmTender.grdDetTenderLinesExtraCosts.AfterRowUpdate
                += new RowEventHandler(grdDetTenderLinesExtraCosts_AfterRowUpdate);
            this.frmTender.grdDetTenderLinesExtraCosts.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderLinesExtraCosts_InitializeLayout);

            TenderLineExtraCostParameters pmtTenderLineExtraCost = new TenderLineExtraCostParameters();
            pmtTenderLineExtraCost.TenderLineId = ParameterConstants.IntNone;
            this.dtTenderLineExtraCosts = this.srvTenderLineExtraCost.SearchByParameters(pmtTenderLineExtraCost);

            DataSet dsTenderLineExtraCosts = new DataSet();

            dsTenderLineExtraCosts.Tables.Add(this.dtTenderLines);
            dsTenderLineExtraCosts.Tables.Add(this.dtTenderLineExtraCosts);

            DataRelation drTenderLineExtraCosts = new DataRelation("drTenderLineExtraCosts",
                this.dtTenderLines.Columns["TenderLineId"], this.dtTenderLineExtraCosts.Columns["TenderLineId"], true);
            dsTenderLineExtraCosts.Relations.Add(drTenderLineExtraCosts);            

            this.frmTender.grdDetTenderLinesExtraCosts.DataSource = null;
            this.frmTender.grdDetTenderLinesExtraCosts.DataSource = dsTenderLineExtraCosts;
            this.frmTender.grdDetTenderLinesExtraCosts.Rows.ExpandAll(true);

            //grdDetPreresults
            this.frmTender.grdDetPreresults.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetPreresults_InitializeLayout);
            this.frmTender.grdDetPreresults.DoubleClickCell +=
                new DoubleClickCellEventHandler(grdDetPreresults_DoubleClickCell);

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
            this.frmTender.ubtnDetCreateCompetitor.Click += new EventHandler(ubtnDetCreateCompetitor_Click);
            this.frmTender.ubtnDetDeleteCompetitor.Click += new EventHandler(ubtnDetDeleteCompetitor_Click);
            this.frmTender.ubtnDetCreateWholesaler.Click += new EventHandler(ubtnDetCreateWholesaler_Click);
            this.frmTender.ubtnDetDeleteWholesaler.Click += new EventHandler(ubtnDetDeleteWholesaler_Click);
            this.frmTender.ubtnDetCreateWarranty.Click += new EventHandler(ubtnDetCreateWarranty_Click);
            this.frmTender.ubtnDetDeleteWarranty.Click += new EventHandler(ubtnDetDeleteWarranty_Click);
            this.frmTender.ubtnDetCancelPreresult.Click += new EventHandler(ubtnDetCancelPreresult_Click);
            this.frmTender.ubtnDetSavePreresult.Click += new EventHandler(ubtnDetSavePreresult_Click);
            this.frmTender.ubtnDetDeletePreresult.Click += new EventHandler(ubtnDetDeletePreresult_Click);
            this.frmTender.ubtnDetCancelTenderFile.Click += new EventHandler(ubtnDetCancelTenderFile_Click);
            this.frmTender.ubtnDetCreateTenderFile.Click += new EventHandler(ubtnDetCreateTenderFile_Click);
            this.frmTender.ubtnDetDeleteTenderFile.Click += new EventHandler(ubtnDetDeleteTenderFile_Click);
            this.frmTender.ubtnDetNewTenderFile.Click += new EventHandler(ubtnDetNewTenderFile_Click);
            this.frmTender.btnDetSearchFile.Click += new EventHandler(btnDetSearchFile_Click);
            this.frmTender.ubtnDetCreateTenderLineExtraCost.Click += new EventHandler(ubtnDetCreateTenderLineExtraCost_Click);
            this.frmTender.ubtnDetDeleteTenderLineExtraCost.Click += new EventHandler(ubtnDetDeleteTenderLineExtraCost_Click);
            this.frmTender.uchkDetAddExtraCosts.CheckedChanged += new EventHandler(uchkDetAddExtraCosts_CheckedChanged);
            this.frmTender.uchkDetProrateWarranties.CheckedChanged += new EventHandler(uchkDetProrateWarranties_CheckedChanged);
            this.frmTender.ubtnDetDownloadTenderFile.Click += new EventHandler(ubtnDetDownloadTenderFile_Click);

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
            if (this.frmTender.bcDetBidder.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Licitante.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTender.tabDetDetail.SelectedTab =
                    this.frmTender.tabDetDetail.TabPages["Principal"];
                this.frmTender.bcDetBidder.Focus();
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
                //if (Convert.ToInt32(row["ManufacturerId"]) == -1)
                //{
                //    MessageBox.Show("Debe seleccionar un fabricante por partida.",
                //        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.frmTender.tabDetDetail.SelectedTab =
                //        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                //    this.frmTender.tcDetTextControls.SelectedTab =
                //        this.frmTender.tcDetTextControls.TabPages["TenderLines"];
                //    return false;
                //}

                if (row["Quantity"].ToString().Trim() == string.Empty
                    || Convert.ToDecimal(row["Quantity"]) <= 0)
                {
                    MessageBox.Show("Debe poner una cantidad correcta por partida.",
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
                        this.frmTender.tcDetTextControls.TabPages["Wholesalers"];
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

            foreach (DataRow row in this.dtTenderWarranties.Rows)
            {
                if (Convert.ToInt32(row["WarrantyTypeId"]) == -1)
                {
                    MessageBox.Show(
                        "Debe seleccionar un tipo de fianza por renglón en la lista de fianzas.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTender.tabDetDetail.SelectedTab =
                        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTender.tcDetTextControls.SelectedTab =
                        this.frmTender.tcDetTextControls.TabPages["Warranties"];
                    return false;
                }

                if (Convert.ToInt32(row["DocumentTypeWarrantyId"]) == -1)
                {
                    MessageBox.Show(
                        "Debe seleccionar un tipo de documento de fianza por renglón en la lista de fianzas.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTender.tabDetDetail.SelectedTab =
                        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTender.tcDetTextControls.SelectedTab =
                        this.frmTender.tcDetTextControls.TabPages["Warranties"];
                    return false;
                }

                if (row["Amount"].ToString().Trim() == string.Empty)
                {
                    MessageBox.Show(
                        "Debe seleccionar un monto de la fianza por renglón en la lista de fianzas.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTender.tabDetDetail.SelectedTab =
                        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTender.tcDetTextControls.SelectedTab =
                        this.frmTender.tcDetTextControls.TabPages["Warranties"];
                    return false;
                }
            }

            return true;
        }

        private void LoadEntity()
        {
            this.tender.Bidder = this.frmTender.bcDetBidder.Value;
            this.tender.Dependency = this.frmTender.dcDetDependency.Value;
            this.tender.EndUser = null;
            this.tender.Asesor = this.frmTender.acDetAsesor.Value;
            this.tender.ApprovedBy = null;
            this.tender.TenderStatus = this.frmTender.tscDetTenderStatus.Value;

            this.tender.ClarificationDate = (Nullable<DateTime>)this.frmTender.dteDetClarificationDate.Value;
            this.tender.Deadline = (Nullable<DateTime>)this.frmTender.dteDetDeadline.Value;
            this.tender.PreRevisionDate = null;
            this.tender.RegistrationDate = (Nullable<DateTime>)this.frmTender.dteDetRegistrationDate.Value;
            this.tender.VerdictDate = null;
            this.tender.Address = string.Empty;
            this.tender.AcquisitionReason = this.frmTender.txtDetAcquisitionReason.Text;
            this.tender.PricingStrategy = this.frmTender.txtDetPricingStrategy.Text;
            this.tender.Results = this.frmTender.txtDetResults.Text;
            this.tender.PreResults = this.frmTender.txtDetPreResults.Text;
            this.tender.Name = this.frmTender.txtDetTenderName.Text;
            this.tender.PreviousTender = this.frmTender.tscPreviousTender.Value;
            this.tender.Opportunity = this.frmTender.oscDetRelatedOpportunity.Value;
            this.tender.PriceComparison = this.frmTender.txtDetPriceComparison.Text;
            this.tender.AddExtraCosts = this.frmTender.uchkDetAddExtraCosts.Checked;
            this.tender.ProrateWarranties = this.frmTender.uchkDetProrateWarranties.Checked;

            this.LoadTenderManufacturers();
            this.LoadTenderLines();
            this.LoadPricingEstrategy();
            this.LoadTenderWholesalers();
            this.LoadTenderCompetitors();
            this.LoadTenderLogs();
            this.LoadTenderExchangeRates();
            this.LaodTenderWarranties();

            this.tender.Activated = true;
            this.tender.Deleted = false;
        }

        private void LaodTenderWarranties()
        {
            foreach (TenderWarranty tenderWarranty in this.tender.TenderWarranties)
            {
                tenderWarranty.Deleted = true;
                tenderWarranty.Activated = false;
            }

            foreach (DataRow row in this.dtTenderWarranties.Rows)
            {
                TenderWarranty tenderWarranty = this.tender.TenderWarranties
                    .SingleOrDefault(x => row["TenderWarrantyId"] != DBNull.Value &&
                        x.TenderWarrantyId == Convert.ToInt32(row["TenderWarrantyId"]) &&
                        Convert.ToInt32(row["TenderWarrantyId"]) > 0);

                if (tenderWarranty == null)
                {
                    tenderWarranty = new TenderWarranty();
                    this.tender.TenderWarranties.Add(tenderWarranty);
                }

                tenderWarranty.WarrantyType
                    = this.srvWarrantyType.GetById(Convert.ToInt32(row["WarrantyTypeId"]));
                tenderWarranty.DocumentTypeWarranty
                    = this.srvDocumentTypeWarranty.GetById(Convert.ToInt32(row["DocumentTypeWarrantyId"]));
                tenderWarranty.Tender = this.tender;
                tenderWarranty.Description = row["Description"].ToString();
                tenderWarranty.Name = row["Name"].ToString();
                tenderWarranty.Amount = Convert.ToDecimal(row["Amount"]);
                tenderWarranty.ExpirationDate = row["ExpirationDate"] == DBNull.Value ?
                    null : (Nullable<DateTime>)Convert.ToDateTime(row["ExpirationDate"]);

                tenderWarranty.Activated = true;
                tenderWarranty.Deleted = false;
            }
        }

        private void LoadPricingEstrategy()
        {
            foreach (DataRow row in this.dtPricingStrategy.AsEnumerable())
            {
                TenderLine tenderLine = this.tender.TenderLines
                    .Single(x => x.TenderLineId == Convert.ToInt32((row["PricingStrategyId"])));
                PricingStrategy pricingStrategy = tenderLine.PricingStrategy;

                if (pricingStrategy == null)
                {
                    pricingStrategy = new PricingStrategy();
                    tenderLine.PricingStrategy = pricingStrategy;
                }

                pricingStrategy.ProfitMargin = Convert.ToDecimal(row["ProfitMargin"]);
                if (row["SelectedPrice"] != DBNull.Value)
                {
                    pricingStrategy.SelectedPrice = Convert.ToDecimal(row["SelectedPrice"]);
                    pricingStrategy.TenderLineProfit = Convert.ToDecimal(row["TenderLineProfit"]);
                    pricingStrategy.RealPrice = Convert.ToDecimal(row["RealPrice"]);
                    pricingStrategy.TotalPriceAfterTax = Convert.ToDecimal(row["TotalPriceAfterTax"]);
                    pricingStrategy.TotalPriceBeforeTax = Convert.ToDecimal(row["TotalPriceBeforeTax"]);
                    pricingStrategy.UnitPriceAfterTax = Convert.ToDecimal(row["UnitPriceAfterTax"]);
                    pricingStrategy.UnitPriceBeforeTax = Convert.ToDecimal(row["UnitPriceBeforeTax"]);
                    pricingStrategy.UnitProfit = Convert.ToDecimal(row["UnitProfit"]);
                }

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
                tenderCompetitor.Competitor = this.srvCompetitor.GetById(Convert.ToInt32(row["CompetitorId"]));
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
                TenderLine tenderLine = null;

                if (Convert.ToInt32(row["TenderLineId"]) <= 0)
                    tenderLine = this.tender.TenderLines
                        .Single(x => row["TenderLineId"] != DBNull.Value &&
                            -x.GetHashCode() == Convert.ToInt32(row["TenderLineId"]));
                else
                    tenderLine = this.tender.TenderLines
                        .Single(x => row["TenderLineId"] != DBNull.Value &&
                            x.TenderLineId == Convert.ToInt32(row["TenderLineId"]) &&
                            Convert.ToInt32(row["TenderLineId"]) > 0);

                tenderLine.Tender = this.tender;
                tenderLine.Description = row["Description"].ToString();
                if (row["ManufacturerId"] == DBNull.Value)
                    tenderLine.Manufacturer = null;
                else
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
            this.frmTender.acDetAsesor.Value = null;
            this.frmTender.bcDetBidder.Value = null;
            this.frmTender.dcDetDependency.Value = null;
            this.frmTender.tscDetTenderStatus.Value = null;
            this.frmTender.txtDetAcquisitionReason.Text = string.Empty;
            this.frmTender.txtDetPreResults.Text = string.Empty;
            this.frmTender.txtDetPriceComparison.Text = string.Empty;
            this.frmTender.txtDetPricingStrategy.Text = string.Empty;
            this.frmTender.txtDetResults.Text = string.Empty;
            this.frmTender.txtDetTenderName.Text = string.Empty;
            this.frmTender.dteDetClarificationDate.Value = null;
            this.frmTender.dteDetDeadline.Value = null;
            this.frmTender.dteDetRegistrationDate.Value = null;
            this.frmTender.oscDetRelatedOpportunity.Clear();
            this.frmTender.tscPreviousTender.Clear();
            this.dtTenderManufacturers.Rows.Clear();
            this.dtTenderFiles.Rows.Clear();
            this.dtTenderLineExtraCosts.Rows.Clear();
            this.dtTenderLines.Rows.Clear();
            this.dtTenderCompetitors.Rows.Clear();
            this.dtTenderWholesalers.Rows.Clear();
            this.dtTenderWarranties.Rows.Clear();
            this.dtTenderLog.Rows.Clear();
            this.dtPriceComparison = null;
            this.dtPreresults = null;
            this.dtPricingStrategy.Rows.Clear();
            this.frmTender.grdDetPriceComparison.DataSource = null;
            this.frmTender.grdDetPreresults.DataSource = null;
            this.dtTenderExchangeRates.Clear();
            this.frmTender.uchkDetAddExtraCosts.Checked = false;
            this.frmTender.uchkDetProrateWarranties.Checked = false;
        }

        private void ClearSearchControls()
        {
            this.frmTender.txtSchTenderName.Text = string.Empty;
            this.frmTender.acSchAsesor.Value = null;
            this.frmTender.bcSchBidder.Value = null;
            this.frmTender.dcSchDependency.Value = null;
            this.frmTender.tscSchTenderStatus.Value = null;
            this.frmTender.uosSchDates.Value = -1;
            this.frmTender.dteSchMaxDate.DateTime = DateTime.Now;
            this.frmTender.dteSchMinDate.DateTime = DateTime.Now;
        }

        private void ClearPreresultsControls()
        {
            this.frmTender.uceDetPreresultCurrency.Value = null;
            this.frmTender.txtDetPreresultManufacturer.Value = null;
            this.frmTender.txtDetPreresultCompetitor.Value = null;
            this.frmTender.txtDetPreresultsComments.Value = null;
            this.frmTender.umskDetPreresultPrice.Value = null;
        }

        private void SaveTender()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Licitación?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                try
                {
                    this.frmTender.Cursor = Cursors.WaitCursor;
                    this.LoadEntity();
                    this.srvTender.SaveOrUpdate(this.tender);
                    this.EditTender(this.tender.TenderId);
                }
                finally
                {
                    this.frmTender.Cursor = Cursors.Default;
                }
            }
        }

        private void EditTender(int tenderId)
        {
            try
            {
                this.frmTender.Cursor = Cursors.WaitCursor;
                this.tender = this.srvTender.GetById(tenderId);

                this.ClearDetailControls();
                this.LoadFormFromEntity();
                this.frmTender.HiddenDetail(false);
                this.ShowDetail(true);
            }
            finally
            {
                this.frmTender.Cursor = Cursors.Default;
            }
        }

        private void LoadFormFromEntity()
        {
            this.frmTender.acDetAsesor.Value = this.tender.Asesor;
            this.frmTender.bcDetBidder.Value = this.tender.Bidder;
            this.frmTender.dcDetDependency.Value = this.tender.Dependency;
            this.frmTender.tscDetTenderStatus.Value = this.tender.TenderStatus;
            this.frmTender.txtDetAcquisitionReason.Text = this.tender.AcquisitionReason;
            this.frmTender.txtDetPreResults.Text = this.tender.PreResults;
            this.frmTender.txtDetPriceComparison.Text = this.tender.PriceComparison;
            this.frmTender.txtDetPricingStrategy.Text = this.tender.PricingStrategy;
            this.frmTender.txtDetResults.Text = this.tender.Results;
            this.frmTender.txtDetTenderName.Text = this.tender.Name;
            if (this.tender.ClarificationDate.HasValue)
                this.frmTender.dteDetClarificationDate.Value = this.tender.ClarificationDate.Value;
            if (this.tender.Deadline.HasValue)
                this.frmTender.dteDetDeadline.Value = this.tender.Deadline.Value;
            if (this.tender.RegistrationDate.HasValue)
                this.frmTender.dteDetRegistrationDate.Value = this.tender.RegistrationDate.Value;
            this.frmTender.tscPreviousTender.Value = this.tender.PreviousTender;
            this.frmTender.oscDetRelatedOpportunity.Value = this.tender.Opportunity;
            this.frmTender.uchkDetAddExtraCosts.Checked = this.tender.AddExtraCosts;
            this.frmTender.uchkDetProrateWarranties.Checked = this.tender.ProrateWarranties;
            this.uchkDetAddExtraCosts_CheckedChanged(null, null);
            this.uchkDetProrateWarranties_CheckedChanged(null, null);

            foreach (TenderCompetitor tenderCompetitor in this.tender.TenderCompetitors)
            {
                DataRow row = this.dtTenderCompetitors.NewRow();
                this.dtTenderCompetitors.Rows.Add(row);

                row["Description"] = tenderCompetitor.Description;
                row["CompetitorId"] = tenderCompetitor.Competitor.CompetitorId;
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

                row["Description"] = tenderLine.Description;
                if (tenderLine.Manufacturer == null)
                    row["ManufacturerId"] = DBNull.Value;
                else
                    row["ManufacturerId"] = tenderLine.Manufacturer.ManufacturerId;
                row["Name"] = tenderLine.Name;
                row["Quantity"] = tenderLine.Quantity;
                row["TenderId"] = tenderLine.Tender.TenderId;
                row["TenderLineId"] = tenderLine.TenderLineId;

                this.dtTenderLines.Rows.Add(row);
            }
            this.grdDetTenderLines_InitializeLayout(null, null);

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

            foreach (TenderWarranty tenderWarranty in this.tender.TenderWarranties)
            {
                DataRow row = this.dtTenderWarranties.NewRow();
                this.dtTenderWarranties.Rows.Add(row);

                row["Description"] = tenderWarranty.Description;
                row["DocumentTypeWarrantyId"] = tenderWarranty.DocumentTypeWarranty.DocumentTypeWarrantyId;
                row["Name"] = tenderWarranty.Name;
                row["TenderId"] = tenderWarranty.Tender.TenderId;
                row["TenderWarrantyId"] = tenderWarranty.TenderWarrantyId;
                row["WarrantyTypeId"] = tenderWarranty.WarrantyType.WarrantyTypeId;
                if (tenderWarranty.ExpirationDate == null)
                    row["ExpirationDate"] = DBNull.Value;
                else
                    row["ExpirationDate"] = tenderWarranty.ExpirationDate;
                row["Amount"] = tenderWarranty.Amount;
            }

            foreach (TenderLineExtraCost tenderLineExtraCost in this.tender.TenderLines
                .SelectMany(x => x.TenderLineExtraCosts))
            {
                DataRow row = this.dtTenderLineExtraCosts.NewRow();

                row["TenderLineId"] = tenderLineExtraCost.TenderLine.TenderLineId;
                row["TenderLineExtraCostId"] = tenderLineExtraCost.TenderLineExtraCostId;
                row["Description"] = tenderLineExtraCost.Description;
                row["Name"] = tenderLineExtraCost.Name;
                row["Amount"] = tenderLineExtraCost.Amount;

                this.dtTenderLineExtraCosts.Rows.Add(row);
            }

            DataSet dsTenderLinesExtraCosts = new DataSet();

            this.dtTenderLines = this.dtTenderLines.Copy();
            this.dtTenderLineExtraCosts = this.dtTenderLineExtraCosts.Copy();

            this.frmTender.grdDetTenderLines.DataSource = this.dtTenderLines;

            dsTenderLinesExtraCosts.Tables.Add(this.dtTenderLines);
            dsTenderLinesExtraCosts.Tables.Add(this.dtTenderLineExtraCosts);
            dsTenderLinesExtraCosts.Relations.Add(new DataRelation("drTenderLineExtraCosts",
                this.dtTenderLines.Columns["TenderLineId"], this.dtTenderLineExtraCosts.Columns["TenderLineId"]));
            dsTenderLinesExtraCosts.AcceptChanges();

            this.frmTender.grdDetTenderLinesExtraCosts.DataSource = null;
            this.frmTender.grdDetTenderLinesExtraCosts.DataSource = dsTenderLinesExtraCosts;
            this.frmTender.grdDetTenderLinesExtraCosts.Rows.ExpandAll(true);

            this.SearchTenderFiles();
            this.UpdatePriceComparisonGrid();
            this.UpdatePricingStrategyGrid();
            this.UpdatePreresultsGrid();
            this.UpdatePricingStrategyExtraCosts();
            this.UpdatePricingStrategyWarranties();
        }

        private void SearchTenderFiles()
        {
            TenderFileParameters pmtTenderFile = new TenderFileParameters();

            pmtTenderFile.TenderId = this.tender.TenderId;
            this.dtTenderFiles = this.srvTenderFile.SearchByParameters(pmtTenderFile);

            this.frmTender.grdDetTenderFiles.DataSource = null;
            this.frmTender.grdDetTenderFiles.DataSource = this.dtTenderFiles;

            foreach (DataRow row in this.dtTenderFiles.AsEnumerable())
            {
                TenderFile tenderFile = new TenderFile();
                tenderFile.TenderFileId = Convert.ToInt32(row[0]);
                this.tender.TenderFiles.Add(tenderFile);
            }
        }

        private void DeleteEntity(int tenderId)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro de eliminar la Licitación?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.frmTender.Cursor = Cursors.WaitCursor;
                this.tender = this.srvTender.GetById(tenderId);
                this.tender.Activated = false;
                this.tender.Deleted = true;
                this.srvTender.SaveOrUpdate(this.tender);
                this.Search();
            }
            finally
            {
                this.frmTender.Cursor = Cursors.Default;
            }
        }

        private void Search()
        {
            TenderParameters pmtTender = new TenderParameters();

            pmtTender.MinDate = (DateTime)this.frmTender.dteSchMinDate.Value;
            pmtTender.MaxDate = (DateTime)this.frmTender.dteSchMaxDate.Value;
            pmtTender.AsesorId = this.frmTender.acSchAsesor.Value == null ?
                -1 : this.frmTender.acSchAsesor.Value.AsesorId;
            pmtTender.BidderId = this.frmTender.bcSchBidder.Value == null ?
                -1 : this.frmTender.bcSchBidder.Value.BidderId;
            pmtTender.DependencyId = this.frmTender.dcSchDependency.Value == null ?
                -1 : this.frmTender.dcSchDependency.Value.DependencyId;
            pmtTender.TenderStatusId = this.frmTender.tscSchTenderStatus.Value == null ?
                -1 : this.frmTender.tscSchTenderStatus.Value.TenderStatusId;
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

            if (!this.dtPriceComparison.Columns.Contains("TenderLineQuantity"))
            {
                DataColumn dc = new DataColumn("TenderLineQuantity", typeof(string));
                this.dtPriceComparison.Columns.Add(dc);
            }

            if (!this.dtPriceComparison.Columns.Contains("TenderLineDescription"))
            {
                DataColumn dc = new DataColumn("TenderLineDescription", typeof(string));
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
                    rowPC["TenderLineQuantity"] = row["Quantity"];
                    rowPC["TenderLineDescription"] = row["Description"];
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

        private void UpdatePreresultsGrid()
        {
            int intColumnName;

            if (this.dtPreresults == null)
            {
                this.dtPreresults = new DataTable();
            }

            if (!this.dtPreresults.Columns.Contains("TenderLineId"))
            {
                DataColumn dc = new DataColumn("TenderLineId", typeof(int));
                this.dtPreresults.Columns.Add(dc);
            }

            if (!this.dtPreresults.Columns.Contains("TenderLineName"))
            {
                DataColumn dc = new DataColumn("TenderLineName", typeof(string));
                this.dtPreresults.Columns.Add(dc);
            }

            foreach (int competitorId in this.dtTenderCompetitors.AsEnumerable()
                .Select(x => Convert.ToInt32(x["CompetitorId"])))
            {
                if (!this.dtPreresults.Columns.Contains(competitorId.ToString()))
                {
                    DataColumn dcCompetitor = new DataColumn(competitorId.ToString(), typeof(decimal));
                    this.dtPreresults.Columns.Add(dcCompetitor);
                    DataColumn dcCompetitorCurrency = new DataColumn(competitorId.ToString() + "C", typeof(int));
                    this.dtPreresults.Columns.Add(dcCompetitorCurrency);
                }
            }

            IEnumerable<string> columnNames = this.dtPreresults.Copy().Columns
                .Cast<DataColumn>().Select(x => x.ColumnName);

            foreach (string strColumnName in columnNames.Where(x => int.TryParse(x, out intColumnName)))
            {
                if (!this.dtTenderCompetitors.AsEnumerable()
                    .Select(x => x["CompetitorId"].ToString()).Contains(strColumnName))
                {
                    foreach (TenderLineCompetitor tenderLineCompetitor in
                        this.tender.TenderLines.SelectMany(x => x.TenderLineCompetitors)
                        .Where(x => x.Competitor.CompetitorId == Convert.ToInt32(strColumnName)))
                    {
                        this.tenderLineCompetitor.Activated = false;
                        this.tenderLineCompetitor.Deleted = true;
                    }
                    this.dtPreresults.Columns.Remove(strColumnName);
                    this.dtPreresults.Columns.Remove(strColumnName + "C");
                }
            }

            foreach (DataRow row in this.dtTenderLines.AsEnumerable())
            {
                if (Convert.ToInt32(row["TenderLineId"]) > 0 && !this.dtPreresults.Rows.Cast<DataRow>()
                    .Select(x => x["TenderLineId"].ToString()).Contains(row["TenderLineId"].ToString()))
                {
                    DataRow rowPC = this.dtPreresults.NewRow();
                    rowPC["TenderLineId"] = row["TenderLineId"];
                    rowPC["TenderLineName"] = row["Name"];
                    this.dtPreresults.Rows.Add(rowPC);
                }
            }

            foreach (DataRow row in this.dtPreresults.AsEnumerable())
            {
                foreach (DataColumn column in this.dtPreresults.Columns.Cast<DataColumn>()
                    .Where(x => x.ColumnName.EndsWith("C")))
                {
                    if (row[column.ColumnName] == DBNull.Value)
                        row[column.ColumnName] = this.defaultCurrency.CurrencyId;
                }
            }

            IEnumerable<DataRow> rows = this.dtPreresults.Copy().AsEnumerable();

            foreach (DataRow drTenderLine in rows)
            {
                string tenderLineName = drTenderLine["TenderLineName"].ToString();

                if (!this.dtTenderLines.AsEnumerable()
                    .Select(x => x["Name"].ToString()).Contains(tenderLineName))
                {
                    foreach (TenderLineCompetitor tenderLineCompetitor in
                        this.tender.TenderLines.SelectMany(x => x.TenderLineCompetitors)
                        .Where(x => x.TenderLine.TenderLineId == Convert.ToInt32(drTenderLine["TenderLineId"])))
                    {
                        this.tenderLineCompetitor.Activated = false;
                        this.tenderLineCompetitor.Deleted = true;
                    }
                    this.dtPreresults.Rows.Remove(this.dtPreresults.AsEnumerable()
                        .Single(x => Convert.ToInt32(x["TenderLineId"]) == Convert.ToInt32(drTenderLine["TenderLineId"])));
                }
            }

            foreach (TenderLineCompetitor tenderLineCompetitor in
                this.tender.TenderLines.SelectMany(x => x.TenderLineCompetitors)
                .Where(x => x.Activated && !x.Deleted))
            {
                DataRow row = this.dtPreresults.AsEnumerable().SingleOrDefault(x =>
                    Convert.ToInt32(x["TenderLineId"]) == tenderLineCompetitor.TenderLine.TenderLineId);

                if (row != null)
                {
                    if (tenderLineCompetitor.Price != null)
                        row[tenderLineCompetitor.Competitor.CompetitorId.ToString()] = tenderLineCompetitor.Price;
                    else
                        row[tenderLineCompetitor.Competitor.CompetitorId.ToString()] = DBNull.Value;

                    if (tenderLineCompetitor.Currency != null)
                        row[tenderLineCompetitor.Competitor.CompetitorId.ToString() + "C"] = tenderLineCompetitor.Currency.CurrencyId;
                    else
                        row[tenderLineCompetitor.Competitor.CompetitorId.ToString() + "C"] = this.defaultCurrency.CurrencyId;
                }
            }

            this.dtPreresults.AcceptChanges();

            this.frmTender.grdDetPreresults.DataSource = null;
            this.frmTender.grdDetPreresults.DataSource = dtPreresults;
        }

        private void UpdatePricingStrategyGrid()
        {
            foreach (TenderLine tenderLine in this.tender.TenderLines)
            {
                PricingStrategy pricingStrategy = tenderLine.PricingStrategy;
                decimal proratedWarrantiesSummary = 0;
                decimal extraCostsSummary = 0;

                if (pricingStrategy == null)
                {
                    pricingStrategy = new PricingStrategy();
                    tenderLine.PricingStrategy = pricingStrategy;

                    pricingStrategy.ProfitMargin = 5;
                    pricingStrategy.Activated = true;
                    pricingStrategy.Deleted = false;
                }

                if (tenderLine.Wholesaler != null)
                    pricingStrategy.Wholesaler = tenderLine.Wholesaler;

                DataRow drPricingStrategy = this.dtPricingStrategy.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["PricingStrategyId"]) == tenderLine.TenderLineId);

                pricingStrategy.SelectedPrice = drPricingStrategy == null
                    || drPricingStrategy["SelectedPrice"] == DBNull.Value ?
                    pricingStrategy.SelectedPrice : Convert.ToDecimal(drPricingStrategy["SelectedPrice"]);

                pricingStrategy.ProfitMargin = drPricingStrategy == null
                    || drPricingStrategy["ProfitMargin"] == DBNull.Value ?
                    pricingStrategy.ProfitMargin : Convert.ToDecimal(drPricingStrategy["ProfitMargin"]);

                pricingStrategy.RealPrice = drPricingStrategy == null
                    || drPricingStrategy["RealPrice"] == DBNull.Value ?
                    pricingStrategy.RealPrice : Convert.ToDecimal(drPricingStrategy["RealPrice"]);

                if (this.tender.AddExtraCosts)
                    extraCostsSummary = drPricingStrategy == null
                        || drPricingStrategy["ExtraCosts"] == DBNull.Value ?
                        pricingStrategy.RealPrice : Convert.ToDecimal(drPricingStrategy["ExtraCosts"]);

                if (this.tender.ProrateWarranties)
                    proratedWarrantiesSummary = drPricingStrategy == null
                        || drPricingStrategy["Warranties"] == DBNull.Value ?
                        pricingStrategy.RealPrice : Convert.ToDecimal(drPricingStrategy["Warranties"]);

                try
                {
                    pricingStrategy.UnitPriceBeforeTax = pricingStrategy.SelectedPrice
                        / (1 - pricingStrategy.ProfitMargin / 100M);
                }
                catch (DivideByZeroException ex)
                {
                    ex.ToString();
                    pricingStrategy.UnitPriceBeforeTax = 0;
                }

                pricingStrategy.UnitProfit = pricingStrategy.UnitPriceBeforeTax
                    - pricingStrategy.SelectedPrice;
                pricingStrategy.TenderLineProfit = pricingStrategy.UnitProfit
                    * tenderLine.Quantity;
                pricingStrategy.UnitPriceAfterTax = pricingStrategy.UnitPriceBeforeTax
                    * (1 + TaxesUtil.GetTaxPercent(TaxEnum.IVA));

                pricingStrategy.TotalPriceBeforeTax = pricingStrategy.UnitPriceBeforeTax
                    * tenderLine.Quantity;
                pricingStrategy.TotalPriceAfterTax = pricingStrategy.TotalPriceBeforeTax
                    * (1 + TaxesUtil.GetTaxPercent(TaxEnum.IVA)) + proratedWarrantiesSummary
                    + extraCostsSummary;

                DataRow row = this.dtPricingStrategy.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["PricingStrategyId"]) == tenderLine.TenderLineId);

                if (row == null)
                {
                    row = this.dtPricingStrategy.NewRow();
                    this.dtPricingStrategy.Rows.Add(row);
                }

                row["PricingStrategyId"] = pricingStrategy.PricingStrategyId = tenderLine.TenderLineId;
                row["TenderLineName"] = tenderLine.Name;
                row["Quantity"] = tenderLine.Quantity;
                row["ProfitMargin"] = pricingStrategy.ProfitMargin;
                row["RealPrice"] = pricingStrategy.RealPrice;
                row["SelectedPrice"] = pricingStrategy.SelectedPrice;
                row["TenderLineProfit"] = pricingStrategy.TenderLineProfit;
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
            this.UpdatePricingStrategyGridColumns();
        }

        private void UpdatePricingStrategyGridColumns()
        {
            foreach (UltraGridRow row in this.frmTender.grdDetPricingStrategy.Rows)
            {
                if (row.Cells["ManufacturerId"].Value == DBNull.Value)
                {
                    row.Cells["ManufacturerId"].Activation = Activation.ActivateOnly;
                    row.Cells["SelectedPrice"].Activation = Activation.ActivateOnly;
                }
                else
                {
                    row.Cells["ManufacturerId"].Activation = Activation.AllowEdit;
                    row.Cells["SelectedPrice"].Activation = Activation.AllowEdit;
                }

                if (row.Cells["RealPrice"].Value != DBNull.Value
                    && row.Cells["TotalPriceAfterTax"].Value != DBNull.Value
                    && Convert.ToDecimal(row.Cells["RealPrice"].Value)
                    < MoneyUtil.Round(Convert.ToDecimal(row.Cells["TotalPriceAfterTax"].Value))
                    || Convert.ToDecimal(row.Cells["TotalPriceAfterTax"].Value) * 1.05M
                    < Convert.ToDecimal(row.Cells["RealPrice"].Value))
                    row.Cells["RealPrice"].Appearance.BackColor = Color.Red;
                else
                    row.Cells["RealPrice"].Appearance.BackColor = Color.White;
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

        private Competitor GetCompetitor(int competitorId)
        {
            Competitor competitor = null;
            TenderCompetitor tenderCompetitor = this.tender.TenderCompetitors
                .SingleOrDefault(x => x.Competitor.CompetitorId == competitorId);

            if (tenderCompetitor != null)
                competitor = tenderCompetitor.Competitor;
            else
                competitor = this.srvCompetitor.GetById(competitorId);

            return competitor;
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

        private void ShowPreresultsDetail(bool show)
        {
            this.frmTender.grdDetPreresults.Enabled = !show;
            this.frmTender.upnlDetPreresults.Visible = show;
            this.frmTender.gbxDetCommentsPreresults.Visible = !show;
        }

        private void ShowTenderFilesDetail(bool show)
        {
            this.frmTender.grdDetTenderFiles.Enabled = !show;
            this.frmTender.pnlDetTenderFiles.Visible = show;
            this.frmTender.pnlDetTenderFilesButtons.Visible = !show;
        }

        private void ClearTenderFilesDetail()
        {
            this.frmTender.txtDetFilePath.Text = string.Empty;
            this.frmTender.txtDetFileDescription.Text = string.Empty;
            this.frmTender.txtDetFileName.Text = string.Empty;
        }

        private void UpdatePricingStrategyExtraCosts()
        {
            foreach (DataRow row in this.dtPricingStrategy.AsEnumerable())
            {
                row["ExtraCosts"] = this.tender.TenderLines
                    .Single(x => x.TenderLineId == Convert.ToInt32(row["PricingStrategyId"]))
                    .TenderLineExtraCosts.Sum(x => x.Amount);
            }
        }

        private void UpdatePricingStrategyWarranties()
        {
            decimal totalWarranties = this.dtTenderWarranties.AsEnumerable()
                    .Where(x => x["Amount"] != DBNull.Value)
                    .Sum(x => Convert.ToDecimal(x["Amount"]));
            decimal totalTenderAfterTax = this.dtPricingStrategy.AsEnumerable()
                    .Where(x => x["TotalPriceAfterTax"] != DBNull.Value)
                    .Sum(x => Convert.ToDecimal(x["TotalPriceAfterTax"]));

            foreach (DataRow row in this.dtPricingStrategy.AsEnumerable())
            {
                try
                {
                    row["Warranties"] = totalWarranties == 0 ? 0M :
                        (Convert.ToDecimal(row["TotalPriceAfterTax"]) / totalTenderAfterTax)
                        * totalWarranties;
                }
                catch (DivideByZeroException ex)
                {
                    ex.ToString(); 
                    row["Warranties"] = 0;
                }
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
            this.tender = new Tender();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveTender();
        }

        private void grdDetTenderLines_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["Quantity"], 
                TextMaskFormatEnum.NaturalQuantity);

            IEnumerable<Manufacturer> availableManufacturers = this.tender == null ||
                this.tender.TenderManufacturers == null ? lstManufacturers.Where(x => false) :
                lstManufacturers.Where(x => this.tender.TenderManufacturers
                    .Select(y => y.Manufacturer.ManufacturerId).Contains(x.ManufacturerId));

            WindowsFormsUtil.SetUltraGridValueList<Manufacturer>(layout, availableManufacturers, 
                band.Columns["ManufacturerId"], "ManufacturerId", "Name", "Seleccione");
        }

        private void grdDetTenderLines_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key == "Quantity")
            {
                TenderLine tenderLine = this.tender.TenderLines.SingleOrDefault(x => x.TenderLineId
                    == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value));

                if (tenderLine != null)
                {
                    tenderLine.Quantity = Convert.ToInt32(e.NewValue);
                    this.UpdatePricingStrategyGrid();
                }
            }

            DataRow rowPC = this.dtPriceComparison.AsEnumerable().SingleOrDefault(
                x => Convert.ToInt32(x["TenderLineId"]) == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value));

            if (rowPC != null && e.Cell.Column.Key == "Quantity")
            {
                rowPC["TenderLineQuantity"] = e.NewValue;
            }

            if (rowPC != null && e.Cell.Column.Key == "Description")
            {
                rowPC["TenderLineDescription"] = e.NewValue;
            }

            if (rowPC != null && e.Cell.Column.Key == "Name")
            {
                rowPC["TenderLineName"] = e.NewValue;
            }
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
            this.grdDetTenderLines_InitializeLayout(null, null);

            TenderLine tenderLine = new TenderLine();
            this.tender.TenderLines.Add(tenderLine);

            DataRow newRow = this.dtTenderLines.NewRow();
            this.dtTenderLines.Rows.Add(newRow);
            newRow["ManufacturerId"] = -1;
            newRow["TenderLineId"] = -tenderLine.GetHashCode();

            this.dtTenderLines.AcceptChanges();
            this.UpdatePriceComparisonGrid();
            this.UpdatePreresultsGrid();
        }

        private void ubtnDetDeleteLine_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderLines.ActiveRow;

            if (activeRow == null) return;

            this.dtTenderLines.Rows.Remove(((DataRowView)activeRow.ListObject).Row);

            this.UpdatePriceComparisonGrid();
            this.UpdatePreresultsGrid();
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmTender.HiddenDetail(true);
        }

        private void bcSchBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = this.frmTender.bcSchBidder.Value == null ?
                -1 : this.frmTender.bcSchBidder.Value.BidderId;

            this.frmTender.dcSchDependency.Parameters = pmtDependency;
            this.frmTender.dcSchDependency.Refresh();
        }

        private void bcDetBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = this.frmTender.bcDetBidder.Value == null ?
                -1 : this.frmTender.bcDetBidder.Value.BidderId;

            this.frmTender.dcDetDependency.Parameters = pmtDependency;
            this.frmTender.dcDetDependency.Refresh();
        }

        private void dcSchDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = this.frmTender.dcSchDependency.Value == null ?
                -1 : this.frmTender.dcSchDependency.Value.DependencyId;
        }

        private void dcDetDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = this.frmTender.dcDetDependency.Value == null ?
                -1 : this.frmTender.dcDetDependency.Value.DependencyId;
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

            this.UpdatePreresultsGrid();
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
            band.Columns["TenderLineQuantity"].CellActivation = Activation.ActivateOnly;
            band.Columns["TenderLineQuantity"].Header.Caption = "Cantidad";
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["TenderLineQuantity"],
                TextMaskFormatEnum.NaturalQuantity);
            band.Columns["TenderLineDescription"].CellActivation = Activation.ActivateOnly;
            band.Columns["TenderLineDescription"].Header.Caption = "Producto";
            band.Columns["SelectedWholesalerId"].Header.Caption = "Seleccionado";
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["BestPrice"],
                TextMaskFormatEnum.Currency);
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
                    TextMaskFormatEnum.Currency);
                WindowsFormsUtil.AddUltraGridSummary(band, band.Columns[col.ColumnName]);

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
                && activeCell.Column.Key.EndsWith("C")) &&
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
            this.SelectedWholesalerEditor_SelectionChanged(null, null);
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
            this.UpdatePricingStrategyGrid();
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
            this.SelectedWholesalerEditor_SelectionChanged(null, null);
            this.UpdatePricingStrategyGrid();
        }

        private void SelectedWholesalerEditor_SelectionChanged(object sender, EventArgs e)
        {
            object value = null;
            UltraGridRow activeRow = this.frmTender.grdDetPriceComparison.ActiveRow;
            EditorWithCombo editor = sender as EditorWithCombo;
            if (editor != null)
                value = editor.Value;
            else
                value = activeRow.Cells["SelectedWholesalerId"].Value;
            DataRow drPricingStrategy = this.dtPricingStrategy.AsEnumerable()
                .Single(x => Convert.ToInt32(x["PricingStrategyId"])
                    == Convert.ToInt32(activeRow.Cells["TenderLineId"].Value));

            if (activeRow == null)
                return;

            if (Convert.ToInt32(value) > 0)
            {
                if (activeRow.Cells[value.ToString()].Value == DBNull.Value)
                    activeRow.Cells["BestPrice"].Value = DBNull.Value;
                else
                    activeRow.Cells["BestPrice"].Value = Convert.ToDecimal(activeRow.Cells[value.ToString()].Value)
                        * this.GetExchangeRate(Convert.ToInt32(activeRow.Cells[value + "C"].Value));
                drPricingStrategy["WholesalerId"] = value;
                drPricingStrategy["ManufacturerId"] = DBNull.Value;
                drPricingStrategy["SelectedPrice"] = activeRow.Cells["BestPrice"].Value;
            }
            else
            {
                activeRow.Cells["BestPrice"].Value = DBNull.Value;
                drPricingStrategy["WholesalerId"] = DBNull.Value;
                drPricingStrategy["ManufacturerId"] = -1;
                drPricingStrategy["SelectedPrice"] = DBNull.Value;
            }
            this.UpdatePricingStrategyGridColumns();
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
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["Rate"], TextMaskFormatEnum.Rate);

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

        private void grdDetExchangeRates_AfterCellUpdate(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in this.frmTender.grdDetPriceComparison.Rows)
            {
                this.frmTender.grdDetPriceComparison.ActiveRow = row;
                this.SelectedWholesalerEditor_SelectionChanged(null, null);
            }
        }

        private void grdDetPricingStrategy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetPricingStrategy.DisplayLayout;
            UltraGridBand band = layout.Bands[0];

            WholesalerParameters pmtWholesaler = new WholesalerParameters();
            IEnumerable<Wholesaler> ieWholesalers 
                = this.srvWholesaler.GetListByParameters(pmtWholesaler);
            WindowsFormsUtil.SetUltraGridValueList<Wholesaler>(layout, ieWholesalers, 
                band.Columns["WholesalerId"], "WholesalerId", "Name", "Seleccione");
            band.Columns["WholesalerId"].CellActivation = Activation.ActivateOnly;

            ManufacturerParameters pmtManufacturer = new ManufacturerParameters();
            IEnumerable<Manufacturer> ieManufacturers 
                = this.srvManufacturer.GetListByParameters(pmtManufacturer);
            WindowsFormsUtil.SetUltraGridValueList<Manufacturer>(layout, ieManufacturers, 
                band.Columns["ManufacturerId"], "ManufacturerId", "Name", "Seleccione");
            band.Columns["ManufacturerId"].CellActivation = Activation.AllowEdit;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["Quantity"],
                TextMaskFormatEnum.NaturalQuantity);
            band.Columns["Quantity"].CellActivation = Activation.ActivateOnly;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["RealPrice"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["RealPrice"]);
            band.Columns["RealPrice"].CellActivation = Activation.AllowEdit;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["Warranties"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["Warranties"]);
            band.Columns["Warranties"].CellActivation = Activation.ActivateOnly;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["ExtraCosts"],
                TextMaskFormatEnum.Currency);
            band.Columns["ExtraCosts"].CellActivation = Activation.ActivateOnly;
            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["ExtraCosts"]);

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["ProfitMargin"],
                TextMaskFormatEnum.NoLimitPercentage);
            band.Columns["ProfitMargin"].CellActivation = Activation.AllowEdit;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["SelectedPrice"],
                TextMaskFormatEnum.Currency);
            band.Columns["SelectedPrice"].CellActivation = Activation.AllowEdit;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["TenderLineProfit"],
                TextMaskFormatEnum.Currency);
            band.Columns["TenderLineProfit"].CellActivation = Activation.ActivateOnly;
            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["TenderLineProfit"]);

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["TotalPriceAfterTax"],
                TextMaskFormatEnum.Currency);
            band.Columns["TotalPriceAfterTax"].CellActivation = Activation.ActivateOnly;
            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["TotalPriceAfterTax"]);

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["TotalPriceBeforeTax"],
                TextMaskFormatEnum.Currency);
            band.Columns["TotalPriceBeforeTax"].CellActivation = Activation.ActivateOnly;
            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["TotalPriceBeforeTax"]);

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["UnitPriceAfterTax"],
                TextMaskFormatEnum.Currency);
            band.Columns["UnitPriceAfterTax"].CellActivation = Activation.ActivateOnly;
            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["UnitPriceAfterTax"]);

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["UnitPriceBeforeTax"],
                TextMaskFormatEnum.Currency);
            band.Columns["UnitPriceBeforeTax"].CellActivation = Activation.ActivateOnly;
            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["UnitPriceBeforeTax"]);

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["UnitProfit"],
                TextMaskFormatEnum.Currency);
            band.Columns["UnitProfit"].CellActivation = Activation.ActivateOnly;
            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["UnitProfit"]);
        }

        private void grdDetPricingStrategy_AfterCellUpdate(object sender, EventArgs e)
        {
            UltraGridCell activeCell = this.frmTender.grdDetPricingStrategy.ActiveCell;

            if (activeCell != null && activeCell.Column.Key == "SelectedPrice"
                || activeCell.Column.Key == "ProfitMargin")
            {
                this.UpdatePricingStrategyGrid();
            }
            this.UpdatePricingStrategyGridColumns();
        }

        private void ubtnDetDeleteWarranty_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderWarranties.ActiveRow;

            if (activeRow == null) return;

            this.dtTenderWholesalers.Rows.Remove(((DataRowView)activeRow.ListObject).Row);
        }

        private void ubtnDetCreateWarranty_Click(object sender, EventArgs e)
        {
            DataRow newRow = this.dtTenderWarranties.NewRow();
            this.dtTenderWarranties.Rows.Add(newRow);
            newRow["WarrantyTypeId"] = -1;
            newRow["DocumentTypeWarrantyId"] = -1;
            this.dtTenderWarranties.AcceptChanges();
        }

        private void grdDetTenderWarranties_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetTenderWarranties.DisplayLayout;
            UltraGridBand band = layout.Bands[0];
            WarrantyTypeParameters pmtWarrantyType = new WarrantyTypeParameters();
            IList<WarrantyType> lstWarrantyTypes = this.srvWarrantyType.GetListByParameters(pmtWarrantyType);
            DocumentTypeWarrantyParameters pmtDocumentTypeWarranty = new DocumentTypeWarrantyParameters();
            IList<DocumentTypeWarranty> lstDocumentTypeWarranties
                = this.srvDocumentTypeWarranty.GetListByParameters(pmtDocumentTypeWarranty);

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;

            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["Amount"]);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["Amount"],
                TextMaskFormatEnum.Currency);

            WindowsFormsUtil.SetUltraGridValueList<WarrantyType>(layout, lstWarrantyTypes,
                band.Columns["WarrantyTypeId"], "WarrantyTypeId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList<DocumentTypeWarranty>(layout, lstDocumentTypeWarranties,
                band.Columns["DocumentTypeWarrantyId"], "DocumentTypeWarrantyId", "Name", "Seleccione");
        }

        private void grdDetTenderWarranties_AfterCellUpdate(object sender, EventArgs e)
        {
            UltraGridCell activeCell = this.frmTender.grdDetTenderWarranties.ActiveCell;

            if (activeCell == null)
                return;

            activeCell.Row.PerformAutoSize();

            this.UpdatePricingStrategyWarranties();
        }

        private void grdDetPreresults_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetPreresults.DisplayLayout;
            UltraGridBand band = layout.Bands[0];
            int columnName;

            layout.Override.AllowUpdate = DefaultableBoolean.False;

            band.Columns["TenderLineId"].Hidden = true;
            band.Columns["TenderLineName"].CellActivation = Activation.ActivateOnly;
            band.Columns["TenderLineName"].Header.Caption = "Partida";

            CurrencyParameters pmtCurrency = new CurrencyParameters();
            IList<Currency> lstCurrencies = this.srvCurrency.GetListByParameters(pmtCurrency);

            foreach (UltraGridColumn column in band.Columns.Cast<UltraGridColumn>()
                .Where(x => x.Key.EndsWith("C")))
            {
                WindowsFormsUtil.SetUltraGridValueList<Currency>(layout, lstCurrencies,
                        column, "CurrencyId", "Code", null);
                column.Editor.SelectionChanged
                    += new EventHandler(CurrencyEditor_SelectionChanged);
            }

            CompetitorParameters pmtCompetitor = new CompetitorParameters();
            IEnumerable<Competitor> ieCompetitors = this.srvCompetitor.GetListByParameters(pmtCompetitor)
                .Where(x => this.dtTenderCompetitors.AsEnumerable()
                    .Select(y => Convert.ToInt32(y["CompetitorId"]))
                    .Contains(x.CompetitorId));

            foreach (DataColumn col in this.dtPreresults.Columns.Cast<DataColumn>()
                .Where(x => int.TryParse(x.ColumnName, out columnName)))
            {
                band.Columns[col.ColumnName + "C"].Header.Caption = "Moneda";
                WindowsFormsUtil.SetUltraColumnFormat(band.Columns[col.ColumnName],
                    TextMaskFormatEnum.Currency);
                WindowsFormsUtil.AddUltraGridSummary(band, band.Columns[col.ColumnName]);

                band.Columns[col.ColumnName].Header.Caption
                    = this.GetCompetitor(Convert.ToInt32(col.ColumnName)).Name;
            }
        }

        private void grdDetPreresults_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
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

                this.tenderLineCompetitor = this.tender.TenderLines.SelectMany(x => x.TenderLineCompetitors)
                    .SingleOrDefault(x => x.TenderLine.TenderLineId == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value)
                    && x.Competitor.CompetitorId.ToString() == strColumnName
                    && x.Activated == true && x.Deleted == false);

                if (this.tenderLineCompetitor == null)
                {
                    this.tenderLineCompetitor = new TenderLineCompetitor();
                    TenderLine tenderLine = this.tender.TenderLines
                        .Single(x => x.TenderLineId == Convert.ToInt32(e.Cell.Row.Cells["TenderLineId"].Value));
                    tenderLine.TenderLineCompetitors.Add(this.tenderLineCompetitor);
                    this.tenderLineCompetitor.Currency
                        = this.GetCurrency(Convert.ToInt32(e.Cell.Row.Cells[strColumnName + "C"].Value));
                    this.tenderLineCompetitor.TenderLine = tenderLine;
                    this.tenderLineCompetitor.Competitor = this.GetCompetitor(Convert.ToInt32(strColumnName));
                    this.tenderLineCompetitor.Activated = true;
                    this.tenderLineCompetitor.Deleted = false;
                }

                this.ClearPreresultsControls();

                this.frmTender.uceDetPreresultCurrency.Value = this.GetCurrency(Convert.ToInt32(
                    e.Cell.Row.Cells[strColumnName + "C"].Value)).CurrencyId;
                this.frmTender.txtDetPreresultCompetitor.Value = e.Cell.Column.Header.Caption;
                this.frmTender.txtDetPreresultManufacturer.Value = this.tenderLineCompetitor.Manufacturer;
                this.frmTender.umskDetPreresultPrice.Value = this.tenderLineCompetitor.Price;
                this.frmTender.txtDetPreresultsComments.Value = this.tenderLineCompetitor.Description;

                this.ShowPreresultsDetail(true);
            }
        }

        private void ubtnDetDeletePreresult_Click(object sender, EventArgs e)
        {
            this.frmTender.grdDetPreresults.ActiveCell.Value = DBNull.Value;

            this.tenderLineCompetitor.Activated = false;
            this.tenderLineCompetitor.Deleted = true;

            this.ShowPreresultsDetail(false);
        }

        private void ubtnDetSavePreresult_Click(object sender, EventArgs e)
        {
            UltraGridCell activeCell = this.frmTender.grdDetPreresults.ActiveCell;

            string strColumnName = activeCell.Column.Key;

            if (activeCell.Column.Key.EndsWith("C"))
                strColumnName = strColumnName.Replace("C", "");

            this.tenderLineCompetitor.Price = this.frmTender.umskDetPreresultPrice.Text.Trim() == string.Empty ?
                null : (Nullable<Decimal>)Convert.ToDecimal(this.frmTender.umskDetPreresultPrice.Text) *
                this.GetExchangeRate(Convert.ToInt32(activeCell.Row.Cells[strColumnName + "C"].Value));
            this.tenderLineCompetitor.Manufacturer = this.frmTender.txtDetPreresultManufacturer.Text;
            this.tenderLineCompetitor.Description = this.frmTender.txtDetPreresultsComments.Text;
            this.tenderLineCompetitor.Currency
                = this.GetCurrency(Convert.ToInt32(this.frmTender.uceDetPreresultCurrency.Value));

            if (this.tenderLineCompetitor.Price == null)
                activeCell.Value = DBNull.Value;
            else
                activeCell.Value = this.tenderLineCompetitor.Price;

            activeCell.Row.Cells[strColumnName + "C"].Value
                = this.frmTender.uceDetPreresultCurrency.Value;

            this.ShowPreresultsDetail(false);
        }

        private void ubtnDetCancelPreresult_Click(object sender, EventArgs e)
        {
            this.ShowPreresultsDetail(false);
        }

        private void ubtnDetDeleteTenderFile_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderFiles.ActiveRow;

            if (activeRow == null)
                return;

            if (MessageBox.Show("¿Esta seguro de eliminar el archivo?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            TenderFile tenderFile = this.tender.TenderFiles.Single(x => x.TenderFileId
                == Convert.ToInt32(activeRow.Cells[0].Value));

            this.tender.TenderFiles.Remove(tenderFile);

            this.dtTenderFiles.Rows.Remove((activeRow.ListObject as DataRowView).Row);
            this.dtTenderFiles.AcceptChanges();

            this.ShowTenderFilesDetail(false);
        }

        private void ubtnDetNewTenderFile_Click(object sender, EventArgs e)
        {
            this.ClearTenderFilesDetail();
            this.ShowTenderFilesDetail(true);
        }

        private void ubtnDetCancelTenderFile_Click(object sender, EventArgs e)
        {
            this.ShowTenderFilesDetail(false);
        }

        private void ubtnDetCreateTenderFile_Click(object sender, EventArgs e)
        {
            try
            {
                TenderFile tenderFile = new TenderFile();

                tenderFile.TenderFileId = -tenderFile.GetHashCode();
                tenderFile.Description = this.frmTender.txtDetFileDescription.Text;
                tenderFile.Filename = this.frmTender.txtDetFileName.Text;
                tenderFile.File = FilesUtil.StreamFile(this.frmTender.txtDetFilePath.Text);
                tenderFile.FileSize = tenderFile.File.Length;
                tenderFile.TenderId = this.tender.TenderId;

                this.tender.TenderFiles.Add(tenderFile);

                DataRow row = this.dtTenderFiles.NewRow();
                this.dtTenderFiles.Rows.Add(row);

                row[0] = tenderFile.TenderFileId;
                row[1] = tenderFile.TenderId;
                row[3] = tenderFile.Filename;
                row[4] = tenderFile.Description;
                row[5] = Convert.ToDecimal(tenderFile.FileSize) / (1024M * 1024M);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("El archivo es demasiado grande, no se puede guardar en la Base de Datos.\n"
                    + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.ShowTenderFilesDetail(false);
        }

        private void grdDetTenderFiles_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetTenderFiles.DisplayLayout;
            UltraGridBand band = layout.Bands[0];

            layout.Override.AllowUpdate = DefaultableBoolean.False;
            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns[4].CellMultiLine = DefaultableBoolean.True;
            band.Columns[4].VertScrollBar = true;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns[5],
                TextMaskFormatEnum.FileSize);
        }

        private void btnDetSearchFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.frmTender.txtDetFilePath.Text = dialog.FileName;
                this.frmTender.txtDetFileName.Text = dialog.FileName
                    .Substring(dialog.FileName.LastIndexOf("\\") + 1);
            }
        }

        private void ubtnDetDeleteTenderLineExtraCost_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderLinesExtraCosts.ActiveRow;
            UltraGridBand bandTenderLineExtraCosts = this.frmTender
                .grdDetTenderLinesExtraCosts.DisplayLayout.Bands["drTenderLineExtraCosts"];

            if (activeRow != null && activeRow.Band == bandTenderLineExtraCosts)
            {
                TenderLine tenderLine = this.tender.TenderLines.SingleOrDefault(x =>
                    x.TenderLineId == Convert.ToInt32(activeRow.ParentRow.Cells["TenderLineId"].Value));

                if (tenderLine != null)
                {
                    TenderLineExtraCost tenderLineExtraCost = null;

                    if (Convert.ToInt32(activeRow.Cells["TenderLineExtraCostId"].Value) <= 0)
                        tenderLineExtraCost = tenderLine.TenderLineExtraCosts.SingleOrDefault(x =>
                            -x.GetHashCode() == Convert.ToInt32(activeRow.Cells["TenderLineExtraCostId"].Value));
                    else
                        tenderLineExtraCost = tenderLine.TenderLineExtraCosts.SingleOrDefault(x =>
                            x.TenderLineExtraCostId == Convert.ToInt32(activeRow.Cells["TenderLineExtraCostId"].Value));

                    if (tenderLineExtraCost.TenderLineExtraCostId <= 0)
                        tenderLine.TenderLineExtraCosts.Remove(tenderLineExtraCost);
                    else
                    {
                        tenderLineExtraCost.Deleted = true;
                        tenderLineExtraCost.Activated = false;
                    }

                    this.dtTenderLineExtraCosts.Rows.Remove((activeRow.ListObject as DataRowView).Row);
                }
            }
        }

        private void ubtnDetCreateTenderLineExtraCost_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderLinesExtraCosts.ActiveRow;

            if (activeRow != null)
            {
                activeRow = activeRow.ParentRow ?? activeRow;

                TenderLine tenderLine = this.tender.TenderLines.SingleOrDefault(x =>
                    x.TenderLineId == Convert.ToInt32(activeRow.Cells["TenderLineId"].Value));
                if (tenderLine != null)
                {
                    TenderLineExtraCost tenderLineExtraCost = new TenderLineExtraCost();
                    tenderLine.TenderLineExtraCosts.Add(tenderLineExtraCost);

                    tenderLineExtraCost.Activated = true;
                    tenderLineExtraCost.Deleted = false;
                    tenderLineExtraCost.Amount = 0M;
                    tenderLineExtraCost.Description = string.Empty;
                    tenderLineExtraCost.Name = string.Empty;
                    tenderLineExtraCost.TenderLine = tenderLine;

                    DataRow row = this.dtTenderLineExtraCosts.NewRow();

                    row["Amount"] = tenderLineExtraCost.Amount;
                    row["Description"] = tenderLineExtraCost.Description;
                    row["Name"] = tenderLineExtraCost.Name;
                    row["TenderLineId"] = tenderLineExtraCost.TenderLine.TenderLineId;

                    if (tenderLineExtraCost.TenderLineExtraCostId <= 0)
                        row["TenderLineExtraCostId"] = -tenderLineExtraCost.GetHashCode();
                    else
                        row["TenderLineExtraCostId"] = tenderLineExtraCost.TenderLineExtraCostId;

                    this.dtTenderLineExtraCosts.Rows.Add(row);
                }
            }
        }

        private void grdDetTenderLinesExtraCosts_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = this.frmTender.grdDetTenderLinesExtraCosts.DisplayLayout;
            UltraGridBand band = layout.Bands["drTenderLineExtraCosts"];
            UltraGridBand bandLines = layout.Bands["TenderLine"];

            bandLines.Columns["Name"].CellActivation = Activation.ActivateOnly;

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;

            WindowsFormsUtil.AddUltraGridSummary(band, band.Columns["Amount"]);

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["Amount"],
                TextMaskFormatEnum.Currency);

            this.UpdatePricingStrategyExtraCosts();
        }

        private void grdDetTenderLinesExtraCosts_AfterRowUpdate(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderLinesExtraCosts.ActiveRow;

            if (activeRow != null && activeRow.Band.Key == "drTenderLineExtraCosts")
            {
                TenderLineExtraCost tenderLineExtraCost = null;

                if (Convert.ToInt32(activeRow.Cells["TenderLineExtraCostId"].Value) <= 0)
                    tenderLineExtraCost = this.tender.TenderLines
                        .Single(x => x.TenderLineId == Convert.ToInt32(activeRow.Cells["TenderLineId"].Value))
                        .TenderLineExtraCosts.Single(x => -x.GetHashCode()
                            == Convert.ToInt32(activeRow.Cells["TenderLineExtraCostId"].Value));
                else
                    tenderLineExtraCost = this.tender.TenderLines
                        .Single(x => x.TenderLineId == Convert.ToInt32(activeRow.Cells["TenderLineId"].Value))
                        .TenderLineExtraCosts.Single(x => x.TenderLineExtraCostId
                            == Convert.ToInt32(activeRow.Cells["TenderLineExtraCostId"].Value));

                tenderLineExtraCost.Description = activeRow.Cells["Description"].Value.ToString();
                tenderLineExtraCost.Name = activeRow.Cells["Name"].Value.ToString();
                tenderLineExtraCost.Amount = Convert.ToDecimal(activeRow.Cells["Amount"].Value);

                this.UpdatePricingStrategyExtraCosts();
            }
        }

        private void uchkDetAddExtraCosts_CheckedChanged(object sender, EventArgs e)
        {
            UltraGridBand band = this.frmTender.grdDetPricingStrategy.DisplayLayout.Bands[0];

            this.tender.AddExtraCosts = this.frmTender.uchkDetAddExtraCosts.Checked;
            band.Columns["ExtraCosts"].Hidden = !this.tender.AddExtraCosts;
            this.UpdatePricingStrategyGrid();
        }

        private void uchkDetProrateWarranties_CheckedChanged(object sender, EventArgs e)
        {
            UltraGridBand band = this.frmTender.grdDetPricingStrategy.DisplayLayout.Bands[0];

            this.tender.ProrateWarranties = this.frmTender.uchkDetProrateWarranties.Checked;
            band.Columns["Warranties"].Hidden = !this.tender.ProrateWarranties;
            this.UpdatePricingStrategyGrid();
        }

        private void ubtnDetDownloadTenderFile_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdDetTenderFiles.ActiveRow;
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (activeRow == null)
                return;

            try
            {
                this.frmTender.Cursor = Cursors.WaitCursor;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int tenderFileId = Convert.ToInt32(activeRow.Cells[0].Value);

                    TenderFile tenderFile = tenderFileId > 0 ? this.srvTenderFile.GetById(tenderFileId)
                        : this.tender.TenderFiles.Single(x => x.TenderFileId == tenderFileId);

                    string fullFileName = dialog.SelectedPath + Path.DirectorySeparatorChar + tenderFile.Filename;

                    if (File.Exists(fullFileName) && MessageBox.Show("El archivo ya existe, ¿Desea sobreescribirlo?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    File.WriteAllBytes(fullFileName, tenderFile.File);
                }
            }
            finally
            {
                this.frmTender.Cursor = Cursors.Default;
            }
        }

        #endregion Events
    }
}
