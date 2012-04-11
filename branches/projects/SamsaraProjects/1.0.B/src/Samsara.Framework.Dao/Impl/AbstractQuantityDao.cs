
using Samsara.Base.Dao.Impl;
using Samsara.Framework.Core.Entities;
using Samsara.Framework.Core.Parameters;
using Samsara.Framework.Dao.Interfaces;

namespace Samsara.Framework.Dao.Impl
{
    public class AbstractQuantityDao : BaseDao<AbstractQuantity, int, AbstractQuantityParameters>, IAbstractQuantityDao
    {
    }
}