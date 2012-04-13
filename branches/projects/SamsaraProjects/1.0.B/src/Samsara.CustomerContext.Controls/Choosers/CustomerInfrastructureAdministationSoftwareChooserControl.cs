
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Choosers
{
    public partial class CustomerInfrastructureAdministationSoftwareChooserControl : SamsaraEntityChooserControl<CustomerInfrastructureAdministationSoftware, int, ICustomerInfrastructureAdministationSoftwareService, ICustomerInfrastructureAdministationSoftwareDao, CustomerInfrastructureAdministationSoftwareParameters>
    {
        public CustomerInfrastructureAdministationSoftwareChooserControl()
        {
            assemblyName = "Samsara.CustomerContextForms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerInfrastructureAdministationSoftwareForm";
            InitializeComponent();
        }
    }
}
