﻿
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
using System.Windows.Forms;

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
            private set
            {
                this.customerInfrastructurePrinters = value;
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
            this.srvPrinterType = SamsaraAppContext.Resolve<IPrinterTypeService>();
            Assert.IsNotNull(this.srvPrinterType);
            this.srvPrinterBrand = SamsaraAppContext.Resolve<IPrinterBrandService>();
            Assert.IsNotNull(this.srvPrinterBrand);

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
            this.customerInfrastructurePrinter = new CustomerInfrastructurePrinter();
            base.CreateRelation();
        }

        protected override void SaveRelation()
        {
            if (this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId == -1)
            {
                this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId = this.entityCounter--;
                this.customerInfrastructurePrinters.Add(this.customerInfrastructurePrinter);

                DataRow newRow = this.dtCustomerPrinters.NewRow();
                this.dtCustomerPrinters.Rows.Add(newRow);

                newRow["CustomerInfrastructurePrinterId"] = this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId;
                newRow["PrinterBrandId"] = this.customerInfrastructurePrinter.PrinterBrand.PrinterBrandId;
                newRow["PrinterTypeId"] = this.customerInfrastructurePrinter.PrinterType.PrinterTypeId;
                newRow["SerialNumber"] = this.customerInfrastructurePrinter.SerialNumber;

                this.dtCustomerPrinters.AcceptChanges();
            }
            base.SaveRelation();
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructurePrinter = this.customerInfrastructurePrinters
                .Single(x => x.CustomerInfrastructurePrinterId == entityId);

            this.customerInfrastructurePrinter.Activated = false;
            this.customerInfrastructurePrinter.Deleted = true;
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

        #endregion Protected

        #endregion Methods
    }
}
