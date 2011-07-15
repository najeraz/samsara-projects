﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Spring.Data.NHibernate.Generic.Support;
using uNhAddIns.NH.Expression;
using uNhAddIns.NH.Impl;
using System.Data;
using Samsara.Support.Util;

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

        public IList<T> GetList(DetachedNamedQuery dnq) {
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
                    else
                        dnq.SetParameter(pInfo.Name, pInfo.GetValue(obj, null));
                }
            }

            return this.GetList<T>(dnq);
        }

        public DataTable DataTableByObjectProperties(string queryName, object obj)
        {
            IList<T> lstResult = GetListByObjectProperties(queryName, obj);
            return CollectionsUtil.ConvertToDataTable(lstResult);
        }
        
        #endregion
    }
}