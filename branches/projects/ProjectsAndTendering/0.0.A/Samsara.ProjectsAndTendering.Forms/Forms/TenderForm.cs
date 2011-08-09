
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
    public partial class TenderForm : TenderSearchForm
    {
        #region Attributes

        private TenderFormController ctrlTenderForm;
        private ITenderService srvTender;

        #endregion Attributes

        #region Constructor

        public TenderForm()
        {
            InitializeComponent();
            this.ctrlTenderForm = new TenderFormController(this);
            this.srvTender = SamsaraAppContext.Resolve<ITenderService>();
            Assert.IsNotNull(this.srvTender);
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
                tender = this.srvTender.GetById(tenderId);
            }

            return tender;
        }

        #endregion Methods
    }
}
