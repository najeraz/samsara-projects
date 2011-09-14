
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
    public partial class NetworkCablingTypeForm : NetworkCablingTypeSearchForm
    {
        #region Attributes

        private NetworkCablingTypeFormController ctrlNetworkCablingTypeForm;
        private INetworkCablingTypeService srvNetworkCablingType;

        #endregion Attributes

        public NetworkCablingTypeForm()
        {
            InitializeComponent();
            this.ctrlNetworkCablingTypeForm = new NetworkCablingTypeFormController(this);
            this.srvNetworkCablingType = SamsaraAppContext.Resolve<INetworkCablingTypeService>();
            Assert.IsNotNull(this.srvNetworkCablingType);
        }

        #region Methods

        public override NetworkCablingType GetSerchResult()
        {
            NetworkCablingType NetworkCablingType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int NetworkCablingTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                NetworkCablingType = this.srvNetworkCablingType.GetById(NetworkCablingTypeId);
            }

            return NetworkCablingType;
        }

        #endregion Methods
    }
}
