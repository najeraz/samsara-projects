
using Samsara.Base.Forms.Forms;
using Samsara.Configuration.Core.Entities;

namespace Samsara.Configuration.Forms.Templates
{
    public partial class FormConfigurationUserPermissionSearchForm : GenericCatalogSearchForm<FormConfigurationUserPermission>
    {
        public FormConfigurationUserPermissionSearchForm()
        {
            InitializeComponent();
        }

        public override FormConfigurationUserPermission GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
