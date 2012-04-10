
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class TelephonyLineTypeSearchForm : GenericCatalogSearchForm<TelephonyLineType>
    {
        public TelephonyLineTypeSearchForm()
        {
            InitializeComponent();
        }

        public override TelephonyLineType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
