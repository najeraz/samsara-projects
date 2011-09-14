
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
    public partial class PersonalComputerTypeForm : PersonalComputerTypeSearchForm
    {
        #region Attributes

        private PersonalComputerTypeFormController ctrlPersonalComputerTypeForm;
        private IPersonalComputerTypeService srvPersonalComputerType;

        #endregion Attributes

        public PersonalComputerTypeForm()
        {
            InitializeComponent();
            this.ctrlPersonalComputerTypeForm = new PersonalComputerTypeFormController(this);
            this.srvPersonalComputerType = SamsaraAppContext.Resolve<IPersonalComputerTypeService>();
            Assert.IsNotNull(this.srvPersonalComputerType);
        }

        #region Methods

        public override PersonalComputerType GetSerchResult()
        {
            PersonalComputerType PersonalComputerType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int PersonalComputerTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                PersonalComputerType = this.srvPersonalComputerType.GetById(PersonalComputerTypeId);
            }

            return PersonalComputerType;
        }

        #endregion Methods
    }
}
