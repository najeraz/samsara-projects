
using Samsara.Base.Forms.Forms;
using Samsara.Configuration.Core.Entities;

namespace Samsara.Configuration.Forms.Templates
{
    public partial class UserGroupSearchForm : GenericCatalogSearchForm<UserGroup>
    {
        public UserGroupSearchForm()
        {
            InitializeComponent();
        }

        public override UserGroup GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
