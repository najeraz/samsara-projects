
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
    public partial class PrinterTypeForm : PrinterTypeSearchForm
    {
        #region Attributes

        private PrinterTypeFormController ctrlPrinterTypeForm;
        private IPrinterTypeService srvPrinterType;

        #endregion Attributes

        public PrinterTypeForm()
        {
            InitializeComponent();
            this.ctrlPrinterTypeForm = new PrinterTypeFormController(this);
            this.srvPrinterType = SamsaraAppContext.Resolve<IPrinterTypeService>();
            Assert.IsNotNull(this.srvPrinterType);
        }

        #region Methods

        public override PrinterType GetSerchResult()
        {
            PrinterType PrinterType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int PrinterTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                PrinterType = this.srvPrinterType.GetById(PrinterTypeId);
            }

            return PrinterType;
        }

        #endregion Methods
    }
}
