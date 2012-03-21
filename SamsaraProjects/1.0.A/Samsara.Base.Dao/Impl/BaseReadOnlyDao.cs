
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using NHibernate.Criterion;
using NHibernate.Impl;
using Samsara.Base.Dao.Interfaces;
using Samsara.Persistance.NHibernate.Transformers;
using Samsara.Support.Util;
using Spring.Data.NHibernate.Generic.Support;

namespace Samsara.Base.Dao.Impl
{
    public class BaseReadOnlyDao<T, TId, Tpmt> : HibernateDaoSupport, IBaseReadOnlyDao<T, TId, Tpmt>
    {
        #region Methods

        #region Public

        public virtual IList<T> GetAll()
        {
            return this.HibernateTemplate.LoadAll<T>();
        }

        public virtual T GetById(TId Id)
        {
            return this.HibernateTemplate.Get<T>(Id);
        }

        public virtual DateTime GetServerDateTime()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("BaseReadOnlyDao.GetServerDateTime");

            DateTime result = dnq.GetExecutableQuery(Session).UniqueResult<DateTime>();

            return result;
        }

        public virtual T GetByParameters(Tpmt parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(
                typeof(T).Name + ".GetByParameters", parameters);
            return dnq.GetExecutableQuery(Session).UniqueResult<T>();
        }

        public virtual DataTable SearchByParameters(Tpmt parameters)
        {
            return this.DataTableByParameters(
                typeof(T).Name + ".SearchByParameters", parameters, false);
        }

        public virtual DataTable CustomSearchByParameters(string queryName, Tpmt parameters, bool absoluteColumnNames)
        {
            return this.DataTableByParameters(queryName, parameters, absoluteColumnNames);
        }

        public virtual IList<T> GetListByParameters(Tpmt parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(
                typeof(T).Name + ".GetListByParameters", parameters);
            return this.GetList(dnq);
        }

        public virtual IList<T> GetListByParameters(string queryName, Tpmt parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(queryName, parameters);
            return this.GetList(dnq);
        }

        public virtual IList<T> GetList(DetachedQuery dq)
        {
            return dq.GetExecutableQuery(Session).List<T>();
        }

        public virtual IList<T> GetList(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List<T>();
        }

        public virtual IList<T> GetList(DetachedCriteria detachedCriteria)
        {
            return detachedCriteria.GetExecutableCriteria(Session).List<T>();
        }

        #endregion Public

        #region Protected

        protected virtual DataTable DataTableByParameters(string queryName, Tpmt parameters, bool absoluteColumnNames)
        {
            DataTable dtResult = null;

            try
            {
                IList<T> lstResult = this.GetListByParameters(queryName, parameters);
                dtResult = CollectionsUtil.ConvertToDataTable<T>(lstResult, absoluteColumnNames);
            }
            catch
            {
                try
                {
                    IList lstResult = GetGenericListByParameters(queryName, parameters);
                    dtResult = CollectionsUtil.ConvertToDataTable(lstResult.Cast<object>().ToList(), typeof(T).Name);
                }
                catch { }
            }

            return dtResult;
        }

        protected virtual DetachedNamedQuery GetDetachedNamedQuery(string queryName, Tpmt parameters)
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery(queryName);
            NHibernateUtil.SetDetachedNamedQueryParameters(dnq, parameters);
            return dnq;
        }

        #endregion Protected

        #region Private

        private IList GetGenericList(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List();
        }

        private IList GetGenericListByParameters(string queryName, Tpmt parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(queryName, parameters);
            dnq.SetResultTransformer(new NativeSQLTransformer());
            return this.GetGenericList(dnq);
        }

        #endregion Private

        #endregion Methods
    }
}