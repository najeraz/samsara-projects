
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class DocumentTypeWarrantySearchForm : GenericSearchForm<DocumentTypeWarranty>
    {
        public DocumentTypeWarrantySearchForm()
        {
            InitializeComponent();
        }

        internal override DocumentTypeWarranty GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
