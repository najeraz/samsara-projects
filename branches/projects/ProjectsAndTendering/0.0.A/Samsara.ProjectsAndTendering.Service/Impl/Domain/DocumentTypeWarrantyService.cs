
using Samsara.ProjectsAndTendering.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class DocumentTypeWarrantyService : GenericService<DocumentTypeWarranty, int, IDocumentTypeWarrantyDao, DocumentTypeWarrantyParameters>, IDocumentTypeWarrantyService
    {
    }
}