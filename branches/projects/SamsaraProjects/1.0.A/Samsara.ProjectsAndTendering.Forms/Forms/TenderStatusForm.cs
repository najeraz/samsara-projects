﻿
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces;

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
            Assert.IsNotNull(this.srvTenderStatus);
        }

        #region Methods

        public override TenderStatus GetSerchResult()
        {
            TenderStatus asesor = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int asesorId = Convert.ToInt32(activeRow.Cells[0].Value);
                asesor = this.srvTenderStatus.GetById(asesorId);
            }

            return asesor;
        }

        #endregion Methods
    }
}
