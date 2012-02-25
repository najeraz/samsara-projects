
using Samsara.Base.Controls.Controls;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Dao.Interfaces;
using Samsara.Operation.Service.Interfaces;

namespace Samsara.Operation.Controls.Controls
{
    public partial class ProductChooserControl : SamsaraEntityChooserControl<Product, int, IProductService, IProductDao, ProductParameters>
    {
        public ProductChooserControl()
        {
            assemblyName = "Samsara.Operation.Forms.dll";
            assemblyFormClassName = "Samsara.Operation.Forms.Forms.ProductForm";
            InitializeComponent();
        }
    }
}
