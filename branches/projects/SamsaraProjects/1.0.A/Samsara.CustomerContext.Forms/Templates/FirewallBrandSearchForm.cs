
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class FirewallBrandSearchForm : GenericSearchForm<FirewallBrand>
    {
        public FirewallBrandSearchForm()
        {
            InitializeComponent();
        }

        public override FirewallBrand GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
