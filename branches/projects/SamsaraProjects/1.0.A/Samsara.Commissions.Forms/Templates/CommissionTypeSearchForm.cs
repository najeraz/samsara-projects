
using Samsara.Base.Forms.Forms;
using Samsara.Commissions.Core.Entities;

namespace Samsara.Commissions.Forms.Templates
{
    public partial class CommissionTypeSearchForm : GenericCatalogSearchForm<CommissionType>
    {
        public CommissionTypeSearchForm()
        {
            InitializeComponent();
        }

        public override CommissionType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
