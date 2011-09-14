
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureSearchForm : GenericSearchForm<CustomerInfrastructure>
    {
        public CustomerInfrastructureSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructure GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
