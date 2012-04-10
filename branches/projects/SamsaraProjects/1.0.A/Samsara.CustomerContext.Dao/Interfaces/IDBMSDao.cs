
using Samsara.Base.Dao.Interfaces;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;

namespace Samsara.CustomerContext.Dao.Interfaces
{
    public interface IDBMSDao : IBaseDao<DBMS, int, DBMSParameters>
    {
    }
}
