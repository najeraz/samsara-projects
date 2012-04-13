
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Controls.Controls;

namespace Samsara.AlleatoERP.Controls
{
    public partial class ERPCustomerChooserControl : SamsaraEntityChooserControl<ERPCustomer, int, IERPCustomerService, IERPCustomerDao, ERPCustomerParameters>
    {
        public ERPCustomerChooserControl()
        {
            assemblyName = "Samsara.AlleatoERP.Forms.dll";
            assemblyFormClassName = "Samsara.AlleatoERP.Forms.Forms.ERPCustomerForm";
            InitializeComponent();
        }
    }
}
