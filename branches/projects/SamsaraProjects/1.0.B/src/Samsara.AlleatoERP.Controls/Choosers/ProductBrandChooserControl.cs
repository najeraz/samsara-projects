
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Controls.Controls;

namespace Samsara.AlleatoERP.Controls
{
    public partial class ProductBrandChooserControl : SamsaraEntityChooserControl<ProductBrand, int, IProductBrandService, IProductBrandDao, ProductBrandParameters>
    {
        public ProductBrandChooserControl()
        {
            assemblyName = "Samsara.AlleatoERP.Forms.dll";
            assemblyFormClassName = "Samsara.AlleatoERP.Forms.Forms.ProductBrandForm";
            InitializeComponent();
        }
    }
}
