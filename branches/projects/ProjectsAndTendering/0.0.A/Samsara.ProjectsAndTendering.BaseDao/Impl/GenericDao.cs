using System;
using System.Collections.Generic;
using System.Reflection;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Spring.Data.NHibernate.Generic.Support;
using System.Data;
using System.Linq;
using Samsara.Support.Util;
using NHibernate.Criterion;
using NHibernate.Impl;
using System.Collections;

namespace Samsara.ProjectsAndTendering.BaseDao.Impl
{
    public class GenericDao<T, TId> : HibernateDaoSupport, IGenericDao<T, TId>
    {
        #region IGenericDao<T,TId> Members

        public void GetConfiguration() {
        }

        public IList<T> GetAll() {
            return HibernateTemplate.LoadAll<T>();
        }

        public void Save(T obj) {
            HibernateTemplate.Save(obj);
        }

        public void Update(T obj) {
            HibernateTemplate.Update(obj);
        }

        public void Delete(T obj) {
            HibernateTemplate.Delete(obj);
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

        public IList<T> GetListByObjectProperties(string queryName, object obj)
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery(queryName);

            foreach (PropertyInfo pInfo in obj.GetType().GetProperties())
            {
                if (pInfo.GetValue(obj, null) != null)
                {
                    if (pInfo.PropertyType.IsAssignableFrom(typeof(DateTime)))
                        dnq.SetDateTime(pInfo.Name, (DateTime)pInfo.GetValue(obj, null));
                    if (pInfo.PropertyType.IsAssignableFrom(typeof(string)))
                        dnq.SetString(pInfo.Name, (string)pInfo.GetValue(obj, null));
                    else
                        dnq.SetParameter(pInfo.Name, pInfo.GetValue(obj, null));
                }
            }

            return this.GetList<T>(dnq);
        }

        public IList GetObjectListByObjectProperties(string queryName, object obj)
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery(queryName);

            foreach (PropertyInfo pInfo in obj.GetType().GetProperties())
            {
                if (pInfo.GetValue(obj, null) != null)
                {
                    if (pInfo.PropertyType.IsAssignableFrom(typeof(DateTime)))
                        dnq.SetDateTime(pInfo.Name, (DateTime)pInfo.GetValue(obj, null));
                    if (pInfo.PropertyType.IsAssignableFrom(typeof(string)))
                        dnq.SetAnsiString(pInfo.Name, (string)pInfo.GetValue(obj, null));
                    else
                        dnq.SetParameter(pInfo.Name, pInfo.GetValue(obj, null));
                }
            }

            return this.GetObjectList(dnq);
        }

        public DataTable DataTableByObjectProperties(string queryName, object obj)
        {
            IList lstResult = GetObjectListByObjectProperties(queryName, obj);
            return CollectionsUtil.ConvertToDataTable(lstResult);
        }

        public DataTable DataTableTypedByObjectProperties<TType>(string queryName, object obj)
        {
            IList lstResult = GetObjectListByObjectProperties(queryName, obj);
            return CollectionsUtil.ConvertToDataTable<TType>(lstResult.Cast<TType>().ToList());
        }
        
        #endregion
    }
}