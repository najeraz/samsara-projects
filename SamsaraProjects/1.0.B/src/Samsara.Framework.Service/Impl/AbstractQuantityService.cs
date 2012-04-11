
using Samsara.Base.Service.Impl;
using Samsara.Framework.Core.Entities;
using Samsara.Framework.Core.Parameters;
using Samsara.Framework.Dao.Interfaces;
using Samsara.Framework.Service.Interfaces;

namespace Samsara.Framework.Service.Impl
{
    public class AbstractQuantityService : BaseService<AbstractQuantity, int, IAbstractQuantityDao, AbstractQuantityParameters>, IAbstractQuantityService
    {
    }
}