
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Dao.Interfaces;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Controls.Controls
{
    public partial class UserPermissionsChooserControl : SamsaraEntityChooserControl<UserPermissions, int, IUserPermissionsService, IUserPermissionsDao, UserPermissionsParameters>
    {
        public UserPermissionsChooserControl()
        {
            string controlsSchemaNamespace = Assembly.GetExecutingAssembly().FullName.Substring(0,
                Assembly.GetExecutingAssembly().FullName.IndexOf(","));

            string schemaNamespace = controlsSchemaNamespace
                .Substring(0, controlsSchemaNamespace.LastIndexOf("."));

            assemblyName = schemaNamespace + ".Forms.dll";
            assemblyFormClassName = schemaNamespace + ".Forms.Forms.UserPermissionsForm";
            InitializeComponent();
        }
    }
}
