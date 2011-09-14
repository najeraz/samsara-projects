﻿
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class OperativeSystemForm : OperativeSystemSearchForm
    {
        #region Attributes

        private OperativeSystemFormController ctrlOperativeSystemForm;
        private IOperativeSystemService srvOperativeSystem;

        #endregion Attributes

        public OperativeSystemForm()
        {
            InitializeComponent();
            this.ctrlOperativeSystemForm = new OperativeSystemFormController(this);
            this.srvOperativeSystem = SamsaraAppContext.Resolve<IOperativeSystemService>();
            Assert.IsNotNull(this.srvOperativeSystem);
        }

        #region Methods

        public override OperativeSystem GetSerchResult()
        {
            OperativeSystem OperativeSystem = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int OperativeSystemId = Convert.ToInt32(activeRow.Cells[0].Value);
                OperativeSystem = this.srvOperativeSystem.GetById(OperativeSystemId);
            }

            return OperativeSystem;
        }

        #endregion Methods
    }
}
