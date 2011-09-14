
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
    public partial class WifiBrandForm : WifiBrandSearchForm
    {
        #region Attributes

        private WifiBrandFormController ctrlWifiBrandForm;
        private IWifiBrandService srvWifiBrand;

        #endregion Attributes

        public WifiBrandForm()
        {
            InitializeComponent();
            this.ctrlWifiBrandForm = new WifiBrandFormController(this);
            this.srvWifiBrand = SamsaraAppContext.Resolve<IWifiBrandService>();
            Assert.IsNotNull(this.srvWifiBrand);
        }

        #region Methods

        public override WifiBrand GetSerchResult()
        {
            WifiBrand WifiBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int WifiBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                WifiBrand = this.srvWifiBrand.GetById(WifiBrandId);
            }

            return WifiBrand;
        }

        #endregion Methods
    }
}
