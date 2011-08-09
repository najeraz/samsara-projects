
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class WholesalerSearchForm : GenericSearchForm<Wholesaler>
    {
        public WholesalerSearchForm()
        {
            InitializeComponent();
        }

        internal override Wholesaler GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
