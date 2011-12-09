
using System.Windows.Forms;
using Infragistics.Win;
using System;

namespace Samsara.Base.Forms.Forms
{
    public partial class CatalogForm : Form
    {
        #region Attributes

        private enum FormStatus
        {
            Creation,
            Edition
        }

        private TabPage hiddenTabPage = null;
        private FormStatus status;
         
        #endregion Attributes

        #region Properties

        #endregion Properties

        #region Constructor

        public CatalogForm()
        {
            InitializeComponent();
            this.grdSchSearch.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.hiddenTabPage = this.tabPrincipal.TabPages["New"];
            this.status = FormStatus.Creation;
        }

        #endregion Constructor

        #region Methods

        public void HiddenDetail(bool hidden)
        {
            if (hidden)
                this.tabPrincipal.TabPages.Remove(hiddenTabPage);
            else if (!this.tabPrincipal.TabPages.ContainsKey("New"))
                this.tabPrincipal.TabPages.Add(hiddenTabPage);

            switch (this.status)
            {
                case FormStatus.Creation:
                    hiddenTabPage.Text = "Nuevo";
                    break;
                case FormStatus.Edition:
                    hiddenTabPage.Text = "Edición";
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
        
        #endregion Methods

        #region Events

        private void btnSchClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSchCreate_Click(object sender, System.EventArgs e)
        {
            this.status = FormStatus.Creation;
        }

        private void btnSchEdit_Click(object sender, System.EventArgs e)
        {
            this.status = FormStatus.Edition;
        }

        #endregion Events
    }
}
