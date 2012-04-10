
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class OperativeSystemSearchForm : GenericCatalogSearchForm<OperativeSystem>
    {
        public OperativeSystemSearchForm()
        {
            InitializeComponent();
        }

        public override OperativeSystem GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
