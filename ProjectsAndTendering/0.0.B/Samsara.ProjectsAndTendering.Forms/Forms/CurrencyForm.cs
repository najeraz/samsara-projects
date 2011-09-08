
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
    public partial class CurrencyForm : CurrencySearchForm
    {
        #region Attributes

        private CurrencyFormController ctrlCurrencyForm;
        private ICurrencyService srvCurrency;

        #endregion Attributes

        public CurrencyForm()
        {
            InitializeComponent();
            this.ctrlCurrencyForm = new CurrencyFormController(this);
            this.srvCurrency = SamsaraAppContext.Resolve<ICurrencyService>();
            Assert.IsNotNull(this.srvCurrency);
        }

        #region Methods

        internal override Currency GetSerchResult()
        {
            Currency Currency = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CurrencyId = Convert.ToInt32(activeRow.Cells[0].Value);
                Currency = this.srvCurrency.GetById(CurrencyId);
            }

            return Currency;
        }

        #endregion Methods
    }
}
