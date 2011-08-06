
using System.Windows.Forms;
using Samsara.ProjectsAndTendering.Controls.Interfaces;
using Samsara.ProjectsAndTendering.Forms.Forms;

namespace Samsara.ProjectsAndTendering.Forms.Templates
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
            this.SearchResult = this.GetSerchResult();
            this.Close();
        }

        abstract internal T GetSerchResult();

        #endregion Events
    }
}
