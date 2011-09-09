
using Samsara.Base.Forms.Forms;
using Samsara.Operation.Core.Entities;

namespace Samsara.Operation.Forms.Templates
{
    public partial class CurrencySearchForm : GenericSearchForm<Currency>
    {
        public CurrencySearchForm()
        {
            InitializeComponent();
        }

        public override Currency GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
