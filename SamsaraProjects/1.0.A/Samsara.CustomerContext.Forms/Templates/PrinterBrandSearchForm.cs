
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class PrinterBrandSearchForm : GenericSearchForm<PrinterBrand>
    {
        public PrinterBrandSearchForm()
        {
            InitializeComponent();
        }

        public override PrinterBrand GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
