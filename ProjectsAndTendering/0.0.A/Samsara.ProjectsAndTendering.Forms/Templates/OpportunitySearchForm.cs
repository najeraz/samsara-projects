
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class OpportunitySearchForm : GenericSearchForm<Opportunity>
    {
        public OpportunitySearchForm()
        {
            InitializeComponent();
        }

        internal override Opportunity GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
