
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class SecuritySoftwareTypeForm : SecuritySoftwareTypeSearchForm
    {
        #region Attributes

        private SecuritySoftwareTypeFormController ctrlSecuritySoftwareTypeForm;
        private ISecuritySoftwareTypeService srvSecuritySoftwareType;

        #endregion Attributes

        public SecuritySoftwareTypeForm()
        {
            InitializeComponent();
            this.ctrlSecuritySoftwareTypeForm = new SecuritySoftwareTypeFormController(this);
            this.srvSecuritySoftwareType = SamsaraAppContext.Resolve<ISecuritySoftwareTypeService>();
        }

        #region Methods

        public override SecuritySoftwareType GetSearchResult()
        {
            SecuritySoftwareType SecuritySoftwareType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int SecuritySoftwareTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                SecuritySoftwareType = this.srvSecuritySoftwareType.GetById(SecuritySoftwareTypeId);
            }

            return SecuritySoftwareType;
        }

        #endregion Methods
    }
}
