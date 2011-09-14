
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkSiteRackSearchForm : GenericSearchForm<CustomerInfrastructureNetworkSiteRack>
    {
        public CustomerInfrastructureNetworkSiteRackSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetworkSiteRack GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
