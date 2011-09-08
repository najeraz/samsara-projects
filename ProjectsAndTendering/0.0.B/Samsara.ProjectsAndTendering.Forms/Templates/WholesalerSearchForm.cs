
using Samsara.BaseForms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class WholesalerSearchForm : GenericSearchForm<Wholesaler>
    {
        public WholesalerSearchForm()
        {
            InitializeComponent();
        }

        public override Wholesaler GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
