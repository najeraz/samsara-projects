
using Samsara.Base.Dao.Impl;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Dao.Interfaces;

namespace Samsara.Operation.Dao.Impl
{
    public class ProductBrandDao : GenericDao<ProductBrand, int, ProductBrandParameters>, IProductBrandDao
    {
    }
}