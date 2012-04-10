
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerInfrastructurePrinterClassificationSearchForm : GenericSearchForm<CustomerInfrastructurePrinterClassification>
    {
        public CustomerInfrastructurePrinterClassificationSearchForm()
        {
            InitializeComponent();
        }

        public override CustomerInfrastructurePrinterClassification GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
