﻿
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
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.Support.Util;
using Iesi.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class TenderFormController
    {
        #region Attributes

        private TenderForm frmTender;
        private Tender tender;
        private IBidderService srvBidder;
        private IAsesorService srvAsesor;
        private ITenderStatusService srvTenderStatus;
        private IDependencyService srvDependency;
        private ITenderService srvTender;
        private IEndUserService srvEndUser;
        private IManufacturerService srvManufacturer;
        private DataTable dtTenderLines;
        private DataTable dtTenderManufacturers;
        private TabPage hiddenTenderDetailTab;

        #endregion Attributes

        #region Constructor

        public TenderFormController(TenderForm instance)
        {
            this.frmTender = instance;
            this.srvBidder = SamsaraAppContext.Resolve<IBidderService>();
            Assert.IsNotNull(srvBidder);
            this.srvAsesor = SamsaraAppContext.Resolve<IAsesorService>();
            Assert.IsNotNull(srvAsesor);
            this.srvTenderStatus = SamsaraAppContext.Resolve<ITenderStatusService>();
            Assert.IsNotNull(srvTenderStatus);
            this.srvDependency = SamsaraAppContext.Resolve<IDependencyService>();
            Assert.IsNotNull(srvDependency);
            this.srvTender = SamsaraAppContext.Resolve<ITenderService>();
            Assert.IsNotNull(srvTender);
            this.srvEndUser = SamsaraAppContext.Resolve<IEndUserService>();
            Assert.IsNotNull(srvEndUser);
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
            this.frmTender.grdTenderLines.InitializeLayout 
                += new InitializeLayoutEventHandler(grdTenderLines_InitializeLayout);
            this.frmTender.grdTenderLines.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdTenderLines_BeforeCellUpdate);
            TenderLineParameters pmtTenderLine = new TenderLineParameters();
            pmtTenderLine.TenderId = ParameterConstants.IntNone;
            this.dtTenderLines = this.srvTender.SearchTenderLines(pmtTenderLine);
            this.frmTender.grdTenderLines.DataSource = null;
            this.frmTender.grdTenderLines.DataSource = dtTenderLines;

            //grdDetTenderManufacturers
            this.frmTender.grdDetTenderManufacturers.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderManufacturers_InitializeLayout);
            this.frmTender.grdDetTenderManufacturers.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdDetTenderManufacturers_BeforeCellUpdate);
            TenderManufacturerParameters pmtSearchTenderManufacturers
                = new TenderManufacturerParameters();
            pmtSearchTenderManufacturers.TenderId = ParameterConstants.IntDefault;
            this.dtTenderManufacturers =
                this.srvTender.SearchTenderManufacturers(pmtSearchTenderManufacturers);
            this.frmTender.grdDetTenderManufacturers.DataSource = null;
            this.frmTender.grdDetTenderManufacturers.DataSource = dtTenderManufacturers;

            this.frmTender.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmTender.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmTender.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmTender.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmTender.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmTender.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);
            this.frmTender.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmTender.ubtnDetDeleteManufacturer.Click +=
                new EventHandler(ubtnDetDeleteManufacturer_Click);
            this.frmTender.ubtnDetNewManufacturer.Click +=
                new EventHandler(ubtnDetNewManufacturer_Click);
            this.frmTender.ubtnDetCreateLine.Click += new EventHandler(ubtnDetCreateLine_Click);
            this.frmTender.ubtnDetDeleteLine.Click += new EventHandler(ubtnDetDeleteLine_Click);

            this.hiddenTenderDetailTab = this.frmTender.tabDetDetail.TabPages["TenderDetails"];
            this.frmTender.uosSchDates.Value = -1;
            this.frmTender.HiddenDetail(true);

            this.frmTender.tscPreviousTender.DisplayMember = "Name";
            this.frmTender.tscPreviousTender.SearchForm = this.frmTender;
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
                    MessageBox.Show(
                        "Debe seleccionar un fabricante por renglon en la lista de fabricantes.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTender.tabDetDetail.SelectedTab =
                        this.frmTender.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTender.tcDetTextControls.SelectedTab =
                        this.frmTender.tcDetTextControls.TabPages["Manufacturers"];
                    return false;
                }
            }

            foreach (DataRow row in this.dtTenderManufacturers.Rows)
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
            }

            return true;
        }

        private void LoadEntity()
        {
            if (Convert.ToInt32(this.frmTender.uceDetBidder.Value) > 0)
            {
                Bidder bidder = srvBidder.GetById(
                    Convert.ToInt32(this.frmTender.uceDetBidder.Value));
                Assert.IsNotNull(bidder);
                this.tender.Bidder = bidder;
            }
            if (Convert.ToInt32(this.frmTender.uceDetDependency.Value) > 0)
            {
                Dependency dependency = srvDependency.GetById(
                    Convert.ToInt32(this.frmTender.uceDetDependency.Value));
                Assert.IsNotNull(dependency);
                this.tender.Dependency = dependency;
            }

            if (Convert.ToInt32(this.frmTender.uceDetEndUser.Value) > 0)
            {
                EndUser endUser = srvEndUser.GetById(
                    Convert.ToInt32(this.frmTender.uceDetEndUser.Value));
                Assert.IsNotNull(endUser);
                this.tender.EndUser = endUser;
            }

            if (Convert.ToInt32(this.frmTender.uceDetAsesor.Value) > 0)
            {
                Asesor asesor = srvAsesor.GetById(
                    Convert.ToInt32(this.frmTender.uceDetAsesor.Value));
                Assert.IsNotNull(asesor);
                this.tender.Asesor = asesor;
            }

            if (Convert.ToInt32(this.frmTender.uceDetApprovedBy.Value) > 0)
            {
                Asesor asesor = srvAsesor.GetById(
                    Convert.ToInt32(this.frmTender.uceDetApprovedBy.Value));
                Assert.IsNotNull(asesor);
                this.tender.ApprovedBy = asesor;
            }

            if (Convert.ToInt32(this.frmTender.uceDetTenderStatus.Value) > 0)
            {
                TenderStatus tenderStatus = srvTenderStatus.GetById(
                    Convert.ToInt32(this.frmTender.uceDetTenderStatus.Value));
                Assert.IsNotNull(tenderStatus);
                this.tender.TenderStatus = tenderStatus;
            }

            this.tender.ClarificationDate = (Nullable<DateTime>)this.frmTender.dteDetClarificationDate.Value;
            this.tender.Deadline = (Nullable<DateTime>)this.frmTender.dteDetDeadline.Value;
            this.tender.PreRevisionDate = (Nullable<DateTime>)this.frmTender.dteDetPrerevisionDate.Value;
            this.tender.RegistrationDate = (Nullable<DateTime>)this.frmTender.dteDetRegistrationDate.Value;
            this.tender.VerdictDate = (Nullable<DateTime>)this.frmTender.dteDetVeredictDate.Value;
            this.tender.Address = this.frmTender.txtDetAddress.Text;
            this.tender.AcquisitionReason = this.frmTender.txtDetAcquisitionReason.Text;
            this.tender.PricingStrategy = this.frmTender.txtDetPricingStrategy.Text;
            this.tender.Results = this.frmTender.txtDetResults.Text;
            this.tender.PreResults = this.frmTender.txtDetPreResults.Text;
            this.tender.Name = this.frmTender.txtDetTenderName.Text;
            this.tender.PreviousTender = this.frmTender.tscPreviousTender.Value;

            this.GetTenderManufacturers();
            this.GetTenderLines();

            this.tender.Activated = true;
            this.tender.Deleted = false;
        }

        private void GetTenderLines()
        {
            if (this.tender.TenderLines != null)
                foreach (TenderLine tenderLine in this.tender.TenderLines)
                {
                    tenderLine.Deleted = true;
                    tenderLine.Activated = false;
                }

            foreach (DataRow row in this.dtTenderLines.Rows)
            {
                TenderLine tenderLine = this.tender.TenderLines
                    .SingleOrDefault(x => row["TenderLineId"] != DBNull.Value &&
                        x.TenderId == Convert.ToInt32(row["TenderLineId"]));

                if (tenderLine == null)
                {
                    tenderLine = new TenderLine();
                    this.tender.TenderLines.Add(tenderLine);
                }

                tenderLine.Cost = Convert.ToDecimal(row["Cost"]);
                tenderLine.Description = row["Description"].ToString();
                tenderLine.ManufacturerId = Convert.ToInt32(row["ManufacturerId"]);
                tenderLine.Name = row["Name"].ToString();
                tenderLine.Quantity = Convert.ToDecimal(row["Quantity"]);
                tenderLine.Activated = true;
                tenderLine.Deleted = false;
            }
        }

        private void GetTenderManufacturers()
        {
            if (this.tender.TenderManufacturers != null)
                foreach (TenderManufacturer tenderManufacturer in this.tender.TenderManufacturers)
                {
                    tenderManufacturer.Deleted = true;
                    tenderManufacturer.Activated = false;
                }

            foreach (DataRow row in this.dtTenderManufacturers.Rows)
            {
                TenderManufacturer tenderManufacturer = this.tender.TenderManufacturers
                    .SingleOrDefault(x => x.ManufacturerId == Convert.ToInt32(row["ManufacturerId"]));

                if (tenderManufacturer == null)
                    tenderManufacturer = new TenderManufacturer();

                tenderManufacturer.FolioReference = row["FolioReference"].ToString();
                tenderManufacturer.ManufacturerId = Convert.ToInt32(row["ManufacturerId"]);
                tenderManufacturer.ManufacturerSupport = row["ManufacturerSupport"].ToString();
                tenderManufacturer.Deleted = false;
                tenderManufacturer.Activated = true;

                this.tender.TenderManufacturers.Add(tenderManufacturer);
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
            this.frmTender.txtDetPreResults.Text = string.Empty;
            this.frmTender.txtDetPricingStrategy.Text = string.Empty;
            this.frmTender.txtDetResults.Text = string.Empty;
            this.frmTender.txtDetTenderName.Text = string.Empty;
            this.frmTender.dteDetClarificationDate.Value = null;
            this.frmTender.dteDetDeadline.Value = null;
            this.frmTender.dteDetPrerevisionDate.Value = null;
            this.frmTender.dteDetRegistrationDate.Value = null;
            this.frmTender.dteDetVeredictDate.Value = null;
            this.frmTender.tscPreviousTender.Clear();
            this.dtTenderLines.Rows.Clear();
            this.dtTenderManufacturers.Rows.Clear();
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
            this.Search();
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
            this.frmTender.txtDetPreResults.Text = this.tender.PreResults;
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

            foreach (TenderLine tenderLine in this.tender.TenderLines)
            {
                DataRow row = this.dtTenderLines.NewRow();
                this.dtTenderLines.Rows.Add(row);

                row["Cost"] = tenderLine.Cost;
                row["Description"] = tenderLine.Description;
                row["ManufacturerId"] = tenderLine.ManufacturerId;
                row["Name"] = tenderLine.Name;
                row["Quantity"] = tenderLine.Quantity;
                row["TenderId"] = tenderLine.TenderId;
                row["TenderLineId"] = tenderLine.TenderLineId;
            }

            foreach (TenderManufacturer tenderManufacturer in this.tender.TenderManufacturers)
            {
                DataRow row = this.dtTenderManufacturers.NewRow();
                this.dtTenderManufacturers.Rows.Add(row);

                row["FolioReference"] = tenderManufacturer.FolioReference;
                row["ManufacturerId"] = tenderManufacturer.ManufacturerId;
                row["ManufacturerSupport"] = tenderManufacturer.ManufacturerSupport;
                row["TenderId"] = tenderManufacturer.TenderId;
            }
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
            pmtTender.TenderStatusId = (int)this.frmTender.uceSchTenderStatus.Value;
            pmtTender.TenderName = "%" + this.frmTender.txtSchTenderName.Text + "%";
            pmtTender.DateTypeSearchId = (DateTypeSearchEnum)this.frmTender.uosSchDates.Value;

            DataTable dtTenders = srvTender.SearchByParameters(pmtTender);

            this.frmTender.grdSchSearch.DataSource = null;
            this.frmTender.grdSchSearch.DataSource = dtTenders;
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
            UltraGridLayout layout = this.frmTender.grdTenderLines.DisplayLayout;
            UltraGridBand band = layout.Bands[0];
            ManufacturerParameters pmtManufacturer = new ManufacturerParameters();
            IList<Manufacturer> lstManufacturers = this.srvManufacturer.GetListByParameters(pmtManufacturer);

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["TenderLineId"].CellActivation = Activation.ActivateOnly;
            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;

            IEnumerable<Manufacturer> availableManufacturers = this.tender == null || 
                this.tender.TenderManufacturers == null ? lstManufacturers.Where(x => false) : 
                lstManufacturers.Where(x => this.tender.TenderManufacturers
                    .Select(y => y.ManufacturerId).Contains(x.ManufacturerId));

            WindowsFormsUtil.SetUltraGridValueList<Manufacturer>(layout,
                availableManufacturers, band, "ManufacturerId", "Name");
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
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["ManufacturerSupport"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["ManufacturerSupport"].VertScrollBar = true;
            ManufacturerParameters pmtManufacturer = new ManufacturerParameters();
            IList<Manufacturer> lstManufacturers = this.srvManufacturer.GetListByParameters(pmtManufacturer);

            WindowsFormsUtil.SetUltraGridValueList<Manufacturer>(layout, lstManufacturers, band,
                "ManufacturerId", "Name");
        }

        private void grdDetTenderManufacturers_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            e.Cell.Row.PerformAutoSize();
            UltraGridRow activeRow = this.frmTender.grdDetTenderManufacturers.ActiveRow;
            if (activeRow == null) return;

            if (e.Cell.Column.Key == "ManufacturerId" && Convert.ToInt32(e.NewValue) != -1)
            {
                if (this.dtTenderManufacturers.AsEnumerable().SingleOrDefault(x =>
                    Convert.ToInt32(x["ManufacturerId"]) == Convert.ToInt32(e.NewValue)) != null)
                {
                    e.Cancel = true;
                    MessageBox.Show("Ya se encuentra ese Fabricante en esta Licitación!", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    TenderManufacturer tenderManufacturer = this.tender.TenderManufacturers
                        .SingleOrDefault(x => x.ManufacturerId == Convert.ToInt32(e.Cell.Value));

                    if (tenderManufacturer != null)
                        tenderManufacturer.ManufacturerId = Convert.ToInt32(e.NewValue);
                    else
                    {
                        tenderManufacturer = new TenderManufacturer();
                        tenderManufacturer.ManufacturerId = Convert.ToInt32(e.NewValue);
                        this.tender.TenderManufacturers.Add(tenderManufacturer);
                    }
                }
            }
        }

        private void ubtnDetNewManufacturer_Click(object sender, EventArgs e)
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
            this.dtTenderLines.AcceptChanges();
        }

        private void ubtnDetDeleteLine_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTender.grdTenderLines.ActiveRow;

            if (activeRow == null) return;

            if (activeRow.Cells["TenderLineId"].Value != DBNull.Value &&
                Convert.ToInt32(activeRow.Cells["TenderLineId"].Value) > 0)
            {
                int tenderLineId = Convert.ToInt32(activeRow.Cells["TenderLineId"].Value);
            }

            this.dtTenderLines.Rows.Remove(((DataRowView)activeRow.ListObject).Row);
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

        #endregion Events
    }
}
