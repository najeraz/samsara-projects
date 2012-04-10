
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class DBMSForm : DBMSSearchForm
    {
        #region Attributes

        private DBMSFormController ctrlDBMSForm;
        private IDBMSService srvDBMS;

        #endregion Attributes

        public DBMSForm()
        {
            InitializeComponent();
            this.ctrlDBMSForm = new DBMSFormController(this);
            this.srvDBMS = SamsaraAppContext.Resolve<IDBMSService>();
        }

        #region Methods

        public override DBMS GetSearchResult()
        {
            DBMS DBMS = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int DBMSId = Convert.ToInt32(activeRow.Cells[0].Value);
                DBMS = this.srvDBMS.GetById(DBMSId);
            }

            return DBMS;
        }

        #endregion Methods
    }
}
