
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
    public partial class UPSTypeForm : UPSTypeSearchForm
    {
        #region Attributes

        private UPSTypeFormController ctrlUPSTypeForm;
        private IUPSTypeService srvUPSType;

        #endregion Attributes

        public UPSTypeForm()
        {
            InitializeComponent();
            this.ctrlUPSTypeForm = new UPSTypeFormController(this);
            this.srvUPSType = SamsaraAppContext.Resolve<IUPSTypeService>();
            Assert.IsNotNull(this.srvUPSType);
        }

        #region Methods

        public override UPSType GetSearchResult()
        {
            UPSType UPSType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int UPSTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                UPSType = this.srvUPSType.GetById(UPSTypeId);
            }

            return UPSType;
        }

        #endregion Methods
    }
}
