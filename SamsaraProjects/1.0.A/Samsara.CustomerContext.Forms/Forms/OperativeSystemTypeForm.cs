
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class OperativeSystemTypeForm : OperativeSystemTypeSearchForm
    {
        #region Attributes

        private OperativeSystemTypeFormController ctrlOperativeSystemTypeForm;
        private IOperativeSystemTypeService srvOperativeSystemType;

        #endregion Attributes

        public OperativeSystemTypeForm()
        {
            InitializeComponent();
            this.ctrlOperativeSystemTypeForm = new OperativeSystemTypeFormController(this);
            this.srvOperativeSystemType = SamsaraAppContext.Resolve<IOperativeSystemTypeService>();
        }

        #region Methods

        public override OperativeSystemType GetSearchResult()
        {
            OperativeSystemType OperativeSystemType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int OperativeSystemTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                OperativeSystemType = this.srvOperativeSystemType.GetById(OperativeSystemTypeId);
            }

            return OperativeSystemType;
        }

        #endregion Methods
    }
}
