
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate.Impl;
using Samsara.Base.Dao.Interfaces;
using Samsara.Persistance.NHibernate.Transformers;
using Samsara.Support.Util;
using Spring.Data.NHibernate.Generic.Support;

namespace Samsara.Base.Dao.Impl
{
    public class GenericReadOnlyDao : HibernateDaoSupport, IGenericReadOnlyDao
    {
        #region Methods

        #region Public

        public virtual IList<T> GetAll<T>()
        {
            return this.HibernateTemplate.LoadAll<T>();
        }

        public virtual T GetById<T>(object Id)
        {
            return this.HibernateTemplate.Get<T>(Id);
        }

        public virtual DateTime GetServerDateTime()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("BaseReadOnlyDao.GetServerDateTime");
            DateTime result = dnq.GetExecutableQuery(Session).UniqueResult<DateTime>();
            return result;
        }

        public virtual T GetByParameters<T>(object parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(
                typeof(T).Name + ".GetByParameters", parameters);
            return dnq.GetExecutableQuery(Session).UniqueResult<T>();
        }

        public virtual DataTable SearchByParameters<T>(object parameters)
        {
            return this.DataTableByParameters<T>(
                typeof(T).Name + ".SearchByParameters", parameters, false);
        }

        public virtual DataTable SearchByParameters(string queryName, object parameters, bool absoluteColumnNames)
        {
            return this.DataTableByParameters(queryName, parameters, absoluteColumnNames);
        }

        public virtual DataTable SearchByParameters(string queryName, object parameters)
        {
            return this.DataTableByParameters(queryName, parameters, false);
        }

        public virtual IList<T> GetListByParameters<T>(object parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(
                typeof(T).Name + ".GetListByParameters", parameters);
            return this.GetList<T>(dnq);
        }

        public virtual IList<T> GetListByParameters<T>(string queryName, object parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(queryName, parameters);
            return this.GetList<T>(dnq);
        }

        #endregion Public

        #region Protected

        protected virtual DetachedNamedQuery GetDetachedNamedQuery(string queryName, object parameters)
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery(queryName);
            Samsara.Support.Util.NHibernateUtil.SetDetachedNamedQueryParameters(dnq, parameters);
            return dnq;
        }

        protected virtual DataTable DataTableByParameters<T>(string queryName, object parameters, bool absoluteColumnNames)
        {
            DataTable dtResult = null;

            try
            {
                IList<T> lstResult = this.GetListByParameters<T>(queryName, parameters);
                dtResult = CollectionsUtil.ConvertToDataTable<T>(lstResult, absoluteColumnNames);
            }
            catch
            {
                return this.DataTableByParameters(queryName, parameters, absoluteColumnNames);
            }

            return dtResult;
        }

        protected virtual DataTable DataTableByParameters(string queryName, object parameters, bool absoluteColumnNames)
        {
            DataTable dtResult = null;

            try
            {
                IList lstResult = GetGenericListByParameters(queryName, parameters);
                dtResult = CollectionsUtil.ConvertToDataTable(lstResult.Cast<object>().ToList(), null);
            }
            catch { }

            return dtResult;
        }

        #endregion Protected

        #region Private

        private IList<T> GetList<T>(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List<T>();
        }

        private IList GetGenericList(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List();
        }

        private IList GetGenericListByParameters(string queryName, object parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(queryName, parameters);
            dnq.SetResultTransformer(new NativeSQLTransformer());
            return this.GetGenericList(dnq);
        }

        #endregion Private

        #endregion Methods
    }
}