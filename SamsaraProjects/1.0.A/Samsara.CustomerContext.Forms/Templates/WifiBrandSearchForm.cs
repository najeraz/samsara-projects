
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class WifiBrandSearchForm : GenericSearchForm<WifiBrand>
    {
        public WifiBrandSearchForm()
        {
            InitializeComponent();
        }

        public override WifiBrand GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
