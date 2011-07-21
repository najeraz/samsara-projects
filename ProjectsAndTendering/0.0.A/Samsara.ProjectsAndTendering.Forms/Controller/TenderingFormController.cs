
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
    public class TenderingFormController
    {
        #region Attributes

        private TenderingForm frmTendering;
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

        public TenderingFormController(TenderingForm instance)
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
            Dictionary<int, Asesor> dicAsesors = srvAsesor.LoadAsesors();

            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceSchAsesor,
                dicAsesors.Values, "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceDetAsesor,
                dicAsesors.Values, "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceDetApprovedBy,
                dicAsesors.Values.Where(x => x.CanApprove == true).ToList(), "AsesorId", "Name");

            // TenderStatus
            Dictionary<int, TenderStatus> dicTenderStatuses = srvTenderStatus.LoadTenderStatuses();

            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTendering.uceSchTenderStatus,
                dicTenderStatuses.Values, "TenderStatusId", "Name");
            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTendering.uceDetTenderStatus,
                dicTenderStatuses.Values, "TenderStatusId", "Name");

            // Bidder
            Dictionary<int, Bidder> dicBidders = srvBidder.LoadBidders();

            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTendering.uceSchBidder,
                dicBidders.Values, "BidderId", "Name");
            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTendering.uceDetBidder,
                dicBidders.Values, "BidderId", "Name");

            this.frmTendering.uceSchBidder.ValueChanged += new EventHandler(uceSchBidder_ValueChanged);
            this.frmTendering.uceDetBidder.ValueChanged += new EventHandler(uceDetBidder_ValueChanged);

            // Dependency
            LoadDependenciesParameters pmtLoadDependencies = new LoadDependenciesParameters();
            pmtLoadDependencies.BidderId = -1;
            Dictionary<int, Dependency> dicDependencies = 
                srvDependency.LoadDependencies(pmtLoadDependencies);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceSchDependency,
                dicDependencies.Values, "DependencyId", "Name");
            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceDetDependency,
                dicDependencies.Values, "DependencyId", "Name");

            this.frmTendering.uceSchDependency.ValueChanged += new EventHandler(uceSchDependency_ValueChanged);
            this.frmTendering.uceDetDependency.ValueChanged += new EventHandler(uceDetDependency_ValueChanged);

            // EndUser
            LoadEndUsersParameters pmtLoadEndUsers = new LoadEndUsersParameters();
            pmtLoadEndUsers.DependencyId = -1;
            Dictionary<int, EndUser> dicEndUsers = srvEndUser.LoadEndUsers(pmtLoadEndUsers);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceSchEndUser,
                dicEndUsers.Values, "EndUserId", "Name");
            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceDetEndUser,
                dicEndUsers.Values, "EndUserId", "Name");
            
            //grdTenderLines
            this.frmTendering.grdTenderLines.InitializeLayout 
                += new InitializeLayoutEventHandler(grdTenderLines_InitializeLayout);
            this.frmTendering.grdTenderLines.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdTenderLines_BeforeCellUpdate);
            SearchTenderLinesParameters pmtSearchTenderLines = new SearchTenderLinesParameters();
            pmtSearchTenderLines.TenderId = -1;
            this.dtTenderLines = this.srvTender.SearchTenderLines(pmtSearchTenderLines);
            this.frmTendering.grdTenderLines.DataSource = null;
            this.frmTendering.grdTenderLines.DataSource = dtTenderLines;

            //grdDetTenderManufacturers
            this.frmTendering.grdDetTenderManufacturers.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderManufacturers_InitializeLayout);
            this.frmTendering.grdDetTenderManufacturers.BeforeCellUpdate
                += new BeforeCellUpdateEventHandler(grdDetTenderManufacturers_BeforeCellUpdate);
            SearchTenderManufacturerParameters pmtSearchTenderManufacturers
                = new SearchTenderManufacturerParameters();
            pmtSearchTenderManufacturers.TenderId = -1;
            this.dtTenderManufacturers =
                this.srvTender.SearchTenderManufacturers(pmtSearchTenderManufacturers);
            this.frmTendering.grdDetTenderManufacturers.DataSource = null;
            this.frmTendering.grdDetTenderManufacturers.DataSource = dtTenderManufacturers;

            this.frmTendering.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmTendering.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmTendering.btnDetSave.Click += new EventHandler(btnDetSave_Click);
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
            if (this.frmTendering.uceDetBidder.Value != null ||
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
                Bidder bidder = srvBidder.LoadBidder(
                    Convert.ToInt32(this.frmTendering.uceDetBidder.Value));
                Assert.IsNotNull(bidder);
                this.tender.Bidder = bidder;
            }
            if (Convert.ToInt32(this.frmTendering.uceDetDependency.Value) > 0)
            {
                Dependency dependency = srvDependency.LoadDependency(
                    Convert.ToInt32(this.frmTendering.uceDetDependency.Value));
                Assert.IsNotNull(dependency);
                this.tender.Dependency = dependency;
            }

            if (Convert.ToInt32(this.frmTendering.uceDetEndUser.Value) > 0)
            {
                EndUser endUser = srvEndUser.LoadEndUser(
                    Convert.ToInt32(this.frmTendering.uceDetEndUser.Value));
                Assert.IsNotNull(endUser);
                this.tender.EndUser = endUser;
            }

            if (Convert.ToInt32(this.frmTendering.uceDetAsesor.Value) > 0)
            {
                Asesor asesor = srvAsesor.LoadAsesor(
                    Convert.ToInt32(this.frmTendering.uceDetAsesor.Value));
                Assert.IsNotNull(asesor);
                this.tender.Asesor = asesor;
            }

            if (Convert.ToInt32(this.frmTendering.uceDetApprovedBy.Value) > 0)
            {
                Asesor asesor = srvAsesor.LoadAsesor(
                    Convert.ToInt32(this.frmTendering.uceDetApprovedBy.Value));
                Assert.IsNotNull(asesor);
                this.tender.ApprovedBy = asesor;
            }

            if (Convert.ToInt32(this.frmTendering.uceDetTenderStatus.Value) > 0)
            {
                TenderStatus tenderStatus = srvTenderStatus.LoadTenderStatus(
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

            this.LoadManufacturers();
            this.LoadTenderLines();

            this.tender.Activated = true;
            this.tender.Deleted = false;
        }

        private void LoadTenderLines()
        {
            foreach (DataRow row in this.dtTenderLines.Rows)
            {
                TenderLine tenderLine = this.tender.TenderLines
                    .Single(x => x.ManufacturerId == Convert.ToInt32(row["ManufacturerId"]));

                tenderLine.Cost = Convert.ToDecimal(row["Cost"]);
                tenderLine.Description = row["Description"].ToString();
                tenderLine.Name = row["Name"].ToString();
                tenderLine.Quantity = Convert.ToDecimal(row["Quantity"]);
                tenderLine.Activated = true;
                tenderLine.Deleted = false;
            }
        }

        private void LoadManufacturers()
        {
            foreach (DataRow row in this.dtTenderManufacturers.Rows)
            {
                TenderManufacturer tenderManufacturer = new TenderManufacturer();

                tenderManufacturer.FolioReference = row["FolioReference"].ToString();
                tenderManufacturer.ManufacturerId = Convert.ToInt32(row["ManufacturerId"]);
                tenderManufacturer.ManufacturerSupport = row["ManufacturerSupport"].ToString();

                this.tender.TenderManufacturers.Add(tenderManufacturer);
            }
        }

        private void CleanDetailControls()
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
            if (this.ValidateFormInformation())
            {
                this.LoadEntity();
                this.srvTender.SaveOrUpdateTender(this.tender);
            }
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            SearchTendersParameters pmtSearchTenders = new SearchTendersParameters();

            pmtSearchTenders.MinDate = (DateTime)this.frmTendering.dteSchMinDate.Value;
            pmtSearchTenders.MaxDate = (DateTime)this.frmTendering.dteSchMaxDate.Value;
            pmtSearchTenders.AsesorId = (int)this.frmTendering.uceSchAsesor.Value;
            pmtSearchTenders.BidderId = (int)this.frmTendering.uceSchBidder.Value;
            pmtSearchTenders.DependencyId = (int)this.frmTendering.uceSchDependency.Value;
            pmtSearchTenders.TenderStatusId = (int)this.frmTendering.uceSchTenderStatus.Value;
            pmtSearchTenders.TenderName = "%" + this.frmTendering.txtSchTenderName.Text + "%";
            pmtSearchTenders.DateTypeSearchId = (DateTypeSearchEnum)this.frmTendering.uosSchDates.Value;

            DataTable dtTenders = srvTender.SearchTenders(pmtSearchTenders);

            this.frmTendering.grdSchSearch.DataSource = null;
            this.frmTendering.grdSchSearch.DataSource = dtTenders;
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.tender = new Tender();
            this.CleanDetailControls();
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
            Dictionary<int, Manufacturer> manufacturers = this.srvManufacturer.LoadManufacturers();

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["TenderLineId"].CellActivation = Activation.ActivateOnly;
            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;

            IEnumerable<Manufacturer> availableManufacturers = this.tender == null || 
                this.tender.TenderManufacturers == null ? manufacturers.Values.Where(x => false) : 
                manufacturers.Values.Where(x => this.tender.TenderManufacturers
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
            Dictionary<int, Manufacturer> manufacturers = this.srvManufacturer.LoadManufacturers();

            WindowsFormsUtil.SetUltraGridValueList<Manufacturer>(layout, manufacturers.Values, band,
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
                this.tender.TenderManufacturers.Remove(this.tender.TenderManufacturers
                    .Single(x => x.ManufacturerId == manufacturerId));
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
                this.tender.TenderLines.Remove(this.tender.TenderLines
                    .Single(x => x.TenderLineId == tenderLineId));
            }

            this.dtTenderLines.Rows.Remove(((DataRowView)activeRow.ListObject).Row);
        }

        private void uchkDetIsOpportunity_CheckedChanged(object sender, EventArgs e)
        {
            this.frmTendering.dteDetDeadline.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.txtDetAddress.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.dteDetVeredictDate.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.uceDetApprovedBy.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.dteDetClarificationDate.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.dteDetPrerevisionDate.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;
            this.frmTendering.dteDetClarificationDate.ReadOnly = this.frmTendering.uchkDetIsOpportunity.Checked;

            if (this.frmTendering.uchkDetIsOpportunity.Checked)
                this.frmTendering.tabDetDetail.TabPages.Remove(this.hiddenTenderDetailTab);
            else if (!this.frmTendering.tabDetDetail.TabPages.ContainsKey("TenderDetails"))
                this.frmTendering.tabDetDetail.TabPages.Add(this.hiddenTenderDetailTab);
        }

        private void uceSchBidder_ValueChanged(object sender, EventArgs e)
        {
            LoadDependenciesParameters pmtLoadDependencies = new LoadDependenciesParameters();
            pmtLoadDependencies.BidderId = Convert.ToInt32(this.frmTendering.uceSchBidder.Value);
            Dictionary<int, Dependency> dicDependencies =
                srvDependency.LoadDependencies(pmtLoadDependencies);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceSchDependency,
                dicDependencies.Values, "DependencyId", "Name");
        }

        private void uceDetBidder_ValueChanged(object sender, EventArgs e)
        {
            LoadDependenciesParameters pmtLoadDependencies = new LoadDependenciesParameters();
            pmtLoadDependencies.BidderId = Convert.ToInt32(this.frmTendering.uceDetBidder.Value);
            Dictionary<int, Dependency> dicDependencies =
                srvDependency.LoadDependencies(pmtLoadDependencies);

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceDetDependency,
                dicDependencies.Values, "DependencyId", "Name");
        }

        private void uceSchDependency_ValueChanged(object sender, EventArgs e)
        {
            LoadEndUsersParameters pmtLoadEndUsers = new LoadEndUsersParameters();
            pmtLoadEndUsers.DependencyId = Convert.ToInt32(this.frmTendering.uceSchDependency.Value);
            Dictionary<int, EndUser> dicEndUsers = srvEndUser.LoadEndUsers(pmtLoadEndUsers);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceSchEndUser,
                dicEndUsers.Values, "EndUserId", "Name");
        }

        private void uceDetDependency_ValueChanged(object sender, EventArgs e)
        {
            LoadEndUsersParameters pmtLoadEndUsers = new LoadEndUsersParameters();
            pmtLoadEndUsers.DependencyId = Convert.ToInt32(this.frmTendering.uceDetDependency.Value);
            Dictionary<int, EndUser> dicEndUsers = srvEndUser.LoadEndUsers(pmtLoadEndUsers);

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceDetEndUser,
                dicEndUsers.Values, "EndUserId", "Name");
        }
        #endregion Events
    }
}
