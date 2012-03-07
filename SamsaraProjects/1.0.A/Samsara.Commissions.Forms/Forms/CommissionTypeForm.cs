
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Forms.Controller;
using Samsara.Commissions.Forms.Templates;
using Samsara.Commissions.Service.Interfaces;

namespace Samsara.Commissions.Forms.Forms
{
    public partial class CommissionTypeForm : CommissionTypeSearchForm
    {
        #region Attributes

        private CommissionTypeFormController ctrlCommissionTypeForm;
        private ICommissionTypeService srvCommissionType;

        #endregion Attributes

        public CommissionTypeForm()
        {
            InitializeComponent();
            this.ctrlCommissionTypeForm = new CommissionTypeFormController(this);
            this.srvCommissionType = SamsaraAppContext.Resolve<ICommissionTypeService>();
            Assert.IsNotNull(this.srvCommissionType);
        }

        #region Methods

        public override CommissionType GetSearchResult()
        {
            CommissionType CommissionType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CommissionTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                CommissionType = this.srvCommissionType.GetById(CommissionTypeId);
            }

            return CommissionType;
        }

        #endregion Methods
    }
}
