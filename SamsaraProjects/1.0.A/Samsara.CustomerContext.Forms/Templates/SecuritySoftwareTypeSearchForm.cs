
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class SecuritySoftwareTypeSearchForm : GenericSearchForm<SecuritySoftwareType>
    {
        public SecuritySoftwareTypeSearchForm()
        {
            InitializeComponent();
        }

        public override SecuritySoftwareType GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
