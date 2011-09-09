
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class AsesorSearchForm : GenericSearchForm<Asesor>
    {
        public AsesorSearchForm()
        {
            InitializeComponent();
        }

        public override Asesor GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
