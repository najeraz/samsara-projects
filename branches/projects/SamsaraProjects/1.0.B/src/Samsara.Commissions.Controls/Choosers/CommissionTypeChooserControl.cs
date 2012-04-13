
using Samsara.Base.Controls.Controls;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Dao.Interfaces;
using Samsara.Commissions.Service.Interfaces;

namespace Samsara.Commissions.Controls.Choosers
{
    public partial class CommissionTypeChooserControl : SamsaraEntityChooserControl<CommissionType, int, ICommissionTypeService, ICommissionTypeDao, CommissionTypeParameters>
    {
        public CommissionTypeChooserControl()
        {
            assemblyName = "Samsara.Commissions.Forms.dll";
            assemblyFormClassName = "Samsara.Commissions.Forms.Forms.CommissionTypeForm";
            InitializeComponent();
        }
    }
}
