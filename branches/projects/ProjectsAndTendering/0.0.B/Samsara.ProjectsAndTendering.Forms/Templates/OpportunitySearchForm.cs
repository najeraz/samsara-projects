
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

        internal override Opportunity GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
