
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
    public partial class UserPermissionForm : UserPermissionSearchForm
    {
        #region Attributes

        private UserPermissionFormController ctrlUserPermissionForm;
        private IUserPermissionService srvUserPermission;

        #endregion Attributes

        public UserPermissionForm()
        {
            InitializeComponent();
            this.ctrlUserPermissionForm = new UserPermissionFormController(this);
            this.srvUserPermission = SamsaraAppContext.Resolve<IUserPermissionService>();
            Assert.IsNotNull(this.srvUserPermission);
        }

        #region Methods

        public override UserPermission GetSearchResult()
        {
            UserPermission UserPermission = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int UserPermissionId = Convert.ToInt32(activeRow.Cells[0].Value);
                UserPermission = this.srvUserPermission.GetById(UserPermissionId);
            }

            return UserPermission;
        }

        #endregion Methods
    }
}
