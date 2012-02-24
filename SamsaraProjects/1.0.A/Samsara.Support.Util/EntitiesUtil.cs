﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Samsara.Base.Core.Attributes;

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
        private static PropertyInfo[] GetPropertiesWithSpecificAttribute(Type classType
            , Type attributeType)
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
    }
}
