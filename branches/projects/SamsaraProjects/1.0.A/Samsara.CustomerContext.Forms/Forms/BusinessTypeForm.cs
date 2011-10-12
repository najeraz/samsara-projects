
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
    public partial class BusinessTypeForm : BusinessTypeSearchForm
    {
        #region Attributes

        private BusinessTypeFormController ctrlBusinessTypeForm;
        private IBusinessTypeService srvBusinessType;

        #endregion Attributes

        public BusinessTypeForm()
        {
            InitializeComponent();
            this.ctrlBusinessTypeForm = new BusinessTypeFormController(this);
            this.srvBusinessType = SamsaraAppContext.Resolve<IBusinessTypeService>();
            Assert.IsNotNull(this.srvBusinessType);
        }

        #region Methods

        public override BusinessType GetSearchResult()
        {
            BusinessType BusinessType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int BusinessTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                BusinessType = this.srvBusinessType.GetById(BusinessTypeId);
            }

            return BusinessType;
        }

        #endregion Methods
    }
}
