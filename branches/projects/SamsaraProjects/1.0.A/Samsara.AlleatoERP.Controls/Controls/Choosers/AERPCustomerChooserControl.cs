
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Controls.Controls;

namespace Samsara.AlleatoERP.Controls.Controls
{
    public partial class AERPCustomerChooserControl : SamsaraEntityChooserControl<AERPCustomer, int, IAERPCustomerService, IAERPCustomerDao, AERPCustomerParameters>
    {
        public AERPCustomerChooserControl()
        {
            assemblyName = "Samsara.AlleatoERP.Forms.dll";
            assemblyFormClassName = "Samsara.AlleatoERP.Forms.Forms.AERPCustomerForm";
            InitializeComponent();
        }
    }
}
