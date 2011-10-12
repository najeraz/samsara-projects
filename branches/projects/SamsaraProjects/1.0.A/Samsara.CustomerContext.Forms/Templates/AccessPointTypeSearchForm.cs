
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class AccessPointTypeSearchForm : GenericSearchForm<AccessPointType>
    {
        public AccessPointTypeSearchForm()
        {
            InitializeComponent();
        }

        public override AccessPointType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
