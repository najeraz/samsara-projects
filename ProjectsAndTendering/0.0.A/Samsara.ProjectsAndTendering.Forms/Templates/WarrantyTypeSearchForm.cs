
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class WarrantyTypeSearchForm : GenericSearchForm<WarrantyType>
    {
        public WarrantyTypeSearchForm()
        {
            InitializeComponent();
        }

        internal override WarrantyType GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
