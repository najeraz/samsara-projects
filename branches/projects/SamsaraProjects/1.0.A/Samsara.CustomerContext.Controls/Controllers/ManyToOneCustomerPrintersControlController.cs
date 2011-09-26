
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

        #region Methods
        
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
            base.EditRelation();
        }

        public override void SaveRelation()
        {
            base.SaveRelation();
        }

        #endregion Public

        #endregion Methods
    }
}
