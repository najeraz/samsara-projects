
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class CCTVBrandForm : CCTVBrandSearchForm
    {
        #region Attributes

        private CCTVBrandFormController ctrlCCTVBrandForm;
        private ICCTVBrandService srvCCTVBrand;

        #endregion Attributes

        public CCTVBrandForm()
        {
            InitializeComponent();
            this.ctrlCCTVBrandForm = new CCTVBrandFormController(this);
            this.srvCCTVBrand = SamsaraAppContext.Resolve<ICCTVBrandService>();
        }

        #region Methods

        public override CCTVBrand GetSearchResult()
        {
            CCTVBrand CCTVBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CCTVBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                CCTVBrand = this.srvCCTVBrand.GetById(CCTVBrandId);
            }

            return CCTVBrand;
        }

        #endregion Methods
    }
}
