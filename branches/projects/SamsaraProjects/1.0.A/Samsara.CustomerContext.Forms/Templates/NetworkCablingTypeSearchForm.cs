
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class NetworkCablingTypeSearchForm : GenericCatalogSearchForm<NetworkCablingType>
    {
        public NetworkCablingTypeSearchForm()
        {
            InitializeComponent();
        }

        public override NetworkCablingType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
