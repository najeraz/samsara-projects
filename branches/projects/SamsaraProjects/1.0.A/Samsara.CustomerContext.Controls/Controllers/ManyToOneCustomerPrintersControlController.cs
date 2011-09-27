
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

namespace Samsara.CustomerContext.Controls.Controllers
{
    public class ManyToOneCustomerPrintersControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ManyToOneCustomerPrintersControl controlManyToOneCustomerPrinters;
        private ICustomerInfrastructurePrinterService srvICustomerInfrastructurePrinter;
        private CustomerInfrastructurePrinter entCustomerInfrastructurePrinter;

        private DataTable dtCustomerPrinters;

        #endregion Attributes

        #region Constructor

        public ManyToOneCustomerPrintersControlController(
            ManyToOneCustomerPrintersControl instance) : base(instance)  
        {
            this.controlManyToOneCustomerPrinters = instance;

            this.srvICustomerInfrastructurePrinter = SamsaraAppContext.Resolve<ICustomerInfrastructurePrinterService>();
            Assert.IsNotNull(this.srvICustomerInfrastructurePrinter);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public override void InitializeControlControls()
        {
            CustomerInfrastructurePrinterParameters pmtCustomerInfrastructurePrinter
                = new CustomerInfrastructurePrinterParameters();

            base.InitializeControlControls();

            pmtCustomerInfrastructurePrinter.CustomerInfrastructureId = ParameterConstants.IntNone;
            this.dtCustomerPrinters = this.srvICustomerInfrastructurePrinter
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
                int customerInfrastructureId = Convert.ToInt32((activeRow.ListObject as DataRowView).Row[0]);
                this.entCustomerInfrastructurePrinter = this.srvICustomerInfrastructurePrinter
                    .GetById(customerInfrastructureId);

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
        }

        #endregion Private

        #endregion Methods
    }
}
