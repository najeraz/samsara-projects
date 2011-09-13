
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class ManufacturerForm : ManufacturerSearchForm
    {
        #region Attributes

        private ManufacturerFormController ctrlManufacturerForm;
        private IManufacturerService srvManufacturer;

        #endregion Attributes

        public ManufacturerForm()
        {
            InitializeComponent();
            this.ctrlManufacturerForm = new ManufacturerFormController(this);
            this.srvManufacturer = SamsaraAppContext.Resolve<IManufacturerService>();
            Assert.IsNotNull(this.srvManufacturer);
        }

        #region Methods

        public override Manufacturer GetSerchResult()
        {
            Manufacturer asesor = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int asesorId = Convert.ToInt32(activeRow.Cells[0].Value);
                asesor = this.srvManufacturer.GetById(asesorId);
            }

            return asesor;
        }

        #endregion Methods
    }
}
