
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class WarrantySearchForm : GenericSearchForm<Warranty>
    {
        public WarrantySearchForm()
        {
            InitializeComponent();
        }

        internal override Warranty GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
