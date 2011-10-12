
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class BusinessTypeSearchForm : GenericSearchForm<BusinessType>
    {
        public BusinessTypeSearchForm()
        {
            InitializeComponent();
        }

        public override BusinessType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
