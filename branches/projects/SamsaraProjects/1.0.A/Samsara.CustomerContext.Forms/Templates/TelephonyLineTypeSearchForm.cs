
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class TelephonyLineTypeSearchForm : GenericSearchForm<TelephonyLineType>
    {
        public TelephonyLineTypeSearchForm()
        {
            InitializeComponent();
        }

        public override TelephonyLineType GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
