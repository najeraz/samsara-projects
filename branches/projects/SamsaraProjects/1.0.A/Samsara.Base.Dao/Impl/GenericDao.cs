
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using NHibernate.Criterion;
using NHibernate.Impl;
using Samsara.Base.Dao.Interfaces;
using Samsara.Support.Util;
using Spring.Data.NHibernate.Generic.Support;

namespace Samsara.Base.Dao.Impl
{
    public class GenericDao<T, TId, Tpmt> : HibernateDaoSupport, IGenericDao<T, TId, Tpmt>
    {
        #region Methods

        #region Public

        public virtual IList<T> GetAll()
        {
            return HibernateTemplate.LoadAll<T>();
        }

        public virtual void SaveOrUpdate(T entity)
        {
            HibernateTemplate.SaveOrUpdate(entity);
        }

        public virtual void Save(T entity)
        {
            HibernateTemplate.Save(entity);
        }

        public void Refresh(T entity)
        {
            HibernateTemplate.Refresh(entity);
        }

        public virtual void Update(T entity)
        {
            HibernateTemplate.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            HibernateTemplate.Delete(entity);
        }

        public virtual T GetById(TId Id)
        {
            return HibernateTemplate.Get<T>(Id);
        }

        public DateTime GetServerDateTime()
        {
            DateTime result;

            object resultFromServerDateCall = Session.CreateSQLQuery("SELECT GETDATE()").UniqueResult();

            if (resultFromServerDateCall is string)
                result = DateTime.Parse((string)resultFromServerDateCall);
            else
                result = (DateTime)resultFromServerDateCall;

            return result;
        }

        public T GetByParameters(Tpmt parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(
                typeof(T).Name + ".GetByParameters", parameters);
            return dnq.GetExecutableQuery(Session).UniqueResult<T>();
        }

        public DataTable SearchByParameters(Tpmt parameters)
        {
            return this.DataTableByParameters(
                typeof(T).Name + ".SearchByParameters", parameters, false);
        }

        public DataTable CustomSearchByParameters(string queryName, Tpmt parameters, bool absoluteColumnNames)
        {
            return this.DataTableByParameters(queryName, parameters, absoluteColumnNames);
        }

        public IList<T> GetListByParameters(Tpmt parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(
                typeof(T).Name + ".GetListByParameters", parameters);
            return this.GetList(dnq);
        }

        public IList<T> GetList(DetachedQuery dq)
        {
            return dq.GetExecutableQuery(Session).List<T>();
        }

        public IList<TType> GetList<TType>(DetachedQuery dq)
        {
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

        public IList<TType> GetList<TType>(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List<TType>();
        }

        public IList<T> GetList(DetachedCriteria detachedCriteria)
        {
            return detachedCriteria.GetExecutableCriteria(Session).List<T>();
        }

        public IList<TType> GetList<TType>(DetachedCriteria detachedCriteria)
        {
            return detachedCriteria.GetExecutableCriteria(Session).List<TType>();
        }

        public IList GetGenericListByParameters(string queryName, Tpmt parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(queryName, parameters);
            return this.GetObjectList(dnq);
        }

        public DataTable DataTableByParameters(string queryName, Tpmt parameters, bool absoluteColumnNames)
        {
            DataTable dtResult = null;

            IList lstResult = GetGenericListByParameters(queryName, parameters);

            try
            {
                IList<T> lstTemp = lstTemp = lstResult.Cast<T>().ToList();
                dtResult = CollectionsUtil.ConvertToDataTable<T>(lstTemp, absoluteColumnNames);
            }
            catch
            {
                try
                {
                    dtResult = CollectionsUtil.ConvertToDataTable(lstResult);
                }
                catch { }
            }

            return dtResult;
        }

        public DetachedNamedQuery GetDetachedNamedQuery(string queryName, Tpmt parameters)
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery(queryName);
            object parameterValue;
            Type nullableType;

            foreach (PropertyInfo pInfo in parameters.GetType().GetProperties())
            {
                parameterValue = pInfo.GetValue(parameters, null);
                nullableType = Nullable.GetUnderlyingType(pInfo.PropertyType);
                if (parameterValue != null)
                {
                    if (pInfo.PropertyType.IsAssignableFrom(typeof(int)))
                    {
                        dnq.SetInt32(pInfo.Name, (int)parameterValue);
                    }
                    else if (pInfo.PropertyType.IsAssignableFrom(typeof(bool)))
                    {
                        dnq.SetBoolean(pInfo.Name, (bool)parameterValue);
                    }
                    else if (pInfo.PropertyType.IsAssignableFrom(typeof(DateTime)))
                    {
                        dnq.SetDateTime(pInfo.Name, (DateTime)parameterValue);
                    }
                    else if (pInfo.PropertyType.IsAssignableFrom(typeof(string)))
                    {
                        dnq.SetString(pInfo.Name, parameterValue.ToString());
                    }
                    else if (nullableType != null && nullableType.IsEnum)
                    {
                        dnq.SetInt32(pInfo.Name, (int)parameterValue);
                    }
                    else
                    {
                        dnq.SetParameter(pInfo.Name, parameterValue);
                    }
                }
            }

            return dnq;
        }


        #endregion Public

        #endregion Methods
    }
}