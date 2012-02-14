
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
    public partial class UserPermissionsForm : UserPermissionsSearchForm
    {
        #region Attributes

        private UserPermissionsFormController ctrlUserPermissionsForm;
        private IUserPermissionsService srvUserPermissions;

        #endregion Attributes

        public UserPermissionsForm()
        {
            InitializeComponent();
            this.ctrlUserPermissionsForm = new UserPermissionsFormController(this);
            this.srvUserPermissions = SamsaraAppContext.Resolve<IUserPermissionsService>();
            Assert.IsNotNull(this.srvUserPermissions);
        }

        #region Methods

        public override UserPermissions GetSearchResult()
        {
            UserPermissions UserPermissions = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int UserPermissionsId = Convert.ToInt32(activeRow.Cells[0].Value);
                UserPermissions = this.srvUserPermissions.GetById(UserPermissionsId);
            }

            return UserPermissions;
        }

        #endregion Methods
    }
}
