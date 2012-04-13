
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Choosers
{
    public partial class BackupSoftwareBrandChooserControl : SamsaraEntityChooserControl<BackupSoftwareBrand, int, IBackupSoftwareBrandService, IBackupSoftwareBrandDao, BackupSoftwareBrandParameters>
    {
        public BackupSoftwareBrandChooserControl()
        {
            assemblyName = ".Forms.dll";
            assemblyFormClassName = ".Forms.Forms.BackupSoftwareBrandForm";
            InitializeComponent();
        }
    }
}
