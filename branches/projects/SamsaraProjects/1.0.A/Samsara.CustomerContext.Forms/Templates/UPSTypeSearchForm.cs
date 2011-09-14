
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class UPSTypeSearchForm : GenericSearchForm<UPSType>
    {
        public UPSTypeSearchForm()
        {
            InitializeComponent();
        }

        public override UPSType GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
