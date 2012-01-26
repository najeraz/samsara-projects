﻿
using System.Windows.Forms;
using Infragistics.Win;
using Samsara.Base.Forms.Controllers;

namespace Samsara.Base.Forms.Forms
{
    public partial class GenericReportForm : Form
    {
        #region Attributes

        protected GenericReportFormController controller;
         
        #endregion Attributes

        #region Properties

        #endregion Properties

        #region Constructor

        public GenericReportForm()
        {
            InitializeComponent();
            this.controller = new GenericReportFormController(this);
            this.grdPrincipal.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        #endregion Constructor

        #region Methods
        
        #endregion Methods

        #region Events

        private void btnPrplClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnClick(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                switch (btn.Name)
                {
                    case "btnPrplGenerate":
                        this.controller.GenerateReport();
                        break;
                    default:
                        break;
                }
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion Events
    }
}
