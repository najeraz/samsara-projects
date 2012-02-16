
using System.Reflection;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Controls.Controls;

namespace Samsara.AlleatoERP.Controls.Controls
{
    public partial class StaffChooserControl : SamsaraEntityChooserControl<Staff, int, IStaffService, IStaffDao, StaffParameters>
    {
        public StaffChooserControl()
        {
            string controlsSchemaNamespace = Assembly.GetExecutingAssembly().FullName.Substring(0,
                Assembly.GetExecutingAssembly().FullName.IndexOf(","));

            string schemaNamespace = controlsSchemaNamespace
                .Substring(0, controlsSchemaNamespace.LastIndexOf("."));

            assemblyName = schemaNamespace + ".Forms.dll";
            assemblyFormClassName = schemaNamespace + ".Forms.Forms.StaffForm";
            InitializeComponent();
        }
    }
}
