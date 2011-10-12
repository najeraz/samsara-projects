
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
    public partial class CCTVTypeForm : CCTVTypeSearchForm
    {
        #region Attributes

        private CCTVTypeFormController ctrlCCTVTypeForm;
        private ICCTVTypeService srvCCTVType;

        #endregion Attributes

        public CCTVTypeForm()
        {
            InitializeComponent();
            this.ctrlCCTVTypeForm = new CCTVTypeFormController(this);
            this.srvCCTVType = SamsaraAppContext.Resolve<ICCTVTypeService>();
            Assert.IsNotNull(this.srvCCTVType);
        }

        #region Methods

        public override CCTVType GetSearchResult()
        {
            CCTVType CCTVType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CCTVTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                CCTVType = this.srvCCTVType.GetById(CCTVTypeId);
            }

            return CCTVType;
        }

        #endregion Methods
    }
}
