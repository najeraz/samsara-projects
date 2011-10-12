
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
    public partial class ComputerBrandForm : ComputerBrandSearchForm
    {
        #region Attributes

        private ComputerBrandFormController ctrlComputerBrandForm;
        private IComputerBrandService srvComputerBrand;

        #endregion Attributes

        public ComputerBrandForm()
        {
            InitializeComponent();
            this.ctrlComputerBrandForm = new ComputerBrandFormController(this);
            this.srvComputerBrand = SamsaraAppContext.Resolve<IComputerBrandService>();
            Assert.IsNotNull(this.srvComputerBrand);
        }

        #region Methods

        public override ComputerBrand GetSearchResult()
        {
            ComputerBrand ComputerBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int ComputerBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                ComputerBrand = this.srvComputerBrand.GetById(ComputerBrandId);
            }

            return ComputerBrand;
        }

        #endregion Methods
    }
}
