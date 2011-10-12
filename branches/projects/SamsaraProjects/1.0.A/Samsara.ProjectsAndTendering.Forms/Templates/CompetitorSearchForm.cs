
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class CompetitorSearchForm : GenericSearchForm<Competitor>
    {
        public CompetitorSearchForm()
        {
            InitializeComponent();
        }

        public override Competitor GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
