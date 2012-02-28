
using Samsara.Base.Forms.Forms;
using Samsara.Main.Core.Entities;

namespace Samsara.Main.Forms.Templates
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
