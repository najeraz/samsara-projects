
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Forms.Controller;
using Samsara.Main.Forms.Templates;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Forms.Forms
{
    public partial class SamsaraFormForm : SamsaraFormSearchForm
    {
        #region Attributes

        private SamsaraFormFormController ctrlSamsaraFormForm;
        private ISamsaraFormService srvSamsaraForm;

        #endregion Attributes

        public SamsaraFormForm()
        {
            InitializeComponent();
            this.ctrlSamsaraFormForm = new SamsaraFormFormController(this);
            this.srvSamsaraForm = SamsaraAppContext.Resolve<ISamsaraFormService>();
            Assert.IsNotNull(this.srvSamsaraForm);
        }

        #region Methods

        public override SamsaraForm GetSearchResult()
        {
            SamsaraForm SamsaraForm = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int SamsaraFormId = Convert.ToInt32(activeRow.Cells[0].Value);
                SamsaraForm = this.srvSamsaraForm.GetById(SamsaraFormId);
            }

            return SamsaraForm;
        }

        #endregion Methods
    }
}
