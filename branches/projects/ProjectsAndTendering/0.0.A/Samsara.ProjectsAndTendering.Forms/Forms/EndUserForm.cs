
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class EndUserForm : EndUserSearchForm
    {
        #region Attributes

        private EndUserFormController ctrlEndUserForm;
        private IEndUserService srvEndUser;

        #endregion Attributes

        public EndUserForm()
        {
            InitializeComponent();
            this.ctrlEndUserForm = new EndUserFormController(this);
            this.srvEndUser = SamsaraAppContext.Resolve<IEndUserService>();
            Assert.IsNotNull(srvEndUser);
        }

        #region Methods

        internal override EndUser GetSerchResult()
        {
            EndUser bidder = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int asesorId = Convert.ToInt32(activeRow.Cells[0].Value);
                bidder = this.srvEndUser.LoadEndUser(asesorId);
            }

            return bidder;
        }

        #endregion Methods
    }
}
