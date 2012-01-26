
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;

namespace Samsara.AlleatoERP.Controls.Controls
{
    public partial class ProductSublineChooserControl : SamsaraEntityChooserControl<ProductSubline, int, IProductSublineService, IProductSublineDao, ProductSublineParameters>
    {
        public ProductSublineChooserControl()
        {
            string controlsSchemaNamespace = Assembly.GetExecutingAssembly().FullName.Substring(0,
                Assembly.GetExecutingAssembly().FullName.IndexOf(","));

            string schemaNamespace = controlsSchemaNamespace
                .Substring(0, controlsSchemaNamespace.LastIndexOf("."));

            assemblyName = schemaNamespace + ".Forms.dll";
            assemblyFormClassName = schemaNamespace + ".Forms.Forms.ProductSublineForm";
            InitializeComponent();
        }
    }
}
