
using System;
using System.Linq;
using System.Reflection;
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.Support.Util
{
    public class EntitiesUtil
    {
        public static PropertyInfo GetPrimaryKeyPropertyInfo(Type entityType)
        {
            foreach (PropertyInfo prop in entityType.GetProperties())
            {
                if (prop.GetCustomAttributes(false).Count(x => x.GetType() == typeof(PrimaryKeyAttribute)) > 0)
                    return prop;
            }

            return null;
        }
    }
}
