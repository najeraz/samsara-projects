
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkWifiSearchForm : GenericSearchForm<CustomerInfrastructureNetworkWifi>
    {
        public CustomerInfrastructureNetworkWifiSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetworkWifi GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
