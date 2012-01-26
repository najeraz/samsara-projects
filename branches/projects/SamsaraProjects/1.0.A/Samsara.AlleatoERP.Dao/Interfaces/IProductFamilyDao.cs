﻿
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.Base.Dao.Interfaces;

namespace Samsara.AlleatoERP.Dao.Interfaces
{
    public interface IProductFamilyDao : IGenericReadOnlyDao<ProductFamily, int, ProductFamilyParameters>
    {
    }
}
