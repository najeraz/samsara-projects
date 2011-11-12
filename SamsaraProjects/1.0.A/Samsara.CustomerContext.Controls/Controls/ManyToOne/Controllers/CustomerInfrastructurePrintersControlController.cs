
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Controls.EventsArgs;
using Samsara.Base.Core.Context;
using Samsara.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Enums;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers
{
    public class CustomerInfrastructurePrintersControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructurePrinterService srvCustomerInfrastructurePrinter;
        private CustomerInfrastructurePrintersControl controlCustomerInfrastructurePrinters;
        private CustomerInfrastructurePrinter customerInfrastructurePrinter;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IPrinterBrandService srvPrinterBrand;
        private IPrinterTypeService srvPrinterType;

        private DataTable dtCustomerInfrastructurePrinters;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }

        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructurePrintersControlController(
            CustomerInfrastructurePrintersControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructurePrinters = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructurePrinter = SamsaraAppContext.Resolve<ICustomerInfrastructurePrinterService>();
                Assert.IsNotNull(this.srvCustomerInfrastructurePrinter);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvPrinterBrand = SamsaraAppContext.Resolve<IPrinterBrandService>();
                Assert.IsNotNull(this.srvPrinterBrand);
                this.srvPrinterType = SamsaraAppContext.Resolve<IPrinterTypeService>();
                Assert.IsNotNull(this.srvPrinterType);
            }

            this.InitializeControlControls();
        }

        #endregion Constructor

        #region Methods

        #region Private

        private void InitializeControlControls()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                PrinterBrandParameters pmtPrinterBrand = new PrinterBrandParameters();

                this.controlCustomerInfrastructurePrinters.pbcPrinterBrand.Parameters = pmtPrinterBrand;
                this.controlCustomerInfrastructurePrinters.pbcPrinterBrand.Refresh();

                PrinterTypeParameters pmtPrinterType = new PrinterTypeParameters();

                this.controlCustomerInfrastructurePrinters.ptcPrinterType.Parameters = pmtPrinterType;
                this.controlCustomerInfrastructurePrinters.ptcPrinterType.Refresh();

                CustomerInfrastructurePrinterClassificationParameters pmtCustomerInfrastructurePrinterClassification
                    = new CustomerInfrastructurePrinterClassificationParameters();

                this.controlCustomerInfrastructurePrinters.cipccCustomerInfrastructurePrinterClassification
                    .Parameters = pmtCustomerInfrastructurePrinterClassification;
                this.controlCustomerInfrastructurePrinters.cipccCustomerInfrastructurePrinterClassification.Refresh();

                this.controlCustomerInfrastructurePrinters
                    .cipccCustomerInfrastructurePrinterClassification.ValueChanged
                    +=new Base.Controls.EventsHandlers.SamsaraEntityChooserValueChangedEventHandler
                        <CustomerInfrastructurePrinterClassification>
                        (cipccCustomerInfrastructurePrinterClassification_ValueChanged);

                this.controlCustomerInfrastructurePrinters.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructurePrinterParameters pmtCustomerInfrastructurePrinter
                = new CustomerInfrastructurePrinterParameters();

            pmtCustomerInfrastructurePrinter.CustomerInfrastructureId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructurePrinters = this.srvCustomerInfrastructurePrinter
                .SearchByParameters(pmtCustomerInfrastructurePrinter);

            this.controlCustomerInfrastructurePrinters.grdRelations.DataSource = null;
            this.controlCustomerInfrastructurePrinters.grdRelations.DataSource = this.dtCustomerInfrastructurePrinters;

            if (this.CustomerInfrastructure != null)
            {
                foreach (CustomerInfrastructurePrinter customerInfrastructurePrinter
                    in this.CustomerInfrastructure.CustomerInfrastructurePrinters)
                {
                    DataRow row = this.dtCustomerInfrastructurePrinters.NewRow();
                    this.dtCustomerInfrastructurePrinters.Rows.Add(row);

                    row["CustomerInfrastructurePrinterId"] = customerInfrastructurePrinter.CustomerInfrastructurePrinterId;
                    row["PrinterBrandId"] = customerInfrastructurePrinter.PrinterBrand.PrinterBrandId;
                    row["PrinterTypeId"] = customerInfrastructurePrinter.PrinterType.PrinterTypeId;
                    row["SerialNumber"] = customerInfrastructurePrinter.SerialNumber;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructurePrinters.pbcPrinterBrand.Value = null;
            this.controlCustomerInfrastructurePrinters.ptcPrinterType.Value = null;
            this.controlCustomerInfrastructurePrinters.txtlSerialNumber.Text = string.Empty;
            this.controlCustomerInfrastructurePrinters.cipccCustomerInfrastructurePrinterClassification.Value = null;
            this.controlCustomerInfrastructurePrinters.steQuantity.Value = null;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructurePrinters.Rows.Clear();
            this.dtCustomerInfrastructurePrinters.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructurePrinter = new CustomerInfrastructurePrinter();

            this.customerInfrastructurePrinter.CustomerInfrastructure = this.CustomerInfrastructure;
            this.customerInfrastructurePrinter.Activated = true;
            this.customerInfrastructurePrinter.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructurePrinter = this.CustomerInfrastructure.CustomerInfrastructurePrinters
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructurePrinter = this.CustomerInfrastructure.CustomerInfrastructurePrinters
                    .Single(x => x.CustomerInfrastructurePrinterId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructurePrinters.Remove(this.customerInfrastructurePrinter);
            else
            {
                this.customerInfrastructurePrinter.Activated = false;
                this.customerInfrastructurePrinter.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructurePrinter = this.CustomerInfrastructure.CustomerInfrastructurePrinters
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructurePrinter = this.CustomerInfrastructure.CustomerInfrastructurePrinters
                    .Single(x => x.CustomerInfrastructurePrinterId == entityId);

            this.controlCustomerInfrastructurePrinters.pbcPrinterBrand.Value
                = this.customerInfrastructurePrinter.PrinterBrand;

            this.controlCustomerInfrastructurePrinters.ptcPrinterType.Value
                = this.customerInfrastructurePrinter.PrinterType;

            this.controlCustomerInfrastructurePrinters.txtlSerialNumber.Text
                = this.customerInfrastructurePrinter.SerialNumber;

            this.controlCustomerInfrastructurePrinters.cipccCustomerInfrastructurePrinterClassification.Value
                = this.customerInfrastructurePrinter.CustomerInfrastructurePrinterClassification;

            this.controlCustomerInfrastructurePrinters.steQuantity.Value
                = this.customerInfrastructurePrinter.Quantity;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructurePrinter.PrinterBrand 
                = this.controlCustomerInfrastructurePrinters.pbcPrinterBrand.Value;

            this.customerInfrastructurePrinter.PrinterType
                = this.controlCustomerInfrastructurePrinters.ptcPrinterType.Value;

            this.customerInfrastructurePrinter.SerialNumber
                = this.controlCustomerInfrastructurePrinters.txtlSerialNumber.Text;

            this.customerInfrastructurePrinter.CustomerInfrastructurePrinterClassification
                = this.controlCustomerInfrastructurePrinters.cipccCustomerInfrastructurePrinterClassification.Value;

            if (this.controlCustomerInfrastructurePrinters.steQuantity.Value == null
                || this.controlCustomerInfrastructurePrinters.steQuantity.Value.ToString().Trim() == string.Empty)
                this.customerInfrastructurePrinter.Quantity = null;
            else
                this.customerInfrastructurePrinter.Quantity
                    = Convert.ToInt32(this.controlCustomerInfrastructurePrinters.steQuantity.Value);
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructurePrinters.pbcPrinterBrand.Value == null)
            {
                MessageBox.Show("Favor de seleccionar la Marca de Impresora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePrinters.pbcPrinterBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructurePrinters.ptcPrinterType.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de Impresora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePrinters.ptcPrinterType.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructurePrinters
                .cipccCustomerInfrastructurePrinterClassification.Value == null)
            {
                MessageBox.Show("Favor de seleccionar la Clasificación de la(s) Impresoras(s).",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePrinters
                    .cipccCustomerInfrastructurePrinterClassification.Focus();
                return false;
            }

            if ((CustomerInfrastructurePrinterClassificationEnum)this.controlCustomerInfrastructurePrinters
                .cipccCustomerInfrastructurePrinterClassification.Value.CustomerInfrastructurePrinterClassificationId
                == CustomerInfrastructurePrinterClassificationEnum.Multiple
                && (this.controlCustomerInfrastructurePrinters.steQuantity.Value == null
                || string.IsNullOrEmpty(this.controlCustomerInfrastructurePrinters.steQuantity.Value.ToString())))
            {
                MessageBox.Show("Favor de seleccionar la Cantidad de las Impresoras.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePrinters.steQuantity.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId == -1)
                row = this.dtCustomerInfrastructurePrinters.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructurePrinterId"])
                        == -(this.customerInfrastructurePrinter as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructurePrinters.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructurePrinterId"])
                        == this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructurePrinters.Add(this.customerInfrastructurePrinter);

                row = this.dtCustomerInfrastructurePrinters.NewRow();
                this.dtCustomerInfrastructurePrinters.Rows.Add(row);
            }

            if (this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId == -1)
                row["CustomerInfrastructurePrinterId"] = -(this.customerInfrastructurePrinter as object).GetHashCode();
            else
                row["CustomerInfrastructurePrinterId"] = this.customerInfrastructurePrinter.CustomerInfrastructurePrinterId;

            row["PrinterBrandId"] = this.customerInfrastructurePrinter.PrinterBrand.PrinterBrandId;
            row["PrinterTypeId"] = this.customerInfrastructurePrinter.PrinterType.PrinterTypeId;
            row["SerialNumber"] = this.customerInfrastructurePrinter.SerialNumber;

            this.dtCustomerInfrastructurePrinters.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructurePrinters.ptcPrinterType.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePrinters.pbcPrinterBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePrinters.txtlSerialNumber.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePrinters.cipccCustomerInfrastructurePrinterClassification.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePrinters.steQuantity.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            PrinterBrandParameters pmtPrinterBrand = new PrinterBrandParameters();

            IList<PrinterBrand> printerBrands = this.srvPrinterBrand.GetListByParameters(pmtPrinterBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, printerBrands,
                band.Columns["PrinterBrandId"], "PrinterBrandId", "Name", "Seleccione");

            PrinterTypeParameters pmtPrinterType = new PrinterTypeParameters();

            IList<PrinterType> printerTypes = this.srvPrinterType.GetListByParameters(pmtPrinterType);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, printerTypes,
                band.Columns["PrinterTypeId"], "PrinterTypeId", "Name", "Seleccione");
        }

        private void cipccCustomerInfrastructurePrinterClassification_ValueChanged(object sender,
            SamsaraEntityChooserValueChangedEventArgs<CustomerInfrastructurePrinterClassification> e)
        {
            if (e.NewValue != null)
            {
                bool isUnique = (CustomerInfrastructurePrinterClassificationEnum)
                    e.NewValue.CustomerInfrastructurePrinterClassificationId
                    == CustomerInfrastructurePrinterClassificationEnum.Unique;

                this.controlCustomerInfrastructurePrinters.steQuantity.Visible = !isUnique;
                this.controlCustomerInfrastructurePrinters.ulblQuantity.Visible = !isUnique;
                this.controlCustomerInfrastructurePrinters.txtlSerialNumber.Visible = isUnique;
                this.controlCustomerInfrastructurePrinters.lblSerialNumber.Visible = isUnique;
            }
        }

        #endregion Events
    }
}
