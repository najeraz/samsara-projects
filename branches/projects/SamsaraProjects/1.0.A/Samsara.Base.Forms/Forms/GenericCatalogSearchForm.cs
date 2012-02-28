
using System.Windows.Forms;
using Samsara.Controls.Interfaces;

namespace Samsara.Base.Forms.Forms
{
    public abstract partial class GenericCatalogSearchForm<T> : CatalogForm, ISearchForm<T>
    {
        public Form ParentSearchForm
        {
            get;
            set;
        }

        public T SearchResult
        {
            get;
            set;
        }

        public GenericCatalogSearchForm()
        {
            InitializeComponent();
        }

        public virtual void PrepareSearchControls()
        {
            if ((this as ISearchForm<T>).ParentSearchForm != null)
            {
                this.btnSchCreate.Visible = false;
                this.upSchSeparatorCreate.Visible = false;
                this.btnSchEdit.Visible = false;
                this.upSchSeparatorEdit.Visible = false;
                this.btnSchDelete.Visible = false;
                this.btnSchAccept.Visible = true;
                this.btnSchAccept.Click += new System.EventHandler(btnSchAccept_Click);
            }
            else
            {
                this.btnSchAccept.Visible = false;
                this.upSeparatorAccept.Visible = false;
            }
        }

        #region Events

        private void btnSchAccept_Click(object sender, System.EventArgs e)
        {
            this.SearchResult = this.GetSearchResult();
            this.Close();
        }

        abstract public T GetSearchResult();

        #endregion Events
    }
}
