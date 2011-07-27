
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class DependencySearchForm : GenericSearchForm<Dependency>
    {
        public DependencySearchForm()
        {
            InitializeComponent();
        }

        internal override Dependency GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
