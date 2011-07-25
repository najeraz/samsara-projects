using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Samsara.ProjectsAndTendering.Controls
{
    public partial class SamsaraSearchControl : UserControl
    {
        public Form SearchForm
        {
            get;
            set;
        }

        public SamsaraSearchControl()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.SearchForm != null)
            {

            }
        }
    }
}
