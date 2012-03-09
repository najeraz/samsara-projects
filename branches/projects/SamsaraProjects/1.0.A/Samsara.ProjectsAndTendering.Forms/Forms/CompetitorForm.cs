
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class CompetitorForm : CompetitorSearchForm
    {
        #region Attributes

        private CompetitorFormController ctrlCompetitorForm;
        private ICompetitorService srvCompetitor;

        #endregion Attributes

        public CompetitorForm()
        {
            InitializeComponent();
            this.ctrlCompetitorForm = new CompetitorFormController(this);
            this.srvCompetitor = SamsaraAppContext.Resolve<ICompetitorService>();
        }

        #region Methods

        public override Competitor GetSearchResult()
        {
            Competitor Competitor = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CompetitorId = Convert.ToInt32(activeRow.Cells[0].Value);
                Competitor = this.srvCompetitor.GetById(CompetitorId);
            }

            return Competitor;
        }

        #endregion Methods
    }
}
