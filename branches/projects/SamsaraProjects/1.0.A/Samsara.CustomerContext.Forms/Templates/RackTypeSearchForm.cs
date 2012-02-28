
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class RackTypeSearchForm : GenericCatalogSearchForm<RackType>
    {
        public RackTypeSearchForm()
        {
            InitializeComponent();
        }

        public override RackType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
