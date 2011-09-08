
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
    public partial class OpportunityStatusForm : OpportunityStatusSearchForm
    {
        #region Attributes

        private OpportunityStatusFormController ctrlOpportunityStatusForm;
        private IOpportunityStatusService srvOpportunityStatus;

        #endregion Attributes

        public OpportunityStatusForm()
        {
            InitializeComponent();
            this.ctrlOpportunityStatusForm = new OpportunityStatusFormController(this);
            this.srvOpportunityStatus = SamsaraAppContext.Resolve<IOpportunityStatusService>();
            Assert.IsNotNull(this.srvOpportunityStatus);
        }

        #region Methods

        internal override OpportunityStatus GetSerchResult()
        {
            OpportunityStatus asesor = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int asesorId = Convert.ToInt32(activeRow.Cells[0].Value);
                asesor = this.srvOpportunityStatus.GetById(asesorId);
            }

            return asesor;
        }

        #endregion Methods
    }
}
