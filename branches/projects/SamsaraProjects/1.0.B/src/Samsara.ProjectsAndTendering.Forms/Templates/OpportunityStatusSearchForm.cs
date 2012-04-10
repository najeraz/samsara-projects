
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class OpportunityStatusSearchForm : GenericCatalogSearchForm<OpportunityStatus>
    {
        public OpportunityStatusSearchForm()
        {
            InitializeComponent();
        }

        public override OpportunityStatus GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
