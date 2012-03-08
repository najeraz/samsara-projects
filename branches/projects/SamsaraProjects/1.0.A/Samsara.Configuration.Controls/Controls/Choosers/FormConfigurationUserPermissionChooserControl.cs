
using Samsara.Base.Controls.Controls;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Dao.Interfaces;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Configuration.Controls.Controls
{
    public partial class FormConfigurationUserPermissionChooserControl : SamsaraEntityChooserControl<FormConfigurationUserPermission, int, IFormConfigurationUserPermissionService, IFormConfigurationUserPermissionDao, FormConfigurationUserPermissionParameters>
    {
        public FormConfigurationUserPermissionChooserControl()
        {
            assemblyName = "Samsara.Configuration.Forms.dll";
            assemblyFormClassName = "Samsara.Configuration.Forms.Forms.FormConfigurationUserPermissionForm";
            InitializeComponent();
        }
    }
}
