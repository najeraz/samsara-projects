﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Controllers;
using Samsara.Dashboard.Core.Parameters;
using Samsara.Dashboard.Forms.Forms;
using Samsara.Support.Util;

namespace Samsara.Dashboard.Forms.Controller
{
    public class HorizontalIntegrationReportFormController : GenericReportFormController
    {
        #region Attributes

        private HorizontalIntegrationReportForm frmHorizontalIntegration;
        private DataTable dtGridReport;
        private IAERPCustomerService srvAERPCustomer;
        private IProductSublineService srvProductSubline;
        private IProductFamilyService srvProductFamily;

        #endregion Attributes

        #region Constructor

        public HorizontalIntegrationReportFormController(HorizontalIntegrationReportForm frmHorizontalIntegration)
            : base(frmHorizontalIntegration)
        {
            this.frmHorizontalIntegration = frmHorizontalIntegration;

            this.srvAERPCustomer = SamsaraAppContext.Resolve<IAERPCustomerService>();
            Assert.IsNotNull(this.srvAERPCustomer);
            this.srvProductSubline = SamsaraAppContext.Resolve<IProductSublineService>();
            Assert.IsNotNull(this.srvProductSubline);
            this.srvProductFamily = SamsaraAppContext.Resolve<IProductFamilyService>();
            Assert.IsNotNull(this.srvProductFamily);

            this.InitializeFormControls();
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected override void InitializeFormControls()
        {
            base.InitializeFormControls();

            this.frmHorizontalIntegration.grdPrincipal.InitializeLayout 
                += new InitializeLayoutEventHandler(grdPrincipal_InitializeLayout);

            DateTime dtNow = this.srvAlleatoERP.GetServerDateTime();

            this.frmHorizontalIntegration.dtePrplMinDate.DateTime = new DateTime(dtNow.Year, dtNow.Month <= 6 ? 1 : 6, 1);
            this.frmHorizontalIntegration.dtePrplMaxDate.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);
        }

        protected override void ClearPrincipalControls()
        {
            base.ClearPrincipalControls();
        }

        #endregion Protected

        #region Internal

        public override void GenerateReport()
        {
            base.GenerateReport();
            
            this.dtGridReport = new DataTable();
            
            this.dtGridReport.Columns.Add("CustomerId", typeof(int));
            this.dtGridReport.Columns.Add("CustomerName", typeof(string));
            this.dtGridReport.Columns.Add("ComercialName", typeof(string));
            this.dtGridReport.Columns.Add("Agent", typeof(string));
                        
            DateTime startTime = this.frmHorizontalIntegration.dtePrplMinDate.DateTime;
            DateTime endTime = this.frmHorizontalIntegration.dtePrplMaxDate.DateTime;

            foreach (TimeUtil.Months month in TimeUtil.GetMonthsRange(startTime, endTime))
            {
                this.dtGridReport.Columns.Add(TimeUtil.MonthName(month), typeof(decimal));
            }

            HorizontalIntegrationReportParameters pmtHorizontalIntegrationReport
                = new HorizontalIntegrationReportParameters();

            pmtHorizontalIntegrationReport.MinDate = this.frmHorizontalIntegration.dtePrplMinDate.DateTime;
            pmtHorizontalIntegrationReport.MaxDate = this.frmHorizontalIntegration.dtePrplMaxDate.DateTime;

            DataTable dtData = this.srvAlleatoERP.CustomSearchByParameters(
                "HorizontalIntegrationReport.SearchReportData", pmtHorizontalIntegrationReport, false);

            IList<int> lstStaffIds = dtData.AsEnumerable().AsParallel()
                .Select(x => Convert.ToInt32(x[3])).Distinct().ToList();

            IList<AERPCustomer> lstCustomers = this.srvAERPCustomer.GetAll()
                .AsParallel().Where(x => lstStaffIds.Contains(x.Staff.StaffId))
                .OrderBy(x => x.Staff.Names).ThenBy(x => x.AERPCustomerId).ToList();

            foreach (AERPCustomer customer in lstCustomers)
            {
                DataRow newRow = this.dtGridReport.NewRow();
                this.dtGridReport.Rows.Add(newRow);

                newRow["CustomerId"] = customer.AERPCustomerId;
                newRow["CustomerName"] = customer.Name.Trim();
                if (customer.ComercialName == null)
                    newRow["ComercialName"] = DBNull.Value;
                else
                    newRow["ComercialName"] = customer.ComercialName.Trim();
                newRow["Agent"] = customer.Staff.Names.Trim() + " " + customer.Staff.Lastname.Trim();
            }

            foreach (DataRow row in this.dtGridReport.Rows)
            {
                int customerId = Convert.ToInt32(row["CustomerId"]);

                foreach (DataColumn column in this.dtGridReport.Columns
                    .Cast<DataColumn>().Where(x => x.Ordinal >= 4).ToList())
                {
                    row[column.ColumnName] = dtData.AsEnumerable().AsParallel()
                        .Where(x => Convert.ToInt32(x[1]) == customerId
                            && Convert.ToInt32(column.ColumnName) == Convert.ToInt32(x[0]))
                            .FirstOrDefault() != null;
                }
            }
            
            this.dtGridReport.AcceptChanges();

            this.frmHorizontalIntegration.grdPrincipal.DataSource = null;
            this.frmHorizontalIntegration.grdPrincipal.DataSource = this.dtGridReport;
        }

        #endregion Internal

        #endregion Methods

        #region Events

        private void grdPrincipal_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];
            int index = 0;

            //foreach (UltraGridColumn column in band.Columns.Cast<UltraGridColumn>()
            //    .Where(x => x.Index >= 4 && int.TryParse(x.Header.Caption, out index)))
            //{
            //    column.Header.Caption = this.lstLines
            //        .Single(x => x.ProductLineId == Convert.ToInt32(column.Header.Caption)).Name.Trim();
            //}

            foreach (UltraGridRow row in this.frmHorizontalIntegration.grdPrincipal.Rows.Where(x => x.Cells != null))
            {
                foreach (UltraGridCell cell in row.Cells.Cast<UltraGridCell>().Where(x => x.Column.Index >= 4))
                {
                    if (!Convert.ToBoolean(cell.Value))
                        cell.Appearance.BackColor = Color.Yellow;
                }
            }

            band.Columns["CustomerId"].Header.Caption = "Id Cliente";
            band.Columns["Agent"].Header.Caption = "Agente";
            band.Columns["CustomerName"].Header.Caption = "Nombre Cliente";
            band.Columns["ComercialName"].Header.Caption = "Nombre Comercial";

            band.SortedColumns.Add("Agent", false, true);
        }

        #endregion Events
    }
}
