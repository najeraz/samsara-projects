using System;
using System.Windows.Forms;
using Samsara.ProjectsAndTendering.Controls.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls
{
    public partial class SamsaraSearchControl<T> : UserControl
    {
        public ISearchForm<T> SearchForm
        {
            private get;
            set;
        }

        public string DisplayMember
        {
            private get;
            set;
        }

        public T Value
        {
            get;
            private set;
        }

        public SamsaraSearchControl()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.SearchForm != null && !string.IsNullOrEmpty(this.DisplayMember))
            {
                ISearchForm<T> form = (ISearchForm<T>)Activator.CreateInstance(this.SearchForm.GetType());
                form.ParentSearchForm = (ISearchForm<T>)this.ParentForm;
                form.PrepareSearchControls();
                ((Form)form).ShowDialog(this);
                this.Value = form.SearchResult;
                if (this.Value != null)
                {
                    this.txtName.Text = this.Value.GetType()
                        .GetProperty(this.DisplayMember).GetValue(this.Value, null).ToString();
                }
            }
        }
    }
}
