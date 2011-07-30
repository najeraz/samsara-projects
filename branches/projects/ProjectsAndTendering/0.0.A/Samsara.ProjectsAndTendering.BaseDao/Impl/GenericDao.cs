
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using NHibernate.Criterion;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.Support.Util;
using Spring.Data.NHibernate.Generic.Support;

namespace Samsara.ProjectsAndTendering.BaseDao.Impl
{
    public class GenericDao<T, TId> : HibernateDaoSupport, IGenericDao<T, TId>
    {
        #region Methods
        
        #region Public

        public IList<T> GetAll() {
            return HibernateTemplate.LoadAll<T>();
        }

        public void SaveOrUpdate(T entity)
        {
            HibernateTemplate.SaveOrUpdate(entity);
        }

        public void Save(T entity)
        {
            HibernateTemplate.Save(entity);
        }

        public void Refresh(T entity)
        {
            HibernateTemplate.Refresh(entity);
        }

        public void Update(T entity)
        {
            HibernateTemplate.Update(entity);
        }

        public void Delete(T entity) {
            HibernateTemplate.Delete(entity);
        }

        public T GetById(TId Id) {
            return HibernateTemplate.Get<T>(Id);
        }

        public IList<T> GetList(DetachedQuery dq) {
            return dq.GetExecutableQuery(Session).List<T>();
        }

        public IList<TType> GetList<TType>(DetachedQuery dq) {
            return dq.GetExecutableQuery(Session).List<TType>();
        }

        public IList GetObjectList(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List();
        }
        
        public IList<T> GetList(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List<T>();
        }

        public IList<TType> GetList<TType>(DetachedNamedQuery dnq) {
            return dnq.GetExecutableQuery(Session).List<TType>();
        }

        public IList<T> GetList(DetachedCriteria detachedCriteria) {
            return detachedCriteria.GetExecutableCriteria(Session).List<T>();
        }

        public IList<TType> GetList<TType>(DetachedCriteria detachedCriteria) {
            return detachedCriteria.GetExecutableCriteria(Session).List<TType>();
        }

        public IList<T> GetListByParameters(string queryName, GenericParameters parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(queryName, parameters);
            return this.GetList<T>(dnq);
        }

        public IList GetGenericListByParameters(string queryName, GenericParameters parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(queryName, parameters);
            return this.GetObjectList(dnq);
        }

        public DataTable DataTableByParameters(string queryName, GenericParameters parameters)
        {
            IList lstResult = GetGenericListByParameters(queryName, parameters);
            return CollectionsUtil.ConvertToDataTable(lstResult);
        }

        public DataTable DataTableByParameters<TType>(string queryName, GenericParameters parameters)
        {
            IList lstResult = GetGenericListByParameters(queryName, parameters);
            return CollectionsUtil.ConvertToDataTable<TType>(lstResult.Cast<TType>().ToList());
        }

        #endregion Public

        #region Private

        private DetachedNamedQuery GetDetachedNamedQuery(string queryName, GenericParameters parameters)
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery(queryName);

            foreach (PropertyInfo pInfo in parameters.GetType().GetProperties())
            {
                if (pInfo.GetValue(parameters, null) != null)
                {
                    if (pInfo.PropertyType.IsAssignableFrom(typeof(bool)))
                        dnq.SetBoolean(pInfo.Name, (bool)pInfo.GetValue(parameters, null));
                    if (pInfo.PropertyType.IsAssignableFrom(typeof(DateTime)))
                        dnq.SetDateTime(pInfo.Name, (DateTime)pInfo.GetValue(parameters, null));
                    if (pInfo.PropertyType.IsAssignableFrom(typeof(string)))
                        dnq.SetString(pInfo.Name, (string)pInfo.GetValue(parameters, null));
                    if (Nullable.GetUnderlyingType(pInfo.PropertyType) != null
                        && Nullable.GetUnderlyingType(pInfo.PropertyType).IsEnum)
                        dnq.SetInt32(pInfo.Name, (int)pInfo.GetValue(parameters, null));
                    else
                        dnq.SetParameter(pInfo.Name, pInfo.GetValue(parameters, null));
                }
            }

            return dnq;
        }

        #endregion Private

        #endregion Methods
    }
}