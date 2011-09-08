
using Samsara.BaseForms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class EndUserSearchForm : GenericSearchForm<EndUser>
    {
        public EndUserSearchForm()
        {
            InitializeComponent();
        }

        public override EndUser GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
