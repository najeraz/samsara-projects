
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls.Controls
{
    public partial class DependencyChooserControl : SamsaraEntityChooserControl<Dependency, int, IDependencyService, IDependencyDao, DependencyParameters>
    {
        public DependencyChooserControl()
        {
            string controlsSchemaNamespace = Assembly.GetExecutingAssembly().FullName.Substring(0,
                Assembly.GetExecutingAssembly().FullName.IndexOf(","));

            string schemaNamespace = controlsSchemaNamespace
                .Substring(0, controlsSchemaNamespace.LastIndexOf("."));

            AssemblyName = schemaNamespace + ".Forms.dll";
            AssemblyFormClassName = schemaNamespace + ".Forms.Forms.DependencyForm";
            InitializeComponent();
        }
    }
}
