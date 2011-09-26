
using Samsara.Controls.Controllers;
using Samsara.CustomerContext.Controls.Controls;
using Samsara.Controls.Controls;

namespace Samsara.CustomerContext.Controls.Controllers
{
    public class ManyToOneCustomerPrintersControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ManyToOneCustomerPrintersControl controlManyToOneCustomerPrinters;

        #endregion Attributes

        #region Constructor

        public ManyToOneCustomerPrintersControlController(ManyToOneCustomerPrintersControl instance)
            : base(instance)  
        {
            this.controlManyToOneCustomerPrinters = instance;
        }

        #endregion Constructor
    }
}
