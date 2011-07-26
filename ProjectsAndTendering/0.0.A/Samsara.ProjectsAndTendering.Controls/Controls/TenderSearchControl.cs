
using System;
using System.Windows.Forms;
using Samsara.ProjectsAndTendering.Controls.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Controls
{
    public partial class TenderSearchControl : SamsaraSearchControl<Tender>
    {
        public TenderSearchControl()
        {
            InitializeComponent();
        }
    }
}
