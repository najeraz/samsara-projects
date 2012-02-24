
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class CustomerInfrastructureSecuritySoftwareChooserControl : SamsaraEntityChooserControl<CustomerInfrastructureSecuritySoftware, int, ICustomerInfrastructureSecuritySoftwareService, ICustomerInfrastructureSecuritySoftwareDao, CustomerInfrastructureSecuritySoftwareParameters>
    {
        public CustomerInfrastructureSecuritySoftwareChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerInfrastructureSecuritySoftwareForm";
            InitializeComponent();
        }
    }
}
