
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Choosers
{
    public partial class ComputerBrandChooserControl : SamsaraEntityChooserControl<ComputerBrand, int, IComputerBrandService, IComputerBrandDao, ComputerBrandParameters>
    {
        public ComputerBrandChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.ComputerBrandForm";
            InitializeComponent();
        }
    }
}
