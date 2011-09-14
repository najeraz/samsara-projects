
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructureTelephonySearchForm : GenericSearchForm<CustomerInfrastructureTelephony>
    {
        public CustomerInfrastructureTelephonySearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructureTelephony GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
