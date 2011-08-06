
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class OpportunityStatusSearchForm : GenericSearchForm<OpportunityStatus>
    {
        public OpportunityStatusSearchForm()
        {
            InitializeComponent();
        }

        internal override OpportunityStatus GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
