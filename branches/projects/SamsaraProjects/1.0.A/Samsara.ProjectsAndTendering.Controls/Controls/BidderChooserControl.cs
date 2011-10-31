
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls.Controls
{
    public partial class BidderChooserControl : SamsaraEntityChooserControl<Bidder, int, IBidderService, IBidderDao, BidderParameters>
    {
        public BidderChooserControl()
        {
            string schemaNamespace = Assembly.GetExecutingAssembly().FullName.Substring(
                Assembly.GetExecutingAssembly().FullName.IndexOf(".", 1));

            AssemblyName = schemaNamespace + ".Forms.dll";
            AssemblyFormClassName = schemaNamespace + ".Forms.Forms.BidderForm";
            InitializeComponent();
        }
    }
}
