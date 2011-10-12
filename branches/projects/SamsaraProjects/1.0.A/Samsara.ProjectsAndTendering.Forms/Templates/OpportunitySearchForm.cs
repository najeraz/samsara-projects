
using Samsara.Base.Forms.Forms;
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

        public override Opportunity GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
