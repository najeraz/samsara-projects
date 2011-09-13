﻿
using Samsara.Base.Dao.Impl;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;

namespace Samsara.CustomerContext.Dao.Impl
{
    public class PersonalComputerTypeDao : GenericDao<PersonalComputerType, int, PersonalComputerTypeParameters>, IPersonalComputerTypeDao
    {
    }
}