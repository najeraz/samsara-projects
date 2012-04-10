
using System;
using System.Windows.Forms;
using Samsara.Controls.Interfaces;

namespace Samsara.Controls
{
    public partial class SamsaraSearchControl<T> : UserControl
    {
        private T value;

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

        public bool ReadOnly
        {
            get
            {
                return !this.btnSearch.Enabled;
            }
            set
            {
                this.btnSearch.Enabled = !value;
            }
        }

        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                if (this.value != null && this.DisplayMember != null)
                {
                    this.txtName.Text = this.Value.GetType()
                        .GetProperty(this.DisplayMember).GetValue(this.Value, null).ToString();
                }
                else
                {
                    this.txtName.Text = string.Empty;
                }
            }
        }

        public SamsaraSearchControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            this.Value = default(T);
            this.txtName.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.SearchForm != null && !string.IsNullOrEmpty(this.DisplayMember))
            {
                ISearchForm<T> form = Activator.CreateInstance(this.SearchForm.GetType()) as ISearchForm<T>;
                form.ParentSearchForm = this.ParentForm;
                form.PrepareSearchControls();
                (form as Form).ShowDialog(this);
                this.Value = form.SearchResult;
                if (this.Value != null)
                {
                    this.txtName.Text = this.Value.GetType()
                        .GetProperty(this.DisplayMember).GetValue(this.Value, null).ToString();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.value = default(T);
            this.txtName.Text = string.Empty;
        }
    }
}
