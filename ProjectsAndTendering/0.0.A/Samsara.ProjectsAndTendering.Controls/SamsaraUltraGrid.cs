using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Samsara.ProjectsAndTendering.Controls
{
    public partial class SamsaraUltraGrid : UltraGrid
    {
        public SamsaraUltraGrid()
        {
            InitializeComponent();
        }

        protected override void OnInitializeLayout(InitializeLayoutEventArgs e)
        {
            base.OnInitializeLayout(e);

            if (this.DataSource != null && this.DataSource is DataTable)
            {
                DataTable dtGrid = (DataTable)this.DataSource;

                string a = dtGrid.TableName;
            }
        }
    }
}
