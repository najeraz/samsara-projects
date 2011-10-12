
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class EndUserSearchForm : GenericSearchForm<EndUser>
    {
        public EndUserSearchForm()
        {
            InitializeComponent();
        }

        public override EndUser GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
