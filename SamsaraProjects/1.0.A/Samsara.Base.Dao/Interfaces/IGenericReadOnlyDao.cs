
using System;
using System.Collections.Generic;
using System.Data;

namespace Samsara.Base.Dao.Interfaces
{
    public interface IGenericReadOnlyDao
    {
        IList<T> GetAll<T>();
        T GetById<T>(object Id);
        DateTime GetServerDateTime();
        T GetByParameters<T>(object parameters);
        DataTable SearchByParameters<T>(object parameters);
        IList<T> GetListByParameters<T>(object parameters);
        DataTable SearchByParameters(string queryName, object parameters, bool absoluteColumnNames);
    }
}