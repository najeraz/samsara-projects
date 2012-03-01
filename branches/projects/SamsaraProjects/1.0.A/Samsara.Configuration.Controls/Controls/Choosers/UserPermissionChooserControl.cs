
using Samsara.Base.Controls.Controls;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Dao.Interfaces;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Configuration.Controls.Controls
{
    public partial class UserPermissionChooserControl : SamsaraEntityChooserControl<UserPermission, int, IUserPermissionService, IUserPermissionDao, UserPermissionParameters>
    {
        public UserPermissionChooserControl()
        {
            assemblyName = "Samsara.Configuration.Forms.dll";
            assemblyFormClassName = "Samsara.Configuration.Forms.Forms.UserPermissionForm";
            InitializeComponent();
        }
    }
}
