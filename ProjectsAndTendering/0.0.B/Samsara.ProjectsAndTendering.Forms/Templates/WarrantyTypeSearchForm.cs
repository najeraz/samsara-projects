
using Samsara.BaseForms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class WarrantyTypeSearchForm : GenericSearchForm<WarrantyType>
    {
        public WarrantyTypeSearchForm()
        {
            InitializeComponent();
        }

        public override WarrantyType GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
