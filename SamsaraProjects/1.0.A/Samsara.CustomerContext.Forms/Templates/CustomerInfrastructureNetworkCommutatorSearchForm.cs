
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureNetworkCommutatorSearchForm : GenericSearchForm<CustomerInfrastructureNetworkCommutator>
    {
        public CustomerInfrastructureNetworkCommutatorSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureNetworkCommutator GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
