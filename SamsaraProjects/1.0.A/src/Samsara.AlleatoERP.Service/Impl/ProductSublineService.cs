
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Service.Impl;

namespace Samsara.AlleatoERP.Service.Impl
{
    public class ProductSublineService : BaseReadOnlyService<ProductSubline, int, IProductSublineDao, ProductSublineParameters>, IProductSublineService
    {
    }
}