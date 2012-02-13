
using Samsara.Base.Forms.Forms;
using Samsara.Main.Core.Entities;

namespace Samsara.Main.Forms.Templates
{
    public partial class UserPermissionsSearchForm : GenericSearchForm<UserPermissions>
    {
        public UserPermissionsSearchForm()
        {
            InitializeComponent();
        }

        public override UserPermissions GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
