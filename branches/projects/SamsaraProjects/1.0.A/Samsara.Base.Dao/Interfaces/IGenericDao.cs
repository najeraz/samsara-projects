﻿
using System;
using System.Collections.Generic;
using System.Data;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Samsara.Base.Dao.Interfaces
{
    public interface IGenericDao<T, TId, Tpmt>
    {
        void Delete(T entity);
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
        void SaveOrUpdate(T entity);
        void Save(T entity);
        void Update(T entity);
        void Refresh(T entity);
        DetachedNamedQuery GetDetachedNamedQuery(string queryName, Tpmt parameters);
    }
}