
using Samsara.Base.Forms.Forms;
using Samsara.Main.Core.Entities;

namespace Samsara.Main.Forms.Templates
{
    public partial class UserSearchForm : GenericSearchForm<User>
    {
        public UserSearchForm()
        {
            InitializeComponent();
        }

        public override User GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
