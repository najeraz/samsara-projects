
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkWifiAccessPointSearchForm : GenericSearchForm<CustomerInfrastructureNetworkWifiAccessPoint>
    {
        public CustomerInfrastructureNetworkWifiAccessPointSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetworkWifiAccessPoint GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
