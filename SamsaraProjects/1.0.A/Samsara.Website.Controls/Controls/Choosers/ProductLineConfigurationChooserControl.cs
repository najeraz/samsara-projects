
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.Website.Core.Entities;
using Samsara.Website.Core.Parameters;
using Samsara.Website.Dao.Interfaces;
using Samsara.Website.Service.Interfaces;

namespace Samsara.Website.Controls.Controls
{
    public partial class ProductLineConfigurationChooserControl : SamsaraEntityChooserControl<ProductLineConfiguration, int, IProductLineConfigurationService, IProductLineConfigurationDao, ProductLineConfigurationParameters>
    {
        public ProductLineConfigurationChooserControl()
        {
            assemblyName = "Samsara.Website.Forms.dll";
            assemblyFormClassName = "Samsara.Website.Forms.Forms.ProductLineConfigurationForm";
            InitializeComponent();
        }
    }
}
