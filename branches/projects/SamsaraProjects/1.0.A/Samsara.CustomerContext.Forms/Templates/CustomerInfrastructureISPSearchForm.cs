
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureISPSearchForm : GenericSearchForm<CustomerInfrastructureISP>
    {
        public CustomerInfrastructureISPSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureISP GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
