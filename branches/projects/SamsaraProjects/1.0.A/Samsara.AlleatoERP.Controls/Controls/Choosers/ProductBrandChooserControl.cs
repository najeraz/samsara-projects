﻿
using Samsara.Base.Controls.Controls;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;

namespace Samsara.AlleatoERP.Controls.Controls
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
