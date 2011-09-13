
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class DocumentTypeWarrantySearchForm : GenericSearchForm<DocumentTypeWarranty>
    {
        public DocumentTypeWarrantySearchForm()
        {
            InitializeComponent();
        }

        public override DocumentTypeWarranty GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
