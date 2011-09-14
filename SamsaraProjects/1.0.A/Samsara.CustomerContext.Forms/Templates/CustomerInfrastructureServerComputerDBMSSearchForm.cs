
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureServerComputerDBMSSearchForm : GenericSearchForm<CustomerInfrastructureServerComputerDBMS>
    {
        public CustomerInfrastructureServerComputerDBMSSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureServerComputerDBMS GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
