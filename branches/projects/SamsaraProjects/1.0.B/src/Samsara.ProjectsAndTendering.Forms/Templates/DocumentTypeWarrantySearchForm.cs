
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class DocumentTypeWarrantySearchForm : GenericCatalogSearchForm<DocumentTypeWarranty>
    {
        public DocumentTypeWarrantySearchForm()
        {
            InitializeComponent();
        }

        public override DocumentTypeWarranty GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
