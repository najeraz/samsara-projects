
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class PrinterBrandSearchForm : GenericCatalogSearchForm<PrinterBrand>
    {
        public PrinterBrandSearchForm()
        {
            InitializeComponent();
        }

        public override PrinterBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
