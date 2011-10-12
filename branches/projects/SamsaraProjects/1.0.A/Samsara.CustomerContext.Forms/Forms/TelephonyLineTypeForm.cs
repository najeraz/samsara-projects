
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
    public partial class TelephonyLineTypeForm : TelephonyLineTypeSearchForm
    {
        #region Attributes

        private TelephonyLineTypeFormController ctrlTelephonyLineTypeForm;
        private ITelephonyLineTypeService srvTelephonyLineType;

        #endregion Attributes

        public TelephonyLineTypeForm()
        {
            InitializeComponent();
            this.ctrlTelephonyLineTypeForm = new TelephonyLineTypeFormController(this);
            this.srvTelephonyLineType = SamsaraAppContext.Resolve<ITelephonyLineTypeService>();
            Assert.IsNotNull(this.srvTelephonyLineType);
        }

        #region Methods

        public override TelephonyLineType GetSearchResult()
        {
            TelephonyLineType TelephonyLineType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int TelephonyLineTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                TelephonyLineType = this.srvTelephonyLineType.GetById(TelephonyLineTypeId);
            }

            return TelephonyLineType;
        }

        #endregion Methods
    }
}
