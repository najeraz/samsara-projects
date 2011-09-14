
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkSiteSearchForm : GenericSearchForm<CustomerInfrastructureNetworkSite>
    {
        public CustomerInfrastructureNetworkSiteSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetworkSite GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
