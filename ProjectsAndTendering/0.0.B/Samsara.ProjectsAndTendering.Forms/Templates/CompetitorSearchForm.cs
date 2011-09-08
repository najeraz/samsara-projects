
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class CompetitorSearchForm : GenericSearchForm<Competitor>
    {
        public CompetitorSearchForm()
        {
            InitializeComponent();
        }

        internal override Competitor GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
