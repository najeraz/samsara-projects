
using Samsara.Base.Controls.Controls;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls.Controls.Choosers
{
    public partial class DocumentTypeWarrantyChooserControl : SamsaraEntityChooserControl<DocumentTypeWarranty, int, IDocumentTypeWarrantyService, IDocumentTypeWarrantyDao, DocumentTypeWarrantyParameters>
    {
        public DocumentTypeWarrantyChooserControl()
        {
            assemblyName = "Samsara.ProjectsAndTendering.Forms.dll";
            assemblyFormClassName = "Samsara.ProjectsAndTendering.Forms.Forms.DocumentTypeWarrantyForm";
            InitializeComponent();
        }
    }
}
