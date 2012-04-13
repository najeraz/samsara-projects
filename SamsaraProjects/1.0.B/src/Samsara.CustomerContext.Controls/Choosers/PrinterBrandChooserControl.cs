
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Choosers
{
    public partial class PrinterBrandChooserControl : SamsaraEntityChooserControl<PrinterBrand, int, IPrinterBrandService, IPrinterBrandDao, PrinterBrandParameters>
    {
        public PrinterBrandChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.PrinterBrandForm";
            InitializeComponent();
        }
    }
}
