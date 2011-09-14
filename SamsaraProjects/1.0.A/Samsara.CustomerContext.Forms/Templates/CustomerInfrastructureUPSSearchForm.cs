
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureUPSSearchForm : GenericSearchForm<CustomerInfrastructureUPS>
    {
        public CustomerInfrastructureUPSSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureUPS GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
