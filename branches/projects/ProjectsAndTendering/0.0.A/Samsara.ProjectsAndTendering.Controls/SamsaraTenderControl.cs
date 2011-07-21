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
    public partial class SamsaraTenderControl : UserControl
    {
        public SamsaraTenderControl()
        {
            InitializeComponent();
        }

        private void SamsaraTenderControl_SizeChanged(object sender, EventArgs e)
        {
            this.txtName.Size = new Size(this.Width - 38, this.txtName.Size.Height);

        }
    }
}
