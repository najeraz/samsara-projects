
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Enums;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class OpportunityForm : OpportunitySearchForm
    {
        #region Attributes

        private OpportunityFormController ctrlOpportunityForm;
        private IOpportunityTypeService srvOpportunityType;
        private IOpportunityService srvOpportunity;

        #endregion Attributes

        #region Constructor

        public OpportunityForm()
        {
            InitializeComponent();
            this.ctrlOpportunityForm = new OpportunityFormController(this);
            this.srvOpportunity = SamsaraAppContext.Resolve<IOpportunityService>();
            this.srvOpportunityType = SamsaraAppContext.Resolve<IOpportunityTypeService>();
        }

        #endregion Constructor

        #region Methods

        public override void PrepareSearchControls()
        {
            base.PrepareSearchControls();

            if (((GenericCatalogSearchForm<Opportunity>)this).ParentSearchForm != null)
            {
                this.otcSchOpportunityType.ReadOnly = true;
                this.otcSchOpportunityType.Value = this.srvOpportunityType.GetById((int)OpportunityTypeEnum.PublicSector);
            }
        }

        public override Opportunity GetSearchResult()
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
