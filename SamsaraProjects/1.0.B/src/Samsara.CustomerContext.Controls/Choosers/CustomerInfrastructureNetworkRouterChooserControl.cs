
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Choosers
{
    public partial class CustomerInfrastructureNetworkRouterChooserControl : SamsaraEntityChooserControl<CustomerInfrastructureNetworkRouter, int, ICustomerInfrastructureNetworkRouterService, ICustomerInfrastructureNetworkRouterDao, CustomerInfrastructureNetworkRouterParameters>
    {
        public CustomerInfrastructureNetworkRouterChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerInfrastructureNetworkRouterForm";
            InitializeComponent();
        }
    }
}
