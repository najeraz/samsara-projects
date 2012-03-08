
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
    public partial class FormConfigurationUserPermissionForm : FormConfigurationUserPermissionSearchForm
    {
        #region Attributes

        private FormConfigurationUserPermissionFormController ctrlFormConfigurationUserPermissionForm;
        private IFormConfigurationUserPermissionService srvFormConfigurationUserPermission;

        #endregion Attributes

        public FormConfigurationUserPermissionForm()
        {
            InitializeComponent();
            this.ctrlFormConfigurationUserPermissionForm = new FormConfigurationUserPermissionFormController(this);
            this.srvFormConfigurationUserPermission = SamsaraAppContext.Resolve<IFormConfigurationUserPermissionService>();
            Assert.IsNotNull(this.srvFormConfigurationUserPermission);
        }

        #region Methods

        public override FormConfigurationUserPermission GetSearchResult()
        {
            FormConfigurationUserPermission FormConfigurationUserPermission = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int FormConfigurationUserPermissionId = Convert.ToInt32(activeRow.Cells[0].Value);
                FormConfigurationUserPermission = this.srvFormConfigurationUserPermission.GetById(FormConfigurationUserPermissionId);
            }

            return FormConfigurationUserPermission;
        }

        #endregion Methods
    }
}
