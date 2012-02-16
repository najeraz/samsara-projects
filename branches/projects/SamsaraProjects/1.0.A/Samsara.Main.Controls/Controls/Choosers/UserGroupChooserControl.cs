
using Samsara.Base.Controls.Controls;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Dao.Interfaces;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Controls.Controls
{
    public partial class UserGroupChooserControl : SamsaraEntityChooserControl<UserGroup, int, IUserGroupService, IUserGroupDao, UserGroupParameters>
    {
        public UserGroupChooserControl()
        {
            assemblyName = "Samsara.Main.Forms.dll";
            assemblyFormClassName = "Samsara.Main.Forms.Forms.UserGroupForm";
            InitializeComponent();
        }
    }
}
