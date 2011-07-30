
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

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class TenderFormController
    {
        #region Attributes

        private TenderForm frmTendering;
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
            this.frmTendering = instance;
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

            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceSchAsesor,
                lstAsesors, "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceDetAsesor,
                lstAsesors, "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceDetApprovedBy,
                lstAsesors.Where(x => x.CanApprove == true), "AsesorId", "Name");

            // TenderStatus
            TenderStatusParameters pmtTenderStatus = new TenderStatusParameters();
            IList<TenderStatus> lstTenderStatuses = srvTenderStatus.GetListByParameters(pmtTenderStatus);

            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTendering.uceSchTenderStatus,
                lstTenderStatuses, "TenderStatusId", "Name");
            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTendering.uceDetTenderStatus,
                lstTenderStatuses, "TenderStatusId", "Name");

            // Bidder
            BidderParameters pmtBidder = new BidderParameters();
            IList<Bidder> lstBidders = srvBidder.GetListByParameters(pmtBidder);

            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTendering.uceSchBidder,
                lstBidders, "BidderId", "Name");
            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTendering.uceDetBidder,
                lstBidders, "BidderId", "Name");

            this.frmTendering.uceSchBidder.ValueChanged += new EventHandler(uceSchBidder_ValueChanged);
            this.frmTendering.uceDetBidder.ValueChanged += new EventHandler(uceDetBidder_ValueChanged);

            // Dependency
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = ParameterConstants.IntNone;
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceSchDependency,
                lstDependencies, "DependencyId", "Name");
            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceDetDependency,
                lstDependencies, "DependencyId", "Name");

            this.frmTendering.uceSchDependency.ValueChanged += new EventHandler(uceSchDependency_ValueChanged);
            this.frmTendering.uceDetDependency.ValueChanged += new EventHandler(uceDetDependency_ValueChanged);

            // EndUser
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = ParameterConstants.IntNone;
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceSchEndUser,
                lstEndUsers, "EndUserId", "Name");
            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceDetEndUser,
                lstEndUsers, "EndUserId", "Name");

            //grdTenderLines
            this.frmTendering.grdTenderLines.InitializeLayout 
                += new InitializeLayoutEventHandler(grdTenderLines_InitializeLayout);
            this.frmTendering.grdTenderLines.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdTenderLines_BeforeCellUpdate);
            TenderLineParameters pmtTenderLine = new TenderLineParameters();
            pmtTenderLine.TenderId = ParameterConstants.IntNone;
            this.dtTenderLines = this.srvTender.SearchTenderLines(pmtTenderLine);
            this.frmTendering.grdTenderLines.DataSource = null;
            this.frmTendering.grdTenderLines.DataSource = dtTenderLines;

            //grdDetTenderManufacturers
            this.frmTendering.grdDetTenderManufacturers.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderManufacturers_InitializeLayout);
            this.frmTendering.grdDetTenderManufacturers.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdDetTenderManufacturers_BeforeCellUpdate);
            TenderManufacturerParameters pmtSearchTenderManufacturers
                = new TenderManufacturerParameters();
            pmtSearchTenderManufacturers.TenderId = ParameterConstants.IntDefault;
            this.dtTenderManufacturers =
                this.srvTender.SearchTenderManufacturers(pmtSearchTenderManufacturers);
            this.frmTendering.grdDetTenderManufacturers.DataSource = null;
            this.frmTendering.grdDetTenderManufacturers.DataSource = dtTenderManufacturers;

            this.frmTendering.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmTendering.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmTendering.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmTendering.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmTendering.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmTendering.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);
            this.frmTendering.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmTendering.ubtnDetDeleteManufacturer.Click +=
                new EventHandler(ubtnDetDeleteManufacturer_Click);
            this.frmTendering.ubtnDetNewManufacturer.Click +=
                new EventHandler(ubtnDetNewManufacturer_Click);
            this.frmTendering.ubtnDetCreateLine.Click += new EventHandler(ubtnDetCreateLine_Click);
            this.frmTendering.ubtnDetDeleteLine.Click += new EventHandler(ubtnDetDeleteLine_Click);
            this.frmTendering.uchkDetIsOpportunity.CheckedChanged +=
                new EventHandler(uchkDetIsOpportunity_CheckedChanged);

            this.hiddenTenderDetailTab = this.frmTendering.tabDetDetail.TabPages["TenderDetails"];
            this.frmTendering.uosSchDates.Value = -1;
            this.frmTendering.uchkDetIsOpportunity.Checked = true;
            this.frmTendering.HiddenDetail(true);

            this.frmTendering.tscPreviousTender.DisplayMember = "Name";
            this.frmTendering.tscPreviousTender.SearchForm = this.frmTendering;
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmTendering.HiddenDetail(!show);
            if (show)
                this.frmTendering.tabPrincipal.SelectedTab = this.frmTendering.tabPrincipal.TabPages["New"];
            else
                this.frmTendering.tabPrincipal.SelectedTab = this.frmTendering.tabPrincipal.TabPages["Search"];
            this.frmTendering.tabDetDetail.SelectedTab = this.frmTendering.tabDetDetail.TabPages["Principal"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmTendering.uceDetBidder.Value == null ||
                Convert.ToInt32(this.frmTendering.uceDetBidder.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Licitante.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTendering.tabDetDetail.SelectedTab = 
                    this.frmTendering.tabDetDetail.TabPages["Principal"];
                this.frmTendering.uceDetBidder.Focus();
                return false;
            }

            if (this.frmTendering.txtDetTenderName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Licitación.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTendering.tabDetDetail.SelectedTab = 
                    this.frmTendering.tabDetDetail.TabPages["Principal"];
                this.frmTendering.txtDetTenderName.Focus();
                return false;
            }

            foreach (DataRow row in this.dtTenderLines.Rows)
            {
                if (Convert.ToInt32(row["ManufacturerId"]) == -1)
                {
                    MessageBox.Show(
                        "Debe seleccionar un fabricante por renglon en la lista de fabricantes.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTendering.tabDetDetail.SelectedTab =
                        this.frmTendering.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTendering.tcDetTextControls.SelectedTab =
                        this.frmTendering.tcDetTextControls.TabPages["Manufacturers"];
                    return false;
                }
            }

            foreach (DataRow row in this.dtTenderManufacturers.Rows)
            {
                if (Convert.ToInt32(row["ManufacturerId"]) == -1)
                {
                    MessageBox.Show("Debe seleccionar un fabricante por partida.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTendering.tabDetDetail.SelectedTab =
                        this.frmTendering.tabDetDetail.TabPages["TenderDetails"];
                    this.frmTendering.tcDetTextControls.SelectedTab =
                        this.frmTendering.tcDetTextControls.TabPages["TenderLines"];
                    return false;
                }
            }

            return true;
        }

        private void LoadEntity()
        {
            if (Convert.ToInt32(this.frmTendering.uceDetBidder.Value) > 0)
            {
                Bidder bidder = srvBidder.GetById(
                    Convert.ToInt32(this.frmTendering.uceDetBidder.Value));
                Assert.IsNotNull(bidder);
                this.tender.Bidder = bidder;
            }
            if (Convert.ToInt32(this.frmTendering.uceDetDependency.Value) > 0)
            {
                Dependency dependency = srvDependency.GetById(
                    Convert.ToInt32(this.frmTendering.uceDetDependency.Value));
                Assert.IsNotNull(dependency);
                this.tender.Dependency = dependency;
            }

            if (Convert.ToInt32(this.frmTendering.uceDetEndUser.Value) > 0)
            {
                EndUser endUser = srvEndUser.GetById(
                    Convert.ToInt32(this.frmTendering.uceDetEndUser.Value));
                Assert.IsNotNull(endUser);
                this.tender.EndUser = endUser;
            }

            if (Convert.ToInt32(this.frmTendering.uceDetAsesor.Value) > 0)
            {
                Asesor asesor = srvAsesor.GetById(
                    Convert.ToInt32(this.frmTendering.uceDetAsesor.Value));
                Assert.IsNotNull(asesor);
                this.tender.Asesor = asesor;
            }

            if (Convert.ToInt32(this.frmTendering.uceDetApprovedBy.Value) > 0)
            {
                Asesor asesor = srvAsesor.GetById(
                    Convert.ToInt32(this.frmTendering.uceDetApprovedBy.Value));
                Assert.IsNotNull(asesor);
                this.tender.ApprovedBy = asesor;
            }

            if (Convert.ToInt32(this.frmTendering.uceDetTenderStatus.Value) > 0)
            {
                TenderStatus tenderStatus = srvTenderStatus.GetById(
                    Convert.ToInt32(this.frmTendering.uceDetTenderStatus.Value));
                Assert.IsNotNull(tenderStatus);
                this.tender.TenderStatus = tenderStatus;
            }

            this.tender.IsOpportunity = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.tender.ClarificationDate = this.frmTendering.dteDetClarificationDate.DateTime;
            this.tender.Deadline = this.frmTendering.dteDetDeadline.DateTime;
            this.tender.PreRevisionDate = this.frmTendering.dteDetPrerevisionDate.DateTime;
            this.tender.RegistrationDate = this.frmTendering.dteDetRegistrationDate.DateTime;
            this.tender.VerdictDate = this.frmTendering.dteDetVeredictDate.DateTime;
            this.tender.Address = this.frmTendering.txtDetAddress.Text;
            this.tender.AcquisitionReason = this.frmTendering.txtDetAcquisitionReason.Text;
            this.tender.PricingStrategy = this.frmTendering.txtDetPricingStrategy.Text;
            this.tender.Results = this.frmTendering.txtDetResults.Text;
            this.tender.PreResults = this.frmTendering.txtDetPreResults.Text;
            this.tender.Name = this.frmTendering.txtDetTenderName.Text;
            this.tender.PreviousTender = this.frmTendering.tscPreviousTender.Value;

            this.GetByIds();
            this.GetByIdLines();

            this.tender.Activated = true;
            this.tender.Deleted = false;
        }

        private void GetByIdLines()
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

        private void GetByIds()
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
            this.frmTendering.uceDetApprovedBy.Value = -1;
            this.frmTendering.uceDetAsesor.Value = -1;
            this.frmTendering.uceDetBidder.Value = -1;
            this.frmTendering.uceDetDependency.Value = -1;
            this.frmTendering.uceDetEndUser.Value = -1;
            this.frmTendering.uceDetTenderStatus.Value = -1;
            this.frmTendering.txtDetAcquisitionReason.Text = string.Empty;
            this.frmTendering.txtDetAddress.Text = string.Empty;
            this.frmTendering.txtDetPreResults.Text = string.Empty;
            this.frmTendering.txtDetPricingStrategy.Text = string.Empty;
            this.frmTendering.txtDetResults.Text = string.Empty;
            this.frmTendering.txtDetTenderName.Text = string.Empty;
            this.frmTendering.dteDetClarificationDate.DateTime = DateTime.Now;
            this.frmTendering.dteDetDeadline.DateTime = DateTime.Now;
            this.frmTendering.dteDetPrerevisionDate.DateTime = DateTime.Now;
            this.frmTendering.dteDetRegistrationDate.DateTime = DateTime.Now;
            this.frmTendering.dteDetVeredictDate.DateTime = DateTime.Now;
            this.frmTendering.uchkDetIsOpportunity.Checked = true;
            this.frmTendering.tscPreviousTender.Clear();
            this.dtTenderLines.Rows.Clear();
            this.dtTenderManufacturers.Rows.Clear();
        }

        private void ClearSearchControls()
        {
            this.frmTendering.txtSchTenderName.Text = string.Empty;
            this.frmTendering.uceSchAsesor.Value = -1;
            this.frmTendering.uceSchBidder.Value = -1;
            this.frmTendering.uceSchDependency.Value = -1;
            this.frmTendering.uceSchEndUser.Value = -1;
            this.frmTendering.uceSchTenderStatus.Value = -1;
            this.frmTendering.uosSchDates.Value = -1;
            this.frmTendering.dteSchMaxDate.DateTime = DateTime.Now;
            this.frmTendering.dteSchMinDate.DateTime = DateTime.Now;
        }

        private void SaveTender()
        {
            if (MessageBox.Show("¿Esta seguro de guardar la Licitación?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            if (this.ValidateFormInformation())
            {
                this.LoadEntity();
                this.srvTender.SaveOrUpdate(this.tender);
                this.frmTendering.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditTender(int tenderId)
        {
            this.tender = this.srvTender.GetById(tenderId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmTendering.HiddenDetail(false);
            this.ShowDetail(true);
            this.Search();
        }

        private void LoadFormFromEntity()
        {
            this.frmTendering.uceDetApprovedBy.Value = 
                this.tender.ApprovedBy == null ? -1 : this.tender.ApprovedBy.AsesorId;
            this.frmTendering.uceDetAsesor.Value =
                this.tender.Asesor == null ? -1 : this.tender.Asesor.AsesorId;
            this.frmTendering.uceDetBidder.Value =
                this.tender.Bidder == null ? -1 : this.tender.Bidder.BidderId;
            this.frmTendering.uceDetDependency.Value =
                this.tender.Dependency == null ? -1 : this.tender.Dependency.DependencyId;
            this.frmTendering.uceDetEndUser.Value =
                this.tender.EndUser == null ? -1 : this.tender.EndUser.EndUserId;
            this.frmTendering.uceDetTenderStatus.Value =
                this.tender.TenderStatus == null ? -1 : this.tender.TenderStatus.TenderStatusId;
            this.frmTendering.txtDetAcquisitionReason.Text = this.tender.AcquisitionReason;
            this.frmTendering.txtDetAddress.Text = this.tender.Address;
            this.frmTendering.txtDetPreResults.Text = this.tender.PreResults;
            this.frmTendering.txtDetPricingStrategy.Text = this.tender.PricingStrategy;
            this.frmTendering.txtDetResults.Text = this.tender.Results;
            this.frmTendering.txtDetTenderName.Text = this.tender.Name;
            this.frmTendering.dteDetClarificationDate.DateTime = this.tender.ClarificationDate;
            this.frmTendering.dteDetDeadline.DateTime = this.tender.Deadline;
            this.frmTendering.dteDetPrerevisionDate.DateTime = this.tender.PreRevisionDate;
            this.frmTendering.dteDetRegistrationDate.DateTime = this.tender.RegistrationDate;
            this.frmTendering.dteDetVeredictDate.DateTime = this.tender.VerdictDate;
            this.frmTendering.uchkDetIsOpportunity.Checked = this.tender.IsOpportunity;
            this.frmTendering.tscPreviousTender.Value = this.tender.PreviousTender;

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

            pmtTender.MinDate = (DateTime)this.frmTendering.dteSchMinDate.Value;
            pmtTender.MaxDate = (DateTime)this.frmTendering.dteSchMaxDate.Value;
            pmtTender.AsesorId = (int)this.frmTendering.uceSchAsesor.Value;
            pmtTender.BidderId = (int)this.frmTendering.uceSchBidder.Value;
            pmtTender.DependencyId = (int)this.frmTendering.uceSchDependency.Value;
            pmtTender.TenderStatusId = (int)this.frmTendering.uceSchTenderStatus.Value;
            pmtTender.TenderName = "%" + this.frmTendering.txtSchTenderName.Text + "%";
            pmtTender.DateTypeSearchId = (DateTypeSearchEnum)this.frmTendering.uosSchDates.Value;

            DataTable dtTenders = srvTender.SearchByParameters(pmtTender);

            this.frmTendering.grdSchSearch.DataSource = null;
            this.frmTendering.grdSchSearch.DataSource = dtTenders;
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
            UltraGridLayout layout = this.frmTendering.grdTenderLines.DisplayLayout;
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
            UltraGridLayout layout = this.frmTendering.grdDetTenderManufacturers.DisplayLayout;
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
            UltraGridRow activeRow = this.frmTendering.grdDetTenderManufacturers.ActiveRow;
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
            UltraGridRow activeRow = this.frmTendering.grdDetTenderManufacturers.ActiveRow;

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
            UltraGridRow activeRow = this.frmTendering.grdTenderLines.ActiveRow;

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
            this.frmTendering.HiddenDetail(true);
        }
        
        private void uchkDetIsOpportunity_CheckedChanged(object sender, EventArgs e)
        {
            this.frmTendering.txtDetAddress.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.dteDetVeredictDate.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.uceDetApprovedBy.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.dteDetClarificationDate.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.dteDetClarificationDate.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;

            if (this.frmTendering.uchkDetIsOpportunity.Checked)
                this.frmTendering.tabDetDetail.TabPages.Remove(this.hiddenTenderDetailTab);
            else if (!this.frmTendering.tabDetDetail.TabPages.ContainsKey("TenderDetails"))
                this.frmTendering.tabDetDetail.TabPages.Add(this.hiddenTenderDetailTab);
        }

        private void uceSchBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = Convert.ToInt32(this.frmTendering.uceSchBidder.Value);
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceSchDependency,
                lstDependencies, "DependencyId", "Name");
        }

        private void uceDetBidder_ValueChanged(object sender, EventArgs e)
        {
            DependencyParameters pmtDependency = new DependencyParameters();
            pmtDependency.BidderId = Convert.ToInt32(this.frmTendering.uceDetBidder.Value);
            IList<Dependency> lstDependencies = srvDependency.GetListByParameters(pmtDependency);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceDetDependency,
                lstDependencies, "DependencyId", "Name");
        }

        private void uceSchDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = Convert.ToInt32(this.frmTendering.uceSchDependency.Value);
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceSchEndUser,
                lstEndUsers, "EndUserId", "Name");
        }
        
        private void uceDetDependency_ValueChanged(object sender, EventArgs e)
        {
            EndUserParameters pmtEndUser = new EndUserParameters();
            pmtEndUser.DependencyId = Convert.ToInt32(this.frmTendering.uceDetDependency.Value);
            IList<EndUser> lstEndUsers = srvEndUser.GetListByParameters(pmtEndUser);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceDetEndUser,
                lstEndUsers, "EndUserId", "Name");
        }

        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTendering.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditTender(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTendering.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        #endregion Events
    }
}
