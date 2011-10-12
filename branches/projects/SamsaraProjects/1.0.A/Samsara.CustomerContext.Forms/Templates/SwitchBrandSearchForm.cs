
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class SwitchBrandSearchForm : GenericSearchForm<SwitchBrand>
    {
        public SwitchBrandSearchForm()
        {
            InitializeComponent();
        }

        public override SwitchBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
