
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class OperativeSystemTypeSearchForm : GenericCatalogSearchForm<OperativeSystemType>
    {
        public OperativeSystemTypeSearchForm()
        {
            InitializeComponent();
        }

        public override OperativeSystemType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
