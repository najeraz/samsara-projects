﻿
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class RackTypeForm : RackTypeSearchForm
    {
        #region Attributes

        private RackTypeFormController ctrlRackTypeForm;
        private IRackTypeService srvRackType;

        #endregion Attributes

        public RackTypeForm()
        {
            InitializeComponent();
            this.ctrlRackTypeForm = new RackTypeFormController(this);
            this.srvRackType = SamsaraAppContext.Resolve<IRackTypeService>();
        }

        #region Methods

        public override RackType GetSearchResult()
        {
            RackType RackType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int RackTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                RackType = this.srvRackType.GetById(RackTypeId);
            }

            return RackType;
        }

        #endregion Methods
    }
}
