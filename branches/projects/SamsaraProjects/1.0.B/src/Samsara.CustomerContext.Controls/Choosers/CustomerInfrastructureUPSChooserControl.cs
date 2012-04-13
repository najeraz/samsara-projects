
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Choosers
{
    public partial class CustomerInfrastructureUPSChooserControl : SamsaraEntityChooserControl<CustomerInfrastructureUPS, int, ICustomerInfrastructureUPSService, ICustomerInfrastructureUPSDao, CustomerInfrastructureUPSParameters>
    {
        public CustomerInfrastructureUPSChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CustomerInfrastructureUPSForm";
            InitializeComponent();
        }
    }
}
