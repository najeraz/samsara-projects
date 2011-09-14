
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkSwitchSearchForm : GenericSearchForm<CustomerInfrastructureNetworkSwitch>
    {
        public CustomerInfrastructureNetworkSwitchSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetworkSwitch GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
