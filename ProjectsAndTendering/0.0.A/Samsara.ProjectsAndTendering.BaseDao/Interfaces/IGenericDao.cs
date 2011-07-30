using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Samsara.ProjectsAndTendering.BaseDao.Interfaces
{
    public interface IGenericDao<T, TId>
    {
        void Delete(T entity);
        IList<T> GetAll();
        T GetById(TId Id);
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
    }
}