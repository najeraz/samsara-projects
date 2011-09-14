
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkFirewallSearchForm : GenericSearchForm<CustomerInfrastructureNetworkFirewall>
    {
        public CustomerInfrastructureNetworkFirewallSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetworkFirewall GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
