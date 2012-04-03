
using System;
using System.Reflection;
using NHibernate.Impl;

namespace Samsara.Support.Util
{
    public class NHibernateUtil
    {
        public static void SetDetachedNamedQueryParameters(DetachedNamedQuery dnq, object parameters)
        {
            object parameterValue;
            Type nullableType;

            if (parameters == null)
                return;

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
        }
    }
}
