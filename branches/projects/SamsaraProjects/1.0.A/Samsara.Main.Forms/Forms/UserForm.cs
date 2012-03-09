
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Forms.Controller;
using Samsara.Main.Forms.Templates;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Forms.Forms
{
    public partial class UserForm : UserSearchForm
    {
        #region Attributes

        private UserFormController ctrlUserForm;
        private IUserService srvUser;

        #endregion Attributes

        public UserForm()
        {
            InitializeComponent();
            this.ctrlUserForm = new UserFormController(this);
            this.srvUser = SamsaraAppContext.Resolve<IUserService>();
        }

        #region Methods

        public override User GetSearchResult()
        {
            User User = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int UserId = Convert.ToInt32(activeRow.Cells[0].Value);
                User = this.srvUser.GetById(UserId);
            }

            return User;
        }

        #endregion Methods
    }
}
