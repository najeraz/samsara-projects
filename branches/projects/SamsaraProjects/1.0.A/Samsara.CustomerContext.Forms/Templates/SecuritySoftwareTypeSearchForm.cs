
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class SecuritySoftwareTypeSearchForm : GenericCatalogSearchForm<SecuritySoftwareType>
    {
        public SecuritySoftwareTypeSearchForm()
        {
            InitializeComponent();
        }

        public override SecuritySoftwareType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
