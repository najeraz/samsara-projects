
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class RackTypeSearchForm : GenericSearchForm<RackType>
    {
        public RackTypeSearchForm()
        {
            InitializeComponent();
        }

        public override RackType GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
