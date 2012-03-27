
using Samsara.Base.Controls.Controls;
using Samsara.Website.Core.Entities;
using Samsara.Website.Core.Parameters;
using Samsara.Website.Dao.Interfaces;
using Samsara.Website.Service.Interfaces;

namespace Samsara.Website.Controls.Controls
{
    public partial class ProductSublineConfigurationChooserControl : SamsaraEntityChooserControl<ProductSublineConfiguration, int, IProductSublineConfigurationService, IProductSublineConfigurationDao, ProductSublineConfigurationParameters>
    {
        public ProductSublineConfigurationChooserControl()
        {
            assemblyName = "Samsara.Website.Forms.dll";
            assemblyFormClassName = "Samsara.Website.Forms.Forms.ProductSublineConfigurationForm";
            InitializeComponent();
        }
    }
}
