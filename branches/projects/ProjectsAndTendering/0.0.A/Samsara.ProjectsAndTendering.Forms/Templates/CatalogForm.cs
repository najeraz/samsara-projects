using System.Windows.Forms;
using Infragistics.Win;
using Samsara.ProjectsAndTendering.Forms.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class CatalogForm : Form, ISearchForm
    {
        public bool IsCalledForSearch
        {
            get;
            set;
        }

        private TabPage hiddedTabPage = null;

        public CatalogForm()
        {
            InitializeComponent();
            this.grdSchSearch.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.hiddedTabPage = this.tabPrincipal.TabPages["New"];
            this.IsCalledForSearch = false;
        }

        public void HiddenDetail(bool hidden)
        {
            if (hidden)
                this.tabPrincipal.TabPages.Remove(hiddedTabPage);
            else if (!this.tabPrincipal.TabPages.ContainsKey("New"))
                this.tabPrincipal.TabPages.Add(hiddedTabPage);
        }
    }
}
