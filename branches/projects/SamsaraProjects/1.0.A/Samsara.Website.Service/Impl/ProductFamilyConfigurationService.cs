
using Samsara.Base.Service.Impl;
using Samsara.Website.Core.Entities;
using Samsara.Website.Core.Parameters;
using Samsara.Website.Dao.Interfaces;
using Samsara.Website.Service.Interfaces;

namespace Samsara.Website.Service.Impl
{
    public class ProductFamilyConfigurationService : GenericService<ProductFamilyConfiguration, int, IProductFamilyConfigurationDao, ProductFamilyConfigurationParameters>, IProductFamilyConfigurationService
    {
    }
}