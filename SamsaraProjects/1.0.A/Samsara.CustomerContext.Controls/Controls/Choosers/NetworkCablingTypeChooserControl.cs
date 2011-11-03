
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class NetworkCablingTypeChooserControl : SamsaraEntityChooserControl<NetworkCablingType, int, INetworkCablingTypeService, INetworkCablingTypeDao, NetworkCablingTypeParameters>
    {
        public NetworkCablingTypeChooserControl()
        {
            string controlsSchemaNamespace = Assembly.GetExecutingAssembly().FullName.Substring(0,
                Assembly.GetExecutingAssembly().FullName.IndexOf(","));

            string schemaNamespace = controlsSchemaNamespace
                .Substring(0, controlsSchemaNamespace.LastIndexOf("."));

            assemblyName = schemaNamespace + ".Forms.dll";
            assemblyFormClassName = schemaNamespace + ".Forms.Forms.NetworkCablingTypeForm";
            InitializeComponent();
        }
    }
}
