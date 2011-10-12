
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class TelephonyProviderSearchForm : GenericSearchForm<TelephonyProvider>
    {
        public TelephonyProviderSearchForm()
        {
            InitializeComponent();
        }

        public override TelephonyProvider GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
