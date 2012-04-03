
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Context;
using Samsara.Base.Core.Entities;
using Samsara.Base.Core.Interfaces;

namespace Samsara.Support.Util
{
    /// <summary>
    /// Auxiliares para Entidades del Framework.
    /// </summary>
    public class EntitiesUtil
    {
        /// <summary>
        /// Indica si <c>propDescriptor</c> viene marcado como Llave Primaria.
        /// </summary>
        /// <param name="propDescriptor">Descriptor a evaluar.</param>
        /// <returns>Indica si pertenece a la Llave Primaria.</returns>
        public static bool IsPrimaryKeyProperty(PropertyDescriptor propDescriptor)
        {
            return propDescriptor.Attributes.OfType<PrimaryKey>().Count() > 0;
        }

        /// <summary>
        /// Obtiene las Propiedades de la Entidad que son consideradas para formar la Llave
        /// Primaria.
        /// </summary>
        /// <param name="entityType">Tipo de la Entidad.</param>
        /// <returns>Propiedades para Llave Primaria.</returns>
        public static PropertyInfo[] GetPrimaryKeyProperties(Type entityType)
        {
            return EntitiesUtil.GetPropertiesWithSpecificAttribute(entityType, typeof(PrimaryKey));
        }

        /// <summary>
        /// Indica si <c>type</c> está marcado con el Atributo especificado por
        /// <c>attributeType</c>.
        /// </summary>
        /// <param name="type">Tipo a evaluar.</param>
        /// <param name="attributeType">Tipo del Atributo a considerar.</param>
        /// <returns>Indica si tiene el Atributo.</returns>
        private static bool TypeHasAttribute(Type type, Type attributeType)
        {
            return type.GetCustomAttributes(attributeType, false).Length > 0;
        }

        /// <summary>
        /// Obtiene las Propiedades definidas por una Clase marcadas con determinado Atributo.
        /// </summary>
        /// <param name="classType">Tipo de la Clase.</param>
        /// <param name="attributeType">Tipo del Atributo a buscar.</param>
        /// <returns>Propiedades que cumplen con el Atributo.</returns>
        public static PropertyInfo[] GetPropertiesWithSpecificAttribute(Type classType, Type attributeType)
        {
            return classType.GetProperties()
                .Where(property => property.GetCustomAttributes(attributeType, false).Length > 0)
                .ToArray();
        }

        public static PropertyInfo GetPrimaryKeyPropertyInfo(Type entityType)
        {
            foreach (PropertyInfo prop in entityType.GetProperties())
            {
                if (prop.GetCustomAttributes(false).Count(x => x.GetType() == typeof(PrimaryKey)) > 0)
                    return prop;
            }

            return null;
        }

        public static object GetPrimaryKeyPropertyValue(Type entityType, object entity)
        {
            if (entity == null)
                return null;

            PropertyInfo primaryKeyPropertyInfo = GetPrimaryKeyPropertyInfo(entityType);

            return primaryKeyPropertyInfo == null ? null : entityType.GetProperty(primaryKeyPropertyInfo.Name).GetValue(entity, null);
        }

        public static object GetPrimaryKeyPropertyValue<T>(object entity)
        {
            Type entityType = typeof(T);

            if (entity == null)
                return null;

            PropertyInfo primaryKeyPropertyInfo = GetPrimaryKeyPropertyInfo(entityType);

            return entityType.GetProperty(primaryKeyPropertyInfo.Name).GetValue(entity, null);
        }

        public static IList<object> GetPrimaryKeyPropertyValues<T>(IList<T> entityList)
        {
            Type entityType = typeof(T);
            IList<object> resultList = new List<object>();

            foreach (T entity in entityList)
            {
                if (entity == null)
                    continue;

                PropertyInfo primaryKeyPropertyInfo = GetPrimaryKeyPropertyInfo(entityType);
                
                resultList.Add(entityType.GetProperty(primaryKeyPropertyInfo.Name).GetValue(entity, null));
            }

            return resultList;
        }

        public static void SetAsDeleted(BaseEntity entity)
        {
            entity.Activated = false;
            entity.Deleted = true;
        }

        public static void ProcessAuditProperties(object entity, DateTime dtNow, IDictionary<int, string> auditedObjects, NHibernate.ISession nHibernateSession)
        {
            Type entityType = null;

            try
            {
                object unProxiedEntity = nHibernateSession.GetSessionImplementation().PersistenceContext.Unproxy(entity);
                entityType = unProxiedEntity.GetType();
            }
            catch
            {
                //Es un proxy que no pudo ser inicializado...
                return;
            }

            if (auditedObjects == null)
            {
                auditedObjects = new Dictionary<int, string>();
            }

            if (auditedObjects.ContainsKey(entity.GetHashCode()))
            {
                return;
            }

            Nullable<int> primaryKeyValue = (Nullable<int>) GetPrimaryKeyPropertyValue(entityType, entity);

            if (entityType.IsSubclassOf(typeof(BaseEntity)))
            {
                auditedObjects.Add(entity.GetHashCode(), entityType.Name);

                ISession session = SamsaraAppContext.Resolve<ISession>();

                if ((entity as BaseEntity).Activated == null)
                {
                    (entity as BaseEntity).Activated = true;
                }
                if ((entity as BaseEntity).Deleted == null)
                {
                    (entity as BaseEntity).Deleted = false;
                }

                if (primaryKeyValue <= 0)
                {
                    (entity as BaseEntity).CreatedBy = session.UserId;
                    (entity as BaseEntity).CreatedOn = dtNow;
                }
                else
                {
                    (entity as BaseEntity).UpdatedBy = session.UserId;
                    (entity as BaseEntity).UpdatedOn = dtNow;
                }
            }

            foreach (PropertyInfo propertyInfo in entityType.GetProperties())
            {
                object value = entityType.GetProperty(propertyInfo.Name).GetValue(entity, null);

                if (value != null && value.GetType().IsSubclassOf(typeof(BaseEntity)))
                {
                    ProcessAuditProperties(value, dtNow, auditedObjects, nHibernateSession);
                }

                if (value != null && value.GetType().GetInterface(typeof(IEnumerable).FullName) != null)
                {
                    foreach (object item in (value as IEnumerable))
                    {
                        if (item != null && item.GetType().IsSubclassOf(typeof(BaseEntity)))
                        {
                            ProcessAuditProperties(item, dtNow, auditedObjects, nHibernateSession);
                        }
                    }
                }
            }
        }
    }
}
