﻿
using Samsara.Base.Dao.Interfaces;
using Samsara.Website.Core.Entities;
using Samsara.Website.Core.Parameters;

namespace Samsara.Website.Dao.Interfaces
{
    public interface IProductConfigurationDao : IBaseDao<ProductConfiguration, int, ProductConfigurationParameters>
    {
    }
}
