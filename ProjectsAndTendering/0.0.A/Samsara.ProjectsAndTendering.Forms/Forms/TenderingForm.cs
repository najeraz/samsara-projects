
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
    public partial class TenderingForm : TenderSearchForm
    {
        #region Attributes

        private TenderingFormController ctrlTenderingForm;
        private ITenderService srvTender;

        #endregion Attributes

        #region Constructor

        public TenderingForm()
        {
            InitializeComponent();
            this.ctrlTenderingForm = new TenderingFormController(this);
            this.srvTender = SamsaraAppContext.Resolve<ITenderService>();
            Assert.IsNotNull(srvTender);
        }

        #endregion Constructor

        #region Methods

        internal override Tender GetSerchResult()
        {
            Tender tender = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int tenderId = Convert.ToInt32(activeRow.Cells[0].Value);
                tender = this.srvTender.LoadTender(tenderId);
            }

            return tender;
        }

        #endregion Methods
    }
}
