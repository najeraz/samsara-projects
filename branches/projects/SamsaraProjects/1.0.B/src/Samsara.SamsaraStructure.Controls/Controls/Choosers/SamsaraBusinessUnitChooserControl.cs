
using Samsara.Base.Controls.Controls;
using Samsara.SamsaraStructure.Core.Entities;
using Samsara.SamsaraStructure.Core.Parameters;
using Samsara.SamsaraStructure.Dao.Interfaces;
using Samsara.SamsaraStructure.Service.Interfaces;

namespace Samsara.SamsaraStructure.Controls.Controls
{
    public partial class SamsaraBusinessUnitChooserControl : SamsaraEntityChooserControl<SamsaraBusinessUnit, int, ISamsaraBusinessUnitService, ISamsaraBusinessUnitDao, SamsaraBusinessUnitParameters>
    {
        public SamsaraBusinessUnitChooserControl()
        {
            assemblyName = "Samsara.SamsaraStructure.Forms.dll";
            assemblyFormClassName = "Samsara.SamsaraStructure.Forms.Forms.SamsaraBusinessUnitForm";
            InitializeComponent();
        }
    }
}
