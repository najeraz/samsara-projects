
using Samsara.Base.Controls.Controls;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Dao.Interfaces;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Configuration.Controls.Controls
{
    public partial class UserGroupChooserControl : SamsaraEntityChooserControl<UserGroup, int, IUserGroupService, IUserGroupDao, UserGroupParameters>
    {
        public UserGroupChooserControl()
        {
            assemblyName = "Samsara.Configuration.Forms.dll";
            assemblyFormClassName = "Samsara.Configuration.Forms.Forms.UserGroupForm";
            InitializeComponent();
        }
    }
}
