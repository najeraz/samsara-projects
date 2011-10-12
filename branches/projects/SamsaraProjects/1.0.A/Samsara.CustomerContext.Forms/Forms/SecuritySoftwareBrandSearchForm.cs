
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class SecuritySoftwareBrandSearchForm : GenericSearchForm<SecuritySoftwareBrand>
    {
        public SecuritySoftwareBrandSearchForm()
        {
            InitializeComponent();
        }

        public override SecuritySoftwareBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
