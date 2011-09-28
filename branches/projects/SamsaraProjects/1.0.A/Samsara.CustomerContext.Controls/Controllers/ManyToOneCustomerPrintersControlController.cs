
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
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
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IPrinterBrandService srvPrinterBrand;
        private IPrinterTypeService srvPrinterType;
        private System.Collections.Generic.ISet<CustomerInfrastructurePrinter> customerInfrastructurePrinters;

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
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructurePrinter> tmp
                    = new HashSet<CustomerInfrastructurePrinter>();

                foreach(CustomerInfrastructurePrinter customerInfrastructurePrinter in
                    this.customerInfrastructurePrinters)
                {
                    customerInfrastructurePrinter.CustomerInfrastructurePrinterId 
                        = customerInfrastructurePrinter.CustomerInfrastructurePrinterId <= 0 ?
                        -1 : customerInfrastructurePrinter.CustomerInfrastructurePrinterId;

                    tmp.Add(customerInfrastructurePrinter);
                }

                return tmp;
            }
        }
        
        #endregion Properties
        
        #region Constructor

        public ManyToOneCustomerPrintersControlController(
            ManyToOneCustomerPrintersControl instance) : base(instance)  
        {
            this.controlManyToOneCustomerPrinters = instance;

            this.srvCustomerInfrastructurePrinter = SamsaraAppContext.Resolve<ICustomerInfrastructurePrinterService>();
            Assert.IsNotNull(this.srvCustomerInfrastructurePrinter);
            this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
            Assert.IsNotNull(this.srvCustomerInfrastructure);
            this.srvPrinterBrand = SamsaraAppContext.Resolve<IPrinterBrandService>();
            Assert.IsNotNull(this.srvPrinterBrand);
            this.srvPrinterType = SamsaraAppContext.Resolve<IPrinterTypeService>();
            Assert.IsNotNull(this.srvPrinterType);

            this.InitializeControlControls();
        }

        #endregion Constructor

        #region Methods

        #region Private

        private void InitializeControlControls()
        {
            PrinterBrandParameters pmtPrinterBrand = new PrinterBrandParameters();

            IList<PrinterBrand> printerBrands = this.srvPrinterBrand.GetListByParameters(pmtPrinterBrand);
            WindowsFormsUtil.LoadCombo<PrinterBrand>(this.controlManyToOneCustomerPrinters.ucePrinterBrand,
                printerBrands, "PrinterBrandId", "Name", "Seleccione");

            PrinterTypeParameters pmtPrinterType = new PrinterTypeParameters();

            IList<PrinterType> printerTypes = this.srvPrinterType.GetListByParameters(pmtPrinterType);
            WindowsFormsUtil.LoadCombo<PrinterType>(this.controlManyToOneCustomerPrinters.ucePrinterType,
                printerTypes, "PrinterTypeId", "Name", "Seleccione");
        }

        #endregion Private

        #region Public

        public void LoadGrid()
        {
            if (this.CustomerInfrastructureId != null)
            {
                CustomerInfrastructurePrinterParameters pmtCustomerInfrastructurePrinter
                    = new CustomerInfrastructurePrinterParameters();

                pmtCustomerInfrastructurePrinter.CustomerInfrastructureId = this.CustomerInfrastructureId;

                this.dtCustomerPrinters = this.srvCustomerInfrastructurePrinter
                    .SearchByParameters(pmtCustomerInfrastructurePrinter);

                this.controlManyToOneCustomerPrinters.grdRelations.DataSource = null;
                this.controlManyToOneCustomerPrinters.grdRelations.DataSource = this.dtCustomerPrinters;

                IList<CustomerInfrastructurePrinter> lstCustomerInfrastructurePrinters 
                    = this.srvCustomerInfrastructurePrinter.GetListByParameters(pmtCustomerInfrastructurePrinter);

                this.customerInfrastructurePrinters = new HashSet<CustomerInfrastructurePrinter>();

                foreach (CustomerInfrastructurePrinter customerInfrastructurePrinter in
                    lstCustomerInfrastructurePrinters)
                {
                    this.customerInfrastructurePrinters.Add(customerInfrastructurePrinter);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value = ParameterConstants.IntDefault;
            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value = ParameterConstants.IntDefault;
            this.controlManyToOneCustomerPrinters.txtlSerialNumber.Text = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructurePrinter = new CustomerInfrastructurePrinter();

            this.customerInfrastructurePrinter.Activated = true;
            this.customerInfrastructurePrinter.Deleted = false;
            this.customerInfrastructurePrinter.CustomerInfrastructure 
                = this.srvCustomerInfrastructure.GetById(this.CustomerInfrastructureId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructurePrinter = this.customerInfrastructurePrinters
                .Single(x => x.CustomerInfrastructurePrinterId == entityId);

            this.customerInfrastructurePrinter.Activated = false;
            this.customerInfrastructurePrinter.Deleted = true;

            DataRow row = this.dtCustomerPrinters.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructurePrinterId"])
                == this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId);

            this.dtCustomerPrinters.Rows.Remove(row);
            this.dtCustomerPrinters.AcceptChanges();
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructurePrinter = this.customerInfrastructurePrinters
                .Single(x => x.CustomerInfrastructurePrinterId == entityId);

            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value
                = this.customerInfrastructurePrinter.PrinterBrand.PrinterBrandId;

            this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value
                = this.customerInfrastructurePrinter.PrinterType.PrinterTypeId;

            this.controlManyToOneCustomerPrinters.txtlSerialNumber.Text
                = this.customerInfrastructurePrinter.SerialNumber;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructurePrinter.PrinterBrand = this.srvPrinterBrand
                .GetById(Convert.ToInt32(this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value));

            this.customerInfrastructurePrinter.PrinterType = this.srvPrinterType
                .GetById(Convert.ToInt32(this.controlManyToOneCustomerPrinters.ucePrinterType.Value));

            this.customerInfrastructurePrinter.SerialNumber = this.controlManyToOneCustomerPrinters.txtlSerialNumber.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value == null ||
                    Convert.ToInt32(this.controlManyToOneCustomerPrinters.ucePrinterBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca de Impresora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlManyToOneCustomerPrinters.ucePrinterBrand.Focus();
                return false;
            }

            if (this.controlManyToOneCustomerPrinters.ucePrinterType.Value == null ||
                Convert.ToInt32(this.controlManyToOneCustomerPrinters.ucePrinterType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de Impresora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlManyToOneCustomerPrinters.ucePrinterType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId == -1)
            {
                this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId = this.entityCounter--;
                this.customerInfrastructurePrinters.Add(this.customerInfrastructurePrinter);

                row = this.dtCustomerPrinters.NewRow();
                this.dtCustomerPrinters.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerPrinters.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructurePrinterId"])
                        == this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId);
            }

            row["CustomerInfrastructurePrinterId"] = this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId;
            row["PrinterBrandId"] = this.customerInfrastructurePrinter.PrinterBrand.PrinterBrandId;
            row["PrinterTypeId"] = this.customerInfrastructurePrinter.PrinterType.PrinterTypeId;
            row["SerialNumber"] = this.customerInfrastructurePrinter.SerialNumber;

            this.dtCustomerPrinters.AcceptChanges();
        }

        #endregion Protected

        #endregion Methods
    }
}
