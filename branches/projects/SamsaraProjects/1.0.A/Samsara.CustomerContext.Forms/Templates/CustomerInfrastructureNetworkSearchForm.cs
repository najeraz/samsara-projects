
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkSearchForm : GenericSearchForm<CustomerInfrastructureNetwork>
    {
        public CustomerInfrastructureNetworkSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetwork GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
