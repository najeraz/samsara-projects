
using Samsara.Base.Dao.Impl;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Dao.Interfaces;
using NHibernate.Impl;

namespace Samsara.Commissions.Dao.Impl
{
    public class ServiceDao : BaseDao<Service, int, ServiceParameters>, IServiceDao
    {
    }
}