
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Controls.Controllers;
using Samsara.CustomerContext.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.CustomerContext.Controls.Controllers
{
    public class ManyToOneCustomerPrintersControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructurePrinterService srvCustomerInfrastructurePrinter;
        private ManyToOneCustomerPrintersControl controlManyToOneCustomerPrinters;
        private CustomerInfrastructurePrinter customerInfrastructurePrinter;
        private IPrinterBrandService srvPrinterBrand;
        private IPrinterTypeService srvPrinterType;

        private DataTable dtCustomerPrinters;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public System.Collections.Generic.ISet<CustomerInfrastructurePrinter> CustomerInfrastructurePrinters
        {
            get;
            private set;
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
        }

        public override void LoadGrid()
        {
            base.LoadGrid();

            if (this.CustomerInfrastructurePrinters == null && this.CustomerInfrastructureId != null)
            {
                CustomerInfrastructurePrinterParameters pmtCustomerInfrastructurePrinter
                    = new CustomerInfrastructurePrinterParameters();

                pmtCustomerInfrastructurePrinter.CustomerInfrastructureId = this.CustomerInfrastructureId;

                this.dtCustomerPrinters = this.srvCustomerInfrastructurePrinter
                    .SearchByParameters(pmtCustomerInfrastructurePrinter);

                this.controlManyToOneCustomerPrinters.grdRelations.DataSource = null;
                this.controlManyToOneCustomerPrinters.grdRelations.DataSource = this.dtCustomerPrinters;

                IList<CustomerInfrastructurePrinter> customerInfrastructurePrinters 
                    = this.srvCustomerInfrastructurePrinter.GetListByParameters(pmtCustomerInfrastructurePrinter);

                this.CustomerInfrastructurePrinters = new HashSet<CustomerInfrastructurePrinter>();

                foreach (CustomerInfrastructurePrinter customerInfrastructurePrinter in
                    customerInfrastructurePrinters)
                {
                    this.CustomerInfrastructurePrinters.Add(customerInfrastructurePrinter);
                }
            }
        }
        
        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value = null;
            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value = null;
            this.controlManyToOneCustomerPrinters.txtlSerialNumber.Text = string.Empty;
        }

        public override void DeleteEntity(int entityId)
        {
            this.customerInfrastructurePrinter = this.CustomerInfrastructurePrinters
                .Single(x => x.CustomerInfrastructurePrinterId == entityId);

            this.customerInfrastructurePrinter.Activated = false;
            this.customerInfrastructurePrinter.Deleted = true;
        }

        public override void LoadFromEntity(int entityId)
        {
            this.customerInfrastructurePrinter = this.CustomerInfrastructurePrinters
                .Single(x => x.CustomerInfrastructurePrinterId == entityId);

            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value
                = this.customerInfrastructurePrinter.PrinterBrand.PrinterBrandId;

            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value
                = this.customerInfrastructurePrinter.PrinterType.PrinterTypeId;

            this.controlManyToOneCustomerPrinters.txtlSerialNumber.Text
                = this.customerInfrastructurePrinter.SerialNumber;
        }

        public override void LoadEntity()
        {
            this.customerInfrastructurePrinter.PrinterBrand = this.srvPrinterBrand
                .GetById(Convert.ToInt32(this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value));

            this.customerInfrastructurePrinter.PrinterType = this.srvPrinterType
                .GetById(Convert.ToInt32(this.controlManyToOneCustomerPrinters.ucePrinterType.Value));

            this.customerInfrastructurePrinter.SerialNumber = this.controlManyToOneCustomerPrinters.txtlSerialNumber.Text;
        }

        public virtual bool ValidateControlsData()
        {
            return true;
        }

        #endregion Public

        #endregion Methods
    }
}
