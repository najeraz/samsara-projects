
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class CustomerInfrastructureNetworkCommutatorChooserControl : SamsaraEntityChooserControl<CustomerInfrastructureNetworkCommutator, int, ICustomerInfrastructureNetworkCommutatorService, ICustomerInfrastructureNetworkCommutatorDao, CustomerInfrastructureNetworkCommutatorParameters>
    {
        public CustomerInfrastructureNetworkCommutatorChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerInfrastructureNetworkCommutatorForm";
            InitializeComponent();
        }
    }
}
