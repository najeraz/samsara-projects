
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class TenderSearchForm : GenericCatalogSearchForm<Tender>
    {
        public TenderSearchForm()
        {
            InitializeComponent();
        }

        public override Tender GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
