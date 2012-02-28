
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class AsesorSearchForm : GenericCatalogSearchForm<Asesor>
    {
        public AsesorSearchForm()
        {
            InitializeComponent();
        }

        public override Asesor GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
