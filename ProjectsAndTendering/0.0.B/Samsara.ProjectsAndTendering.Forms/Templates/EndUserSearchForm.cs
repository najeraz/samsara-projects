
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class EndUserSearchForm : GenericSearchForm<EndUser>
    {
        public EndUserSearchForm()
        {
            InitializeComponent();
        }

        internal override EndUser GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
