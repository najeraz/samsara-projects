
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class AccessPointTypeChooserControl : SamsaraEntityChooserControl<AccessPointType, int, IAccessPointTypeService, IAccessPointTypeDao, AccessPointTypeParameters>
    {
        public AccessPointTypeChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.AccessPointTypeForm";
            InitializeComponent();
        }
    }
}
