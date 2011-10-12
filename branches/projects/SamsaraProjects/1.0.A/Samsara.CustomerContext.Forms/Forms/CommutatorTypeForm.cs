
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
    public partial class CommutatorTypeForm : CommutatorTypeSearchForm
    {
        #region Attributes

        private CommutatorTypeFormController ctrlCommutatorTypeForm;
        private ICommutatorTypeService srvCommutatorType;

        #endregion Attributes

        public CommutatorTypeForm()
        {
            InitializeComponent();
            this.ctrlCommutatorTypeForm = new CommutatorTypeFormController(this);
            this.srvCommutatorType = SamsaraAppContext.Resolve<ICommutatorTypeService>();
            Assert.IsNotNull(this.srvCommutatorType);
        }

        #region Methods

        public override CommutatorType GetSearchResult()
        {
            CommutatorType CommutatorType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CommutatorTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                CommutatorType = this.srvCommutatorType.GetById(CommutatorTypeId);
            }

            return CommutatorType;
        }

        #endregion Methods
    }
}
