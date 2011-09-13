
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class TenderStatusSearchForm : GenericSearchForm<TenderStatus>
    {
        public TenderStatusSearchForm()
        {
            InitializeComponent();
        }

        public override TenderStatus GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
