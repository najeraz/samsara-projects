
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Base.Controls.Controls;

namespace Samsara.CustomerContext.Controls
{
    public partial class CustomerChooserControl : SamsaraEntityChooserControl<Customer, int, ICustomerService, ICustomerDao, CustomerParameters>
    {
        public CustomerChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerForm";
            InitializeComponent();
        }
    }
}
