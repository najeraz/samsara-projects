
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
    public partial class CommutatorBrandForm : CommutatorBrandSearchForm
    {
        #region Attributes

        private CommutatorBrandFormController ctrlCommutatorBrandForm;
        private ICommutatorBrandService srvCommutatorBrand;

        #endregion Attributes

        public CommutatorBrandForm()
        {
            InitializeComponent();
            this.ctrlCommutatorBrandForm = new CommutatorBrandFormController(this);
            this.srvCommutatorBrand = SamsaraAppContext.Resolve<ICommutatorBrandService>();
            Assert.IsNotNull(this.srvCommutatorBrand);
        }

        #region Methods

        public override CommutatorBrand GetSerchResult()
        {
            CommutatorBrand CommutatorBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CommutatorBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                CommutatorBrand = this.srvCommutatorBrand.GetById(CommutatorBrandId);
            }

            return CommutatorBrand;
        }

        #endregion Methods
    }
}
