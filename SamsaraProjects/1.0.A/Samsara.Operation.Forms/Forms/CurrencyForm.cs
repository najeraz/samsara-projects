
using Samsara.Operation.Forms.Templates;
using Samsara.Operation.Forms.Controller;
using Samsara.Operation.Service.Interfaces;
using Samsara.Base.Core.Context;
using NUnit.Framework;
using Samsara.Operation.Core.Entities;
using Infragistics.Win.UltraWinGrid;
using System;

namespace Samsara.Operation.Forms.Forms
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

        public override Currency GetSerchResult()
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
