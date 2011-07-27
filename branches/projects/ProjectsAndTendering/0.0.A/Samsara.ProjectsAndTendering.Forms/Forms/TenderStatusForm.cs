
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Common;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Infragistics.Win.UltraWinGrid;
using System;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class TenderStatusForm : TenderStatusSearchForm
    {
        #region Attributes

        private TenderStatusFormController ctrlTenderStatusForm;
        private ITenderStatusService srvTenderStatus;

        #endregion Attributes

        public TenderStatusForm()
        {
            InitializeComponent();
            this.ctrlTenderStatusForm = new TenderStatusFormController(this);
            this.srvTenderStatus = SamsaraAppContext.Resolve<ITenderStatusService>();
            Assert.IsNotNull(srvTenderStatus);
        }

        #region Methods

        internal override TenderStatus GetSerchResult()
        {
            TenderStatus asesor = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int asesorId = Convert.ToInt32(activeRow.Cells[0].Value);
                asesor = this.srvTenderStatus.LoadTenderStatus(asesorId);
            }

            return asesor;
        }

        #endregion Methods
    }
}
