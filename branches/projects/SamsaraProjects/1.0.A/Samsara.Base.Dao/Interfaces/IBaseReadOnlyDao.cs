
using System;
using System.Collections.Generic;
using System.Data;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Samsara.Base.Dao.Interfaces
{
    public interface IBaseReadOnlyDao<T, TId, Tpmt>
    {
        IList<T> GetAll();
        T GetById(TId Id);
        DateTime GetServerDateTime();
        T GetByParameters(Tpmt parameters);
        DataTable SearchByParameters(Tpmt parameters);
        IList<T> GetListByParameters(Tpmt parameters);
        DataTable CustomSearchByParameters(string queryName, Tpmt parameters, bool absoluteColumnNames);
        IList<TType> GetList<TType>(DetachedNamedQuery dnq);
        IList<T> GetList(DetachedNamedQuery dnq);
        IList<TType> GetList<TType>(DetachedCriteria detachedCriteria);
        IList<T> GetList(DetachedCriteria detachedCriteria);
        IList<T> GetList(DetachedQuery dq);
        IList<TType> GetList<TType>(DetachedQuery dq);
        DetachedNamedQuery GetDetachedNamedQuery(string queryName, Tpmt parameters);
    }
}