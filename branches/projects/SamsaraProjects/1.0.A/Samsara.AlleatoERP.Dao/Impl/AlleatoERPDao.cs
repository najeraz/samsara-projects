
using System;
using System.Collections;
using System.Data;
using System.Reflection;
using NHibernate.Impl;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.Base.Core.Parameters;
using Samsara.Support.Util;
using Spring.Data.NHibernate.Generic.Support;

namespace Samsara.AlleatoERP.Dao.Impl
{
    public class AlleatoERPDao : HibernateDaoSupport, IAlleatoERPDao
    {
        #region Methods

        #region Public

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

        public DataTable CustomSearchByParameters(string queryName, GenericParameters parameters, bool absoluteColumnNames)
        {
            return this.DataTableByParameters(queryName, parameters, absoluteColumnNames);
        }

        public IList GetObjectList(DetachedNamedQuery dnq)
        {
            return dnq.GetExecutableQuery(Session).List();
        }

        public IList GetGenericListByParameters(string queryName, GenericParameters parameters)
        {
            DetachedNamedQuery dnq = this.GetDetachedNamedQuery(queryName, parameters);
            return this.GetObjectList(dnq);
        }

        public DataTable DataTableByParameters(string queryName, GenericParameters parameters, bool absoluteColumnNames)
        {
            DataTable dtResult = null;

            IList lstResult = GetGenericListByParameters(queryName, parameters);

            try
            {
                dtResult = CollectionsUtil.ConvertToDataTable(lstResult);
            }
            catch { }

            return dtResult;
        }

        public DetachedNamedQuery GetDetachedNamedQuery(string queryName, GenericParameters parameters)
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