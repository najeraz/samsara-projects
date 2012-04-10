
using Samsara.Base.Forms.Forms;
using Samsara.Dashboard.Forms.Controller;

namespace Samsara.Dashboard.Forms.Forms
{
    public partial class VerticalIntegrationReportForm : GenericReportForm
    {
        public VerticalIntegrationReportForm()
        {
            InitializeComponent();

            this.controller = new VerticalIntegrationReportFormController(this);
        }
    }
}
