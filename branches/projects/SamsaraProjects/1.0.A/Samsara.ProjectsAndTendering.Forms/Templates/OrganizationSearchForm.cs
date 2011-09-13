
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class OrganizationSearchForm : GenericSearchForm<Organization>
    {
        public OrganizationSearchForm()
        {
            InitializeComponent();
        }

        public override Organization GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
