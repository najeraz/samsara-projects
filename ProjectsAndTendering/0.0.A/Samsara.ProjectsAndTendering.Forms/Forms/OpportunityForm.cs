
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Enums;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class OpportunityForm : OpportunitySearchForm
    {
        #region Attributes

        private OpportunityFormController ctrlOpportunityForm;
        private IOpportunityService srvOpportunity;

        #endregion Attributes

        #region Constructor

        public OpportunityForm()
        {
            InitializeComponent();
            this.ctrlOpportunityForm = new OpportunityFormController(this);
            this.srvOpportunity = SamsaraAppContext.Resolve<IOpportunityService>();
            Assert.IsNotNull(this.srvOpportunity);
        }

        #endregion Constructor

        #region Methods

        public override void PrepareSearchControls()
        {
            base.PrepareSearchControls();

            if (((GenericSearchForm<Opportunity>)this).ParentSearchForm != null)
            {
                this.uceSchOpportunityType.ReadOnly = true;
                this.uceSchOpportunityType.Value = (int)OpportunityTypeEnum.PublicSector;
            }
        }

        internal override Opportunity GetSerchResult()
        {
            Opportunity Opportunity = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int OpportunityId = Convert.ToInt32(activeRow.Cells[0].Value);
                Opportunity = this.srvOpportunity.GetById(OpportunityId);
            }

            return Opportunity;
        }

        #endregion Methods
    }
}
