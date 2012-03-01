
using Samsara.Base.Forms.Forms;
using Samsara.Configuration.Core.Entities;

namespace Samsara.Configuration.Forms.Templates
{
    public partial class UserPermissionSearchForm : GenericCatalogSearchForm<UserPermission>
    {
        public UserPermissionSearchForm()
        {
            InitializeComponent();
        }

        public override UserPermission GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
