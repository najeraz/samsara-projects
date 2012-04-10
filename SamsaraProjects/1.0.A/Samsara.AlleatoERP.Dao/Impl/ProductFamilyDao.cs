
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.Base.Dao.Impl;

namespace Samsara.AlleatoERP.Dao.Impl
{
    public class ProductFamilyDao : BaseReadOnlyDao<ProductFamily, int, ProductFamilyParameters>, IProductFamilyDao
    {
    }
}