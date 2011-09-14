
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureCCTVSearchForm : GenericSearchForm<CustomerInfrastructureCCTV>
    {
        public CustomerInfrastructureCCTVSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureCCTV GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
