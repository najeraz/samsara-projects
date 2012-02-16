
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Dao.Interfaces;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Controls.Controls
{
    public partial class UserChooserControl : SamsaraEntityChooserControl<User, int, IUserService, IUserDao, UserParameters>
    {
        public UserChooserControl()
        {
            assemblyName = "Samsara.Main.Forms.dll";
            assemblyFormClassName = "Samsara.Main.Forms.Forms.UserForm";
            InitializeComponent();
        }
    }
}
