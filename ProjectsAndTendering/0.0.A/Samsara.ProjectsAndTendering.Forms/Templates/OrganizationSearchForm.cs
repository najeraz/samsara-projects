
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class OrganizationSearchForm : GenericSearchForm<Organization>
    {
        public OrganizationSearchForm()
        {
            InitializeComponent();
        }

        internal override Organization GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
