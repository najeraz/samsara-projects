
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.Support.Util;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Enums;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class TenderingFormController
    {
        #region Attributes

        private TenderingForm frmTendering;

        #endregion Attributes

        #region Constructor

        public TenderingFormController(TenderingForm instance)
        {
            this.frmTendering = instance;
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            // Asesor
            IAsesorService srvAsesor = ApplicationContext.Resolve<IAsesorService>();
            Assert.IsNotNull(srvAsesor);
            Dictionary<int, Asesor> dicAsesors = srvAsesor.LoadAsesors();

            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceSchAsesor,
                dicAsesors.Values.ToList(), "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceDetAsesor,
                dicAsesors.Values.ToList(), "AsesorId", "Name");
            WindowsFormsUtil.LoadCombo<Asesor>(this.frmTendering.uceDetApprovedBy,
                dicAsesors.Values.Where(x => x.CanApprove == true).ToList(), "AsesorId", "Name");

            // TenderStatus
            ITenderStatusService srvTenderStatus = ApplicationContext.Resolve<ITenderStatusService>();
            Assert.IsNotNull(srvTenderStatus);
            Dictionary<int, TenderStatus> dicTenderStatuses = srvTenderStatus.LoadTenderStatuses();

            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTendering.uceSchTenderStatus,
                dicTenderStatuses.Values.ToList(), "TenderStatusId", "Name");
            WindowsFormsUtil.LoadCombo<TenderStatus>(this.frmTendering.uceDetTenderStatus,
                dicTenderStatuses.Values.ToList(), "TenderStatusId", "Name");

            // Bidder
            IBidderService srvBidder = ApplicationContext.Resolve<IBidderService>();
            Assert.IsNotNull(srvBidder);
            Dictionary<int, Bidder> dicBidders = srvBidder.LoadBidders();

            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTendering.uceSchBidder,
                dicBidders.Values.ToList(), "BidderId", "Name");
            WindowsFormsUtil.LoadCombo<Bidder>(this.frmTendering.uceDetBidder,
                dicBidders.Values.ToList(), "BidderId", "Name");

            // Dependency
            IDependencyService srvDependency = ApplicationContext.Resolve<IDependencyService>();
            Assert.IsNotNull(srvDependency);
            Dictionary<int, Dependency> dicDependencys = srvDependency.LoadDependencies();

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceSchDependency,
                dicDependencys.Values.ToList(), "DependencyId", "Name");
            WindowsFormsUtil.LoadCombo<Dependency>(this.frmTendering.uceDetDependency,
                dicDependencys.Values.ToList(), "DependencyId", "Name");

            this.frmTendering.uosSchDates.Value = -1;
            this.frmTendering.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            TenderSearchParameters pmtTenderSearch = new TenderSearchParameters();

            pmtTenderSearch.MinDate = (DateTime)this.frmTendering.dteSchMinDate.Value;
            pmtTenderSearch.MaxDate = (DateTime)this.frmTendering.dteSchMaxDate.Value;
            pmtTenderSearch.AsesorId = (int)this.frmTendering.uceSchAsesor.Value;
            pmtTenderSearch.BidderId = (int)this.frmTendering.uceSchBidder.Value;
            pmtTenderSearch.DependencyId = (int)this.frmTendering.uceSchDependency.Value;
            pmtTenderSearch.TenderStatusId = (int)this.frmTendering.uceSchTenderStatus.Value;
            pmtTenderSearch.DateTypeSearchId = (DateTypeSearchEnum)this.frmTendering.uosSchDates.Value;

            ITenderService srvTender = ApplicationContext.Resolve<ITenderService>();
            Assert.IsNotNull(srvTender);
            DataTable dtTenders = srvTender.SearchTenders(pmtTenderSearch);

            this.frmTendering.grdSchSearch.DataSource = null;
            this.frmTendering.grdSchSearch.DataSource = dtTenders;
        }

        #endregion Events
    }
}
