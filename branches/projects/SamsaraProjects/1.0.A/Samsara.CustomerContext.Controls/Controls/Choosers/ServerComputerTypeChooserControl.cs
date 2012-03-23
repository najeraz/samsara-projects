
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class ServerComputerTypeChooserControl : SamsaraEntityChooserControl<ServerComputerType, int, IServerComputerTypeService, IServerComputerTypeDao, ServerComputerTypeParameters>
    {
        public ServerComputerTypeChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.ServerComputerTypeForm";
            InitializeComponent();
        }
    }
}
