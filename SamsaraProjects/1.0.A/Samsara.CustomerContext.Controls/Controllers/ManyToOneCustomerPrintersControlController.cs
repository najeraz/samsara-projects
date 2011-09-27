
using Samsara.Controls.Controllers;
using Samsara.CustomerContext.Controls.Controls;
using Samsara.Controls.Controls;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Base.Core.Context;
using NUnit.Framework;
using Samsara.CustomerContext.Core.Entities;
using Infragistics.Win.UltraWinGrid;

namespace Samsara.CustomerContext.Controls.Controllers
{
    public class ManyToOneCustomerPrintersControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ManyToOneCustomerPrintersControl controlManyToOneCustomerPrinters;
        private ICustomerInfrastructurePrinterService srvICustomerInfrastructurePrinter;
        private CustomerInfrastructurePrinter entCustomerInfrastructurePrinter;

        #endregion Attributes

        #region Constructor

        public ManyToOneCustomerPrintersControlController(ManyToOneCustomerPrintersControl instance)
            : base(instance)  
        {
            this.controlManyToOneCustomerPrinters = instance;

            this.srvICustomerInfrastructurePrinter = SamsaraAppContext.Resolve<ICustomerInfrastructurePrinterService>();
            Assert.IsNotNull(this.srvICustomerInfrastructurePrinter);
        }

        #endregion Constructor

        #region Methods

        public override void InitializeControlControls()
        {
            base.InitializeControlControls();
        }
        
        #region Public

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

            }
        }

        public override void SaveRelation()
        {
            base.SaveRelation();
        }

        #endregion Public

        #endregion Methods
    }
}
