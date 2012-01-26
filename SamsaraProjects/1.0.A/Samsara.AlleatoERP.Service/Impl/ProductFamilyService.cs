
using Samsara.Base.Service.Impl;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;

namespace Samsara.AlleatoERP.Service.Impl
{
    public class ProductFamilyService : GenericReadOnlyService<ProductFamily, int, IProductFamilyDao, ProductFamilyParameters>, IProductFamilyService
    {
    }
}