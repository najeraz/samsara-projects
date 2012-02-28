
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class DependencySearchForm : GenericCatalogSearchForm<Dependency>
    {
        public DependencySearchForm()
        {
            InitializeComponent();
        }

        public override Dependency GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
