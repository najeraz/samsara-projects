
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkRouterSearchForm : GenericSearchForm<CustomerInfrastructureNetworkRouter>
    {
        public CustomerInfrastructureNetworkRouterSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetworkRouter GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
