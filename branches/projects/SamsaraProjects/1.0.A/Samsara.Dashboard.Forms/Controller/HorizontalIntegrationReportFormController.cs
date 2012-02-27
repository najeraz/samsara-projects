
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
        private IERPCustomerService srvERPCustomer;
        private IProductSublineService srvProductSubline;
        private IProductFamilyService srvProductFamily;

        #endregion Attributes

        #region Constructor

        public HorizontalIntegrationReportFormController(HorizontalIntegrationReportForm frmHorizontalIntegration)
            : base(frmHorizontalIntegration)
        {
            this.frmHorizontalIntegration = frmHorizontalIntegration;

            this.srvERPCustomer = SamsaraAppContext.Resolve<IERPCustomerService>();
            Assert.IsNotNull(this.srvERPCustomer);
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

            int currentYear = startTime.Year;

            foreach (TimeUtil.Months month in TimeUtil.GetMonthsRange(startTime, endTime))
            {
                int currentMonth = Convert.ToInt32(month);

                this.dtGridReport.Columns.Add(currentMonth.ToString() + " " + currentYear, typeof(decimal));

                currentYear = currentMonth == 12 ? currentYear + 1 : currentYear;
            }

            HorizontalIntegrationReportParameters pmtHorizontalIntegrationReport
                = new HorizontalIntegrationReportParameters();

            pmtHorizontalIntegrationReport.MinDate = this.frmHorizontalIntegration.dtePrplMinDate.DateTime;
            pmtHorizontalIntegrationReport.MaxDate = this.frmHorizontalIntegration.dtePrplMaxDate.DateTime;

            DataTable dtData = this.srvAlleatoERP.CustomSearchByParameters(
                "HorizontalIntegrationReport.SearchReportData", pmtHorizontalIntegrationReport, false);

            IList<int> lstStaffIds = dtData.AsEnumerable().AsParallel()
                .Select(x => Convert.ToInt32(x[4])).Distinct().ToList();

            IList<ERPCustomer> lstCustomers = this.srvERPCustomer.GetAll()
                .AsParallel().Where(x => lstStaffIds.Contains(x.Staff.StaffId))
                .OrderBy(x => x.Staff.Names).ThenBy(x => x.ERPCustomerId).ToList();

            foreach (ERPCustomer customer in lstCustomers)
            {
                DataRow newRow = this.dtGridReport.NewRow();
                this.dtGridReport.Rows.Add(newRow);

                newRow["CustomerId"] = customer.ERPCustomerId;
                newRow["CustomerName"] = customer.Name.Trim();
                if (customer.ComercialName == null)
                    newRow["ComercialName"] = DBNull.Value;
                else
                    newRow["ComercialName"] = customer.ComercialName.Trim();
                newRow["Agent"] = customer.Staff.Fullname.Trim();
            }

            foreach (DataRow row in this.dtGridReport.Rows)
            {
                int customerId = Convert.ToInt32(row["CustomerId"]);

                foreach (DataColumn column in this.dtGridReport.Columns
                    .Cast<DataColumn>().Where(x => x.Ordinal >= 4).ToList())
                {
                    IList<string> dateData = column.ColumnName.Split(' ');
                    string month = dateData.First();
                    string year = dateData.Last();

                    DataRow rowTotal = dtData.AsEnumerable().AsParallel()
                        .SingleOrDefault(x => Convert.ToInt32(x[2]) == customerId
                            && Convert.ToInt32(month) == Convert.ToInt32(x[0])
                            && Convert.ToInt32(year) == Convert.ToInt32(x[1]));

                    if (rowTotal == null)
                        row[column.ColumnName] = 0M;
                    else
                        row[column.ColumnName] = rowTotal[3];
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

            foreach (UltraGridColumn column in band.Columns.Cast<UltraGridColumn>()
                .Where(x => x.Index >= 4))
            {
                if (!int.TryParse(column.Header.Caption.Split(' ').First(), out index))
                    continue;

                column.Header.Caption = TimeUtil.MonthName((TimeUtil.Months)index);
            }

            foreach (UltraGridColumn column in band.Columns
                .Cast<UltraGridColumn>().Where(x => x.Index >= 4))
            {
                WindowsFormsUtil.SetUltraColumnFormat(column, TextMaskFormatEnum.Currency);
                column.Width = 100;
            }

            foreach (UltraGridRow row in this.frmHorizontalIntegration.grdPrincipal.Rows.Where(x => x.Cells != null))
            {
                foreach (UltraGridCell cell in row.Cells.Cast<UltraGridCell>().Where(x => x.Column.Index >= 4))
                {
                    if (Convert.ToDecimal(cell.Value) == 0M)
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
