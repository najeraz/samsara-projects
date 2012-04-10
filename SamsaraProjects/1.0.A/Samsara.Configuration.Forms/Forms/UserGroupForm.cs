
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Forms.Controller;
using Samsara.Configuration.Forms.Templates;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Configuration.Forms.Forms
{
    public partial class UserGroupForm : UserGroupSearchForm
    {
        #region Attributes

        private UserGroupFormController ctrlUserGroupForm;
        private IUserGroupService srvUserGroup;

        #endregion Attributes

        public UserGroupForm()
        {
            InitializeComponent();
            this.ctrlUserGroupForm = new UserGroupFormController(this);
            this.srvUserGroup = SamsaraAppContext.Resolve<IUserGroupService>();
        }

        #region Methods

        public override UserGroup GetSearchResult()
        {
            UserGroup UserGroup = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int UserGroupId = Convert.ToInt32(activeRow.Cells[0].Value);
                UserGroup = this.srvUserGroup.GetById(UserGroupId);
            }

            return UserGroup;
        }

        #endregion Methods
    }
}
