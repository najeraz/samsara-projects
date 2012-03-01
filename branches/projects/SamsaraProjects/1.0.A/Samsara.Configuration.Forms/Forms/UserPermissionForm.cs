
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Forms.Controller;
using Samsara.Configuration.Forms.Templates;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Configuration.Forms.Forms
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
