﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
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

            return entityType.GetProperty(primaryKeyPropertyInfo.Name).GetValue(entity, null);
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

        public static void ProcessAuditProperties(object entity, DateTime dtNow)
        {
            Type entityType = entity.GetType();

            int primaryKeyValue = Convert.ToInt32(EntitiesUtil.GetPrimaryKeyPropertyValue(entityType, entity));

            if (entity.GetType().IsSubclassOf(typeof(GenericEntity)))
            {
                ISession session = SamsaraAppContext.Resolve<ISession>();
                Assert.IsNotNull(session);

                if (primaryKeyValue <= 0)
                {
                    if ((entity as GenericEntity).Activated == null)
                    {
                        (entity as GenericEntity).Activated = true;
                    }
                    if ((entity as GenericEntity).Deleted == null)
                    {
                        (entity as GenericEntity).Deleted = false;
                    }
                    (entity as GenericEntity).CreatedBy = session.UserId;
                    (entity as GenericEntity).CreatedOn = dtNow;
                }
                else
                {
                    (entity as GenericEntity).UpdatedBy = session.UserId;
                    (entity as GenericEntity).UpdatedOn = dtNow;
                }
            }

            foreach (PropertyInfo propertyInfo in
                EntitiesUtil.GetPropertiesWithSpecificAttribute(entityType, typeof(PropagationAudit)))
            {
                object value = entity.GetType().GetProperty(propertyInfo.Name).GetValue(entity, null);

                if (value != null && value.GetType().IsSubclassOf(typeof(GenericEntity)))
                {
                    ProcessAuditProperties(value, dtNow);
                }

                if (value.GetType().GetInterface(typeof(IEnumerable).FullName) != null)
                {
                    foreach (object item in (value as IEnumerable))
                    {
                        if (item != null && item.GetType().IsSubclassOf(typeof(GenericEntity)))
                        {
                            ProcessAuditProperties(item, dtNow);
                        }
                    }
                }
            }
        }
    }
}
