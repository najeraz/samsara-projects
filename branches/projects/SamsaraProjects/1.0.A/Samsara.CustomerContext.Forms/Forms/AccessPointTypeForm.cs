
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
    public partial class AccessPointTypeForm : AccessPointTypeSearchForm
    {
        #region Attributes

        private AccessPointTypeFormController ctrlAccessPointTypeForm;
        private IAccessPointTypeService srvAccessPointType;

        #endregion Attributes

        public AccessPointTypeForm()
        {
            InitializeComponent();
            this.ctrlAccessPointTypeForm = new AccessPointTypeFormController(this);
            this.srvAccessPointType = SamsaraAppContext.Resolve<IAccessPointTypeService>();
            Assert.IsNotNull(this.srvAccessPointType);
        }

        #region Methods

        public override AccessPointType GetSerchResult()
        {
            AccessPointType AccessPointType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int AccessPointTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                AccessPointType = this.srvAccessPointType.GetById(AccessPointTypeId);
            }

            return AccessPointType;
        }

        #endregion Methods
    }
}
