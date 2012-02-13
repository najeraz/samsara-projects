
using Samsara.Base.Forms.Forms;
using Samsara.Main.Core.Entities;

namespace Samsara.Main.Forms.Templates
{
    public partial class UserGroupSearchForm : GenericSearchForm<UserGroup>
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
