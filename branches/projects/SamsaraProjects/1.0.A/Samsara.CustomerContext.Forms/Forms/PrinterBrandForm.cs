
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class PrinterBrandForm : PrinterBrandSearchForm
    {
        #region Attributes

        private PrinterBrandFormController ctrlPrinterBrandForm;
        private IPrinterBrandService srvPrinterBrand;

        #endregion Attributes

        public PrinterBrandForm()
        {
            InitializeComponent();
            this.ctrlPrinterBrandForm = new PrinterBrandFormController(this);
            this.srvPrinterBrand = SamsaraAppContext.Resolve<IPrinterBrandService>();
            Assert.IsNotNull(this.srvPrinterBrand);
        }

        #region Methods

        public override PrinterBrand GetSearchResult()
        {
            PrinterBrand PrinterBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int PrinterBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                PrinterBrand = this.srvPrinterBrand.GetById(PrinterBrandId);
            }

            return PrinterBrand;
        }

        #endregion Methods
    }
}
