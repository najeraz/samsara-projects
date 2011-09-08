
using Samsara.BaseForms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class OpportunitySearchForm : GenericSearchForm<Opportunity>
    {
        public OpportunitySearchForm()
        {
            InitializeComponent();
        }

        public override void PrepareSearchControls()
        {
            base.PrepareSearchControls();
        }

        public override Opportunity GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
