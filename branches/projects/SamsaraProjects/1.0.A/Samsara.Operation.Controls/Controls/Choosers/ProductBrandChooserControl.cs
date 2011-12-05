
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Dao.Interfaces;
using Samsara.Operation.Service.Interfaces;

namespace Samsara.Operation.Controls.Controls
{
    public partial class ProductBrandChooserControl : SamsaraEntityChooserControl<ProductBrand, int, IProductBrandService, IProductBrandDao, ProductBrandParameters>
    {
        public ProductBrandChooserControl()
        {
            string controlsSchemaNamespace = Assembly.GetExecutingAssembly().FullName.Substring(0,
                Assembly.GetExecutingAssembly().FullName.IndexOf(","));

            string schemaNamespace = controlsSchemaNamespace
                .Substring(0, controlsSchemaNamespace.LastIndexOf("."));

            assemblyName = schemaNamespace + ".Forms.dll";
            assemblyFormClassName = schemaNamespace + ".Forms.Forms.ProductBrandForm";
            InitializeComponent();
        }
    }
}
