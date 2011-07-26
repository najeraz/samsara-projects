
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class TenderSearchForm : GenericSearchForm<Tender>
    {
        public TenderSearchForm()
        {
            InitializeComponent();
        }

        internal override Tender GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
