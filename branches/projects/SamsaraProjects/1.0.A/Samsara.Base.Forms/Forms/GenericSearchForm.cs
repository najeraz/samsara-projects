
using System.Windows.Forms;
using Samsara.Controls.Interfaces;

namespace Samsara.Base.Forms.Forms
{
    public abstract partial class GenericSearchForm<T> : CatalogForm, ISearchForm<T>
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

        public GenericSearchForm()
        {
            InitializeComponent();
        }

        public virtual void PrepareSearchControls()
        {
            if (((ISearchForm<T>)this).ParentSearchForm != null)
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
