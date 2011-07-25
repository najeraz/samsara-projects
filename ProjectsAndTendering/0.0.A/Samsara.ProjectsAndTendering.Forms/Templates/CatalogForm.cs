﻿using System.Windows.Forms;
using Infragistics.Win;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class CatalogForm : Form
    {
        private TabPage hiddedTabPage = null;

        public CatalogForm()
        {
            InitializeComponent();
            this.grdSchSearch.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.hiddedTabPage = this.tabPrincipal.TabPages["New"];
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
