
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class AccessPointBrandSearchForm : GenericSearchForm<AccessPointBrand>
    {
        public AccessPointBrandSearchForm()
        {
            InitializeComponent();
        }

        public override AccessPointBrand GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
