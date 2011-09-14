
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class RouterBrandSearchForm : GenericSearchForm<RouterBrand>
    {
        public RouterBrandSearchForm()
        {
            InitializeComponent();
        }

        public override RouterBrand GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
