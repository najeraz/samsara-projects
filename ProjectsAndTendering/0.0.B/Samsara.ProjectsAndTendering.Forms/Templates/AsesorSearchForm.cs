
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class AsesorSearchForm : GenericSearchForm<Asesor>
    {
        public AsesorSearchForm()
        {
            InitializeComponent();
        }

        internal override Asesor GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
