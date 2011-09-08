
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.Common.Context;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Core.Entities;
using Infragistics.Win.UltraWinGrid;
using System;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class OrganizationForm : OrganizationSearchForm
    {
        #region Attributes

        private OrganizationFormController ctrlOrganizationForm;
        private IOrganizationService srvOrganization;

        #endregion Attributes

        public OrganizationForm()
        {
            InitializeComponent();
            this.ctrlOrganizationForm = new OrganizationFormController(this);
            this.srvOrganization = SamsaraAppContext.Resolve<IOrganizationService>();
            Assert.IsNotNull(this.srvOrganization);
        }

        #region Methods

        public override Organization GetSerchResult()
        {
            Organization Organization = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int OrganizationId = Convert.ToInt32(activeRow.Cells[0].Value);
                Organization = this.srvOrganization.GetById(OrganizationId);
            }

            return Organization;
        }

        #endregion Methods
    }
}
