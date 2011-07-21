
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Iesi.Collections.Generic;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Enums;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.Support.Util;
using Infragistics.Win;

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
                dicAsesors.Values.ToList(), "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceDetAsesor,
                dicAsesors.Values.ToList(), "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceDetApprovedBy,
                dicAsesors.Values.Where(x => x.CanApprove == true).ToList(), "AsesorId", "Name");

            // TenderStatus
            Dictionary<int, TenderStatus> dicTenderStatuses = srvTenderStatus.LoadTenderStatuses();

            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTendering.uceSchTenderStatus,
                dicTenderStatuses.Values.ToList(), "TenderStatusId", "Name");
            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTendering.uceDetTenderStatus,
                dicTenderStatuses.Values.ToList(), "TenderStatusId", "Name");

            // Bidder
            Dictionary<int, Bidder> dicBidders = srvBidder.LoadBidders();

            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTendering.uceSchBidder,
                dicBidders.Values.ToList(), "BidderId", "Name");
            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTendering.uceDetBidder,
                dicBidders.Values.ToList(), "BidderId", "Name");

            // Dependency
            Dictionary<int, Dependency> dicDependencies = srvDependency.LoadDependencies();

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceSchDependency,
                dicDependencies.Values.ToList(), "DependencyId", "Name");
            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceDetDependency,
                dicDependencies.Values.ToList(), "DependencyId", "Name");

            // EndUser
            Dictionary<int, EndUser> dicEndUsers = srvEndUser.LoadEndUsers();

            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceSchEndUser,
                dicEndUsers.Values.ToList(), "EndUserId", "Name");
            WindowsFormsUtil.LoadCombo<EndUser>(this.frmTendering.uceDetEndUser,
                dicEndUsers.Values.ToList(), "EndUserId", "Name");

            this.frmTendering.uosSchDates.Value = -1;
            this.frmTendering.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmTendering.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmTendering.btnDetAccept.Click += new EventHandler(btnDetAccept_Click);
            this.frmTendering.ubtnDetDeleteManufacturer.Click += 
                new EventHandler(ubtnDetDeleteManufacturer_Click);
            this.frmTendering.ubtnDetNewManufacturer.Click += 
                new EventHandler(ubtnDetNewManufacturer_Click);
            this.frmTendering.ubtnDetCreateLine.Click += new EventHandler(ubtnDetCreateLine_Click);
            this.frmTendering.ubtnDetDeleteLine.Click += new EventHandler(ubtnDetDeleteLine_Click);
            
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
                MessageBox.Show("Favor de seleccionar el Licitante", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTendering.uceDetBidder.Focus();
                return false;
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
            this.tender.AcquisitionReason = this.frmTendering.txtDetAcquisitionReason.Text;
            this.tender.Address = this.frmTendering.txtDetAddress.Text;

            this.tender.Activated = true;
            this.tender.Deleted = false;
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
            this.ShowDetail(true);
            this.tender = new Tender();
        }

        private void btnDetAccept_Click(object sender, EventArgs e)
        {
            this.ValidateFormInformation();
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
            UltraGridRow activeRow = this.frmTendering.grdTenderLines.ActiveRow;
            if (activeRow == null) return;
            activeRow.PerformAutoSize();                       
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
            UltraGridRow activeRow = this.frmTendering.grdDetTenderManufacturers.ActiveRow;
            if (activeRow == null) return;
            activeRow.PerformAutoSize();

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

        #endregion Events
    }
}
