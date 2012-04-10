
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class CustomerInfrastructureServerComputerDBMSChooserControl : SamsaraEntityChooserControl<CustomerInfrastructureServerComputerDBMS, int, ICustomerInfrastructureServerComputerDBMSService, ICustomerInfrastructureServerComputerDBMSDao, CustomerInfrastructureServerComputerDBMSParameters>
    {
        public CustomerInfrastructureServerComputerDBMSChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerInfrastructureServerComputerDBMSForm";
            InitializeComponent();
        }
    }
}
