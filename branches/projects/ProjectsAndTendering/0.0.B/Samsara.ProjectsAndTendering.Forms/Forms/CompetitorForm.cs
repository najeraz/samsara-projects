
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
            Assert.IsNotNull(this.srvCompetitor);
        }

        #region Methods

        internal override Competitor GetSerchResult()
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
