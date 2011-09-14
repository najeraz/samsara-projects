
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructurePersonalComputerSearchForm : GenericSearchForm<CustomerInfrastructurePersonalComputer>
    {
        public CustomerInfrastructurePersonalComputerSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructurePersonalComputer GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
