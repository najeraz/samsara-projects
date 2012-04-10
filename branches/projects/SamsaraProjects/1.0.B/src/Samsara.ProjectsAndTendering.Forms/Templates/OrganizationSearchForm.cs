
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class OrganizationSearchForm : GenericCatalogSearchForm<Organization>
    {
        public OrganizationSearchForm()
        {
            InitializeComponent();
        }

        public override Organization GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
