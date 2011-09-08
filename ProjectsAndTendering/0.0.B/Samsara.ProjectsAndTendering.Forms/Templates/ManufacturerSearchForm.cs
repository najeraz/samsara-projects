
using Samsara.BaseForms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class ManufacturerSearchForm : GenericSearchForm<Manufacturer>
    {
        public ManufacturerSearchForm()
        {
            InitializeComponent();
        }

        public override Manufacturer GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
