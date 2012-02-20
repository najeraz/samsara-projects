
using Samsara.Base.Forms.Forms;
using Samsara.Base.Controls.Enums;

namespace Samsara.Commissions.Forms.Forms
{
    public partial class ServicesManagementForm : GenericDocumentForm
    {
        public ServicesManagementForm()
        {
            InitializeComponent();

            this.asesorChooserControl1.Parameters = new ProjectsAndTendering.Core.Parameters.AsesorParameters();
            this.asesorChooserControl1.Refresh();
        }

        private void ultraButton1_Click(object sender, System.EventArgs e)
        {
            this.asesorChooserControl1.ControlType = SamsaraEntityChooserControlTypeEnum.Multiple;
        }

        private void ultraButton2_Click(object sender, System.EventArgs e)
        {
            this.asesorChooserControl1.ControlType = SamsaraEntityChooserControlTypeEnum.Single;
        }
    }
}
