﻿
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Forms.Controller;
using Samsara.Main.Forms.Templates;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Forms.Forms
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
            Assert.IsNotNull(this.srvUserGroup);
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
