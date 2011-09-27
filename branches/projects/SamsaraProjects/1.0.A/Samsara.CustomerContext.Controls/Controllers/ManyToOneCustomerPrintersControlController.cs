
using Samsara.Controls.Controllers;
using Samsara.CustomerContext.Controls.Controls;
using Samsara.Controls.Controls;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Base.Core.Context;
using NUnit.Framework;
using Samsara.CustomerContext.Core.Entities;
using Infragistics.Win.UltraWinGrid;
using System.Data;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.Support.Util;
using System;
using System.Collections.Generic;

namespace Samsara.CustomerContext.Controls.Controllers
{
    public class ManyToOneCustomerPrintersControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ManyToOneCustomerPrintersControl controlManyToOneCustomerPrinters;
        private ICustomerInfrastructurePrinterService srvCustomerInfrastructurePrinter;
        private IPrinterTypeService srvPrinterType;
        private IPrinterBrandService srvPrinterBrand;
        private CustomerInfrastructurePrinter entCustomerInfrastructurePrinter;

        private DataTable dtCustomerPrinters;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public int CustomerInfrastructureId
        {
            get;
            set;
        }
        
        #endregion Properties
        
        #region Constructor

        public ManyToOneCustomerPrintersControlController(
            ManyToOneCustomerPrintersControl instance) : base(instance)  
        {
            this.controlManyToOneCustomerPrinters = instance;

            this.srvCustomerInfrastructurePrinter = SamsaraAppContext.Resolve<ICustomerInfrastructurePrinterService>();
            Assert.IsNotNull(this.srvCustomerInfrastructurePrinter);
            this.srvPrinterType = SamsaraAppContext.Resolve<IPrinterTypeService>();
            Assert.IsNotNull(this.srvPrinterType);
            this.srvPrinterBrand = SamsaraAppContext.Resolve<IPrinterBrandService>();
            Assert.IsNotNull(this.srvPrinterBrand);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public override void InitializeControlControls()
        {
            base.InitializeControlControls();

            PrinterBrandParameters pmtPrinterBrand = new PrinterBrandParameters();

            IList<PrinterBrand> printerBrands = this.srvPrinterBrand.GetListByParameters(pmtPrinterBrand);
            WindowsFormsUtil.LoadCombo<PrinterBrand>(this.controlManyToOneCustomerPrinters.ucePrinterBrand,
                printerBrands, "PrinterBrandId", "Name", "Seleccione");

            PrinterTypeParameters pmtPrinterType = new PrinterTypeParameters();

            IList<PrinterType> printerTypes = this.srvPrinterType.GetListByParameters(pmtPrinterType);
            WindowsFormsUtil.LoadCombo<PrinterType>(this.controlManyToOneCustomerPrinters.ucePrinterType,
                printerTypes, "PrinterTypeId", "Name", "Seleccione");

            CustomerInfrastructurePrinterParameters pmtCustomerInfrastructurePrinter
                = new CustomerInfrastructurePrinterParameters();

            pmtCustomerInfrastructurePrinter.CustomerInfrastructureId = ParameterConstants.IntNone;
            this.dtCustomerPrinters = this.srvCustomerInfrastructurePrinter
                .SearchByParameters(pmtCustomerInfrastructurePrinter);

            this.controlManyToOneCustomerPrinters.grdRelations.DataSource = null;
            this.controlManyToOneCustomerPrinters.grdRelations.DataSource = this.dtCustomerPrinters;
        }

        public override void CancelRelation()
        {
            base.CancelRelation();
        }

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value = null;
            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value = null;
            this.controlManyToOneCustomerPrinters.txtlSerialNumber.Text = string.Empty;
        }

        public override void DeleteRelation()
        {
            base.DeleteRelation();
        }

        public override void CreateRelation()
        {
            base.CreateRelation();
        }

        public override void EditRelation()
        {
            UltraGridRow activeRow = this.controlManyToOneCustomerPrinters.grdRelations.ActiveRow;
            base.EditRelation();

            if (activeRow != null)
            {
                int customerInfrastructurePrinterId = Convert.ToInt32((activeRow.ListObject as DataRowView).Row[0]);
                this.entCustomerInfrastructurePrinter = this.srvCustomerInfrastructurePrinter
                    .GetById(customerInfrastructurePrinterId);

                this.LoadFromEntity();
            }
        }

        public override void SaveRelation()
        {
            base.SaveRelation();
        }

        #endregion Public

        #region Private

        private void LoadFromEntity()
        {
            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value
                = this.entCustomerInfrastructurePrinter.PrinterBrand.PrinterBrandId;
            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value
                = this.entCustomerInfrastructurePrinter.PrinterType.PrinterTypeId;
            this.controlManyToOneCustomerPrinters.txtlSerialNumber.Text
                = this.entCustomerInfrastructurePrinter.SerialNumber;
        }

        #endregion Private

        #endregion Methods
    }
}
