
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
    public partial class ISPForm : ISPSearchForm
    {
        #region Attributes

        private ISPFormController ctrlISPForm;
        private IISPService srvISP;

        #endregion Attributes

        public ISPForm()
        {
            InitializeComponent();
            this.ctrlISPForm = new ISPFormController(this);
            this.srvISP = SamsaraAppContext.Resolve<IISPService>();
            Assert.IsNotNull(this.srvISP);
        }

        #region Methods

        public override ISP GetSearchResult()
        {
            ISP ISP = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int ISPId = Convert.ToInt32(activeRow.Cells[0].Value);
                ISP = this.srvISP.GetById(ISPId);
            }

            return ISP;
        }

        #endregion Methods
    }
}
