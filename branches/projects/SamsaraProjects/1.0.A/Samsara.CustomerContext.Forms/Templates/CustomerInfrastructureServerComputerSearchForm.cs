
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureServerComputerSearchForm : GenericSearchForm<CustomerInfrastructureServerComputer>
    {
        public CustomerInfrastructureServerComputerSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureServerComputer GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
