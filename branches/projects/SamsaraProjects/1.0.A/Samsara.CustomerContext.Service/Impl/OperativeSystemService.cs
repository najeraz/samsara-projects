
using Samsara.Base.Service.Impl;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Service.Impl
{
    public class OperativeSystemService : BaseService<OperativeSystem, int, IOperativeSystemDao, OperativeSystemParameters>, IOperativeSystemService
    {
    }
}