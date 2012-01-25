
using System;
using System.Data;
using NHibernate.Impl;
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Dao.Interfaces
{
    public interface IAlleatoERPDao
    {
        DateTime GetServerDateTime();
        DataTable CustomSearchByParameters(string queryName, GenericParameters parameters, bool absoluteColumnNames);
        DetachedNamedQuery GetDetachedNamedQuery(string queryName, GenericParameters parameters);
    }
}