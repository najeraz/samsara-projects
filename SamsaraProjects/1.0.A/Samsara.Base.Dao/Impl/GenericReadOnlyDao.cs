
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Impl;
using Samsara.Base.Dao.Interfaces;
using Samsara.Support.Util;
using Spring.Data.NHibernate.Generic.Support;

namespace Samsara.Base.Dao.Impl
{
    public class GenericReadOnlyDao : HibernateDaoSupport, IGenericReadOnlyDao
    {
        #region Attributes

        private ISession readingSession;

        #endregion Attributes

        #region Properties

        protected ISession ReadingSession
        {
            get
            {
                return this.readingSession = this.readingSession ?? this.HibernateTemplate.SessionFactory.OpenSession();
            }
            set
            {
                this.readingSession = value;
            }
        }

        #endregion Properties

        #region Methods

        #region Public

        public virtual IList<T> GetAll<T>()
        {
            return this.HibernateTemplate.LoadAll<T>();
        }

        public virtual T GetById<T>(object Id)
        {
            return this.Session.Get<T>(Id);
        }

        public virtual DateTime GetServerDateTime()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("GenericReadOnlyDao.GetServerDateTime");

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

        public virtual DataTable CustomSearchByParameters<T>(string queryName, object parameters, bool absoluteColumnNames)
        {
            return this.DataTableByParameters<T>(queryName, parameters, absoluteColumnNames);
        }

        public virtual IList<T> GetListByParameters<T>(object parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(
                typeof(T).Name + ".GetListByParameters", parameters);
            return this.GetList<T>(dnq);
        }

        public virtual IList<T> GetList<T>(DetachedQuery dq)
        {
            return dq.GetExecutableQuery(Session).List<T>();
        }

        public virtual IList GetObjectList(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List();
        }

        public virtual IList<T> GetList<T>(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List<T>();
        }

        public virtual IList<T> GetList<T>(DetachedCriteria detachedCriteria)
        {
            return detachedCriteria.GetExecutableCriteria(Session).List<T>();
        }

        public virtual IList GetGenericListByParameters(string queryName, object parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(queryName, parameters);
            return this.GetObjectList(dnq);
        }

        public virtual DataTable DataTableByParameters<T>(string queryName, object parameters, bool absoluteColumnNames)
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

        public virtual DetachedNamedQuery GetDetachedNamedQuery(string queryName, object parameters)
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