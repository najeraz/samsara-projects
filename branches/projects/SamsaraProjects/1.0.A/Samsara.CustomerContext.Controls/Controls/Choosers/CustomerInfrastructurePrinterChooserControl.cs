
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class CustomerInfrastructurePrinterChooserControl : SamsaraEntityChooserControl<CustomerInfrastructurePrinter, int, ICustomerInfrastructurePrinterService, ICustomerInfrastructurePrinterDao, CustomerInfrastructurePrinterParameters>
    {
        public CustomerInfrastructurePrinterChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerInfrastructurePrinterForm";
            InitializeComponent();
        }
    }
}
