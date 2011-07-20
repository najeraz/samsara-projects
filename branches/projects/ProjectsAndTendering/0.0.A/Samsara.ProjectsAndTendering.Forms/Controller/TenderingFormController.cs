
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Enums;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.Support.Util;
using Infragistics.Win.UltraWinGrid;
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
            
            //grdTenderLines
            this.frmTendering.grdTenderLines.InitializeLayout 
                += new InitializeLayoutEventHandler(grdTenderLines_InitializeLayout);
            SearchTenderLinesParameters pmtSearchTenderLines = new SearchTenderLinesParameters();
            pmtSearchTenderLines.TenderId = -1;
            DataTable dtTenderLines = this.srvTender.SearchTenderLines(pmtSearchTenderLines);
            this.frmTendering.grdTenderLines.DataSource = null;
            this.frmTendering.grdTenderLines.DataSource = dtTenderLines;

            //grdDetTenderManufacturers
            this.frmTendering.grdDetTenderManufacturers.InitializeLayout
                += new InitializeLayoutEventHandler(grdDetTenderManufacturers_InitializeLayout);
            SearchTenderManufacturerParameters pmtSearchTenderManufacturers
                = new SearchTenderManufacturerParameters();
            pmtSearchTenderManufacturers.TenderId = -1;
            DataTable dtTenderManofacturers =
                this.srvTender.SearchTenderManufacturers(pmtSearchTenderManufacturers);
            this.frmTendering.grdDetTenderManufacturers.DataSource = null;
            this.frmTendering.grdDetTenderManufacturers.DataSource = dtTenderManofacturers;

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

        private void ValidateFormInformation()
        {
            if (this.frmTendering.uceDetBidder.Value != null ||
                Convert.ToInt32(this.frmTendering.uceDetBidder.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Licitante", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTendering.uceDetBidder.Focus();
            }
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
            
            this.tender.ClarificationDate = this.frmTendering.dteDetClarificationDate.DateTime;
            this.tender.Deadline = this.frmTendering.dteDetDeadline.DateTime;
            this.tender.PreRevisionDate = this.frmTendering.dteDetPrerevisionDate.DateTime;
            this.tender.RegistrationDate = this.frmTendering.dteDetRegistrationDate.DateTime;
            this.tender.VerdictDate = this.frmTendering.dteDetVeredictDate.DateTime;

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

        }

        private void grdDetTenderManufacturers_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            Dictionary<int, Manufacturer> manufacturers = this.srvManufacturer.LoadManufacturers();

            WindowsFormsUtil.SetUltraGridValueList<Manufacturer>(e, manufacturers.Values, 0, "ManufacturerId", "Name");
        }

        #endregion Events
    }
}
