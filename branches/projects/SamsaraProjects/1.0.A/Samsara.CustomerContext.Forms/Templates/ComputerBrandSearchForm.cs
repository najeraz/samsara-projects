
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class ComputerBrandSearchForm : GenericCatalogSearchForm<ComputerBrand>
    {
        public ComputerBrandSearchForm()
        {
            InitializeComponent();
        }

        public override ComputerBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
