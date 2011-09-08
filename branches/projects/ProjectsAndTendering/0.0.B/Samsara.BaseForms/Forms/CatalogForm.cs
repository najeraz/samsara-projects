using System.Windows.Forms;
using Infragistics.Win;

namespace Samsara.BaseForms.Forms
{
    public partial class CatalogForm : Form
    {
        #region Attributes
        
        private TabPage hiddenTabPage = null;
         
        #endregion Attributes

        #region Properties

        #endregion Properties

        #region Constructor

        public CatalogForm()
        {
            InitializeComponent();
            this.grdSchSearch.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.hiddenTabPage = this.tabPrincipal.TabPages["New"];
        }

        #endregion Constructor

        #region Methods

        public void HiddenDetail(bool hidden)
        {
            if (hidden)
                this.tabPrincipal.TabPages.Remove(hiddenTabPage);
            else if (!this.tabPrincipal.TabPages.ContainsKey("New"))
                this.tabPrincipal.TabPages.Add(hiddenTabPage);
        }

        #endregion Methods

        #region Events

        private void btnSchClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #endregion Events
    }
}
