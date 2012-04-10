
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class BackupSoftwareBrandSearchForm : GenericCatalogSearchForm<BackupSoftwareBrand>
    {
        public BackupSoftwareBrandSearchForm()
        {
            InitializeComponent();
        }

        public override BackupSoftwareBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
