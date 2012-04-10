
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class CustomerInfrastructureNetworkSiteChooserControl : SamsaraEntityChooserControl<CustomerInfrastructureNetworkSite, int, ICustomerInfrastructureNetworkSiteService, ICustomerInfrastructureNetworkSiteDao, CustomerInfrastructureNetworkSiteParameters>
    {
        public CustomerInfrastructureNetworkSiteChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerInfrastructureNetworkSiteForm";
            InitializeComponent();
        }
    }
}
