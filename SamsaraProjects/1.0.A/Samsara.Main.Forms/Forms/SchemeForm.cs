
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
    public partial class SchemeForm : SchemeSearchForm
    {
        #region Attributes

        private SchemeFormController ctrlSchemeForm;
        private ISchemeService srvScheme;

        #endregion Attributes

        public SchemeForm()
        {
            InitializeComponent();
            this.ctrlSchemeForm = new SchemeFormController(this);
            this.srvScheme = SamsaraAppContext.Resolve<ISchemeService>();
            Assert.IsNotNull(this.srvScheme);
        }

        #region Methods

        public override Scheme GetSearchResult()
        {
            Scheme Scheme = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int SchemeId = Convert.ToInt32(activeRow.Cells[0].Value);
                Scheme = this.srvScheme.GetById(SchemeId);
            }

            return Scheme;
        }

        #endregion Methods
    }
}
