
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructurePrinterSearchForm : GenericSearchForm<CustomerInfrastructurePrinter>
    {
        public CustomerInfrastructurePrinterSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructurePrinter GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
