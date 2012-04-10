
using Samsara.Base.Forms.Forms;
using Samsara.Operation.Core.Entities;

namespace Samsara.Operation.Forms.Templates
{
    public partial class CurrencySearchForm : GenericCatalogSearchForm<Currency>
    {
        public CurrencySearchForm()
        {
            InitializeComponent();
        }

        public override Currency GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
