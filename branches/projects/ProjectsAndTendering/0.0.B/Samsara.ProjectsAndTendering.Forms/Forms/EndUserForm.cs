﻿
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Common.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces;

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
            Assert.IsNotNull(this.srvEndUser);
        }

        #region Methods

        internal override EndUser GetSerchResult()
        {
            EndUser bidder = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int asesorId = Convert.ToInt32(activeRow.Cells[0].Value);
                bidder = this.srvEndUser.GetById(asesorId);
            }

            return bidder;
        }

        #endregion Methods
    }
}
