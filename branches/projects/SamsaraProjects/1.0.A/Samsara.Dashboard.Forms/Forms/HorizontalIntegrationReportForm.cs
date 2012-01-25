
using Samsara.Base.Forms.Forms;
using Samsara.Dashboard.Forms.Controller;

namespace Samsara.Dashboard.Forms.Forms
{
    public partial class HorizontalIntegrationReportForm : GenericReportForm
    {
        public HorizontalIntegrationReportForm()
        {
            InitializeComponent();

            this.controller = new HorizontalIntegrationReportFormController(this);
        }
    }
}
