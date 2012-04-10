
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class SecuritySoftwareBrandForm : SecuritySoftwareBrandSearchForm
    {
        #region Attributes

        private SecuritySoftwareBrandFormController ctrlSecuritySoftwareBrandForm;
        private ISecuritySoftwareBrandService srvSecuritySoftwareBrand;

        #endregion Attributes

        public SecuritySoftwareBrandForm()
        {
            InitializeComponent();
            this.ctrlSecuritySoftwareBrandForm = new SecuritySoftwareBrandFormController(this);
            this.srvSecuritySoftwareBrand = SamsaraAppContext.Resolve<ISecuritySoftwareBrandService>();
        }

        #region Methods

        public override SecuritySoftwareBrand GetSearchResult()
        {
            SecuritySoftwareBrand SecuritySoftwareBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int SecuritySoftwareBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                SecuritySoftwareBrand = this.srvSecuritySoftwareBrand.GetById(SecuritySoftwareBrandId);
            }

            return SecuritySoftwareBrand;
        }

        #endregion Methods
    }
}
