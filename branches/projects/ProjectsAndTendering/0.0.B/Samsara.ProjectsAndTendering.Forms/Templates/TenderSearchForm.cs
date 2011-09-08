
using Samsara.ProjectsAndTendering.Core.Entities;

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
