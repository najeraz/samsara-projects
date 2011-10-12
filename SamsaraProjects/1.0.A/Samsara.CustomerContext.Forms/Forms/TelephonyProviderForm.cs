
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
    public partial class TelephonyProviderForm : TelephonyProviderSearchForm
    {
        #region Attributes

        private TelephonyProviderFormController ctrlTelephonyProviderForm;
        private ITelephonyProviderService srvTelephonyProvider;

        #endregion Attributes

        public TelephonyProviderForm()
        {
            InitializeComponent();
            this.ctrlTelephonyProviderForm = new TelephonyProviderFormController(this);
            this.srvTelephonyProvider = SamsaraAppContext.Resolve<ITelephonyProviderService>();
            Assert.IsNotNull(this.srvTelephonyProvider);
        }

        #region Methods

        public override TelephonyProvider GetSearchResult()
        {
            TelephonyProvider TelephonyProvider = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int TelephonyProviderId = Convert.ToInt32(activeRow.Cells[0].Value);
                TelephonyProvider = this.srvTelephonyProvider.GetById(TelephonyProviderId);
            }

            return TelephonyProvider;
        }

        #endregion Methods
    }
}
