
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
    public partial class RouterBrandForm : RouterBrandSearchForm
    {
        #region Attributes

        private RouterBrandFormController ctrlRouterBrandForm;
        private IRouterBrandService srvRouterBrand;

        #endregion Attributes

        public RouterBrandForm()
        {
            InitializeComponent();
            this.ctrlRouterBrandForm = new RouterBrandFormController(this);
            this.srvRouterBrand = SamsaraAppContext.Resolve<IRouterBrandService>();
            Assert.IsNotNull(this.srvRouterBrand);
        }

        #region Methods

        public override RouterBrand GetSerchResult()
        {
            RouterBrand RouterBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int RouterBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                RouterBrand = this.srvRouterBrand.GetById(RouterBrandId);
            }

            return RouterBrand;
        }

        #endregion Methods
    }
}
