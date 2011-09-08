
using Samsara.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class DocumentTypeWarrantyService : GenericService<DocumentTypeWarranty, int, IDocumentTypeWarrantyDao, DocumentTypeWarrantyParameters>, IDocumentTypeWarrantyService
    {
    }
}