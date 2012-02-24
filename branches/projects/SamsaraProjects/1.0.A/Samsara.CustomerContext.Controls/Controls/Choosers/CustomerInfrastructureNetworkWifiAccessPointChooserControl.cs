
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class CustomerInfrastructureNetworkWifiAccessPointChooserControl : SamsaraEntityChooserControl<CustomerInfrastructureNetworkWifiAccessPoint, int, ICustomerInfrastructureNetworkWifiAccessPointService, ICustomerInfrastructureNetworkWifiAccessPointDao, CustomerInfrastructureNetworkWifiAccessPointParameters>
    {
        public CustomerInfrastructureNetworkWifiAccessPointChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerInfrastructureNetworkWifiAccessPointForm";
            InitializeComponent();
        }
    }
}
