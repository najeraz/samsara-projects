
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.Website.Core.Entities;
using Samsara.Website.Core.Parameters;
using Samsara.Website.Dao.Interfaces;
using Samsara.Website.Service.Interfaces;

namespace Samsara.Website.Controls.Controls
{
    public partial class ProductLineConfigurationSamsaraBusinessUnitChooserControl : SamsaraEntityChooserControl<ProductLineConfigurationSamsaraBusinessUnit, int, IProductLineConfigurationSamsaraBusinessUnitService, IProductLineConfigurationSamsaraBusinessUnitDao, ProductLineConfigurationSamsaraBusinessUnitParameters>
    {
        public ProductLineConfigurationSamsaraBusinessUnitChooserControl()
        {
            assemblyName = "Samsara.Website.Forms.dll";
            assemblyFormClassName = "Samsara.Website.Forms.Forms.ProductLineConfigurationSamsaraBusinessUnitForm";
            InitializeComponent();
        }
    }
}
