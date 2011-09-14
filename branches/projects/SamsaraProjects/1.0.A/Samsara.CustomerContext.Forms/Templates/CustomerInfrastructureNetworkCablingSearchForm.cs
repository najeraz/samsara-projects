
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkCablingSearchForm : GenericSearchForm<CustomerInfrastructureNetworkCabling>
    {
        public CustomerInfrastructureNetworkCablingSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetworkCabling GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
