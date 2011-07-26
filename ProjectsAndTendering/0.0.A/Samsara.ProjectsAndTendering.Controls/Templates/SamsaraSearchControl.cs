using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Samsara.ProjectsAndTendering.Controls.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

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
                ((Form)this.SearchForm).ShowDialog(this);
                this.Value = this.SearchForm.SearchResult;
                if (this.Value != null)
                {
                    this.txtName.Text = this.Value.GetType()
                        .GetProperty(this.DisplayMember).GetValue(this.Value, null).ToString();
                }
            }
        }
    }
}
