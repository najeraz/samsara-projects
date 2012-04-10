
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Samsara.Framework.Util
{
    public class CollectionsUtil
    {
        public static DataTable ConvertToDataTable(IList list)
        {
            try
            {
                DataTable table = CreateTable(list);

                foreach (Object[] objs in list)
                {
                    table.Rows.Add(objs);
                }

                return table;
            }
            catch { }
            return null;
        }

        public static DataTable ConvertToDataTable(IList<object> list, string tableName)
        {
            DataTable table = CreateTable(list, tableName);

            foreach (IDictionary<string, object> tuple in list)
            {
                DataRow row = table.NewRow();

                foreach (KeyValuePair<string, object> cell in tuple)
                {
                    row[cell.Key] = cell.Value ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> list, bool absoluteColumnNames)
        {
            DataTable table = CreateTable<T>(absoluteColumnNames);
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T entity in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor propertyDescriptor in properties)
                {
                    PropertyInfo primaryKeyPropertyInfo = EntitiesUtil.GetPrimaryKeyPropertyInfo(propertyDescriptor.PropertyType);
                    object value = entity.GetType().GetProperty(propertyDescriptor.Name).GetValue(entity, null);

                    if (primaryKeyPropertyInfo != null)
                    {
                        if (value != null)
                        {
                            object primaryKeyValue = value.GetType().GetProperty(primaryKeyPropertyInfo.Name).GetValue(value, null);

                            if (absoluteColumnNames)
                                row[propertyDescriptor.Name + "." + primaryKeyPropertyInfo.Name] = primaryKeyValue;
                            else
                                row[primaryKeyPropertyInfo.Name] = primaryKeyValue;
                        }
                        else
                        {
                            row[primaryKeyPropertyInfo.Name] = DBNull.Value;
                        }
                    }
                    else
                    {
                        row[propertyDescriptor.Name] = propertyDescriptor.GetValue(entity) ?? DBNull.Value;
                    }
                }

                table.Rows.Add(row);
            }

            return table;
        }

        /// <summary>
        /// Crea una Tabla sencilla a partir de la Definición de una Entidad del Framework.
        /// </summary>
        /// <typeparam name="T">Tipo de la Entidad.</typeparam>
        /// <returns>Tabla con un Esquema acorde a <c>T</c>.</returns>
        public static DataTable CreateTable<T>(bool absoluteColumnNames)
        {
            Type entityType = typeof(T);

            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection entityPropertiesCollection = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor entityProperty in entityPropertiesCollection)
            {
                PropertyInfo primaryKeyType = EntitiesUtil.GetPrimaryKeyPropertyInfo(entityProperty.PropertyType);
                if (primaryKeyType != null)
                {
                    if (absoluteColumnNames)
                        table.Columns.Add(entityProperty.Name + "." + primaryKeyType.Name,
                            primaryKeyType.PropertyType);
                    else
                        table.Columns.Add(primaryKeyType.Name, primaryKeyType.PropertyType);
                }
                else if (entityProperty.PropertyType.IsGenericType
                    && entityProperty.PropertyType.GetGenericTypeDefinition()
                        .Equals(typeof(Nullable<>)))
                {
                    table.Columns.Add(entityProperty.Name, Nullable.GetUnderlyingType(entityProperty.PropertyType));
                }
                else
                {
                    table.Columns.Add(entityProperty.Name, entityProperty.PropertyType);
                }
            }

            return table;
        }

        public static DataTable CreateTable(IList<object> list, string tableName)
        {
            DataTable table = new DataTable(tableName);
            IDictionary<string, object> dictionary = (IDictionary<string, object>) list.First();

            foreach (KeyValuePair<string, object> pair in dictionary)
            {
                table.Columns.Add(pair.Key, GetTypeFromNativeSQLResultColletion(list, pair.Key));
            }

            return table;
        }

        private static Type GetTypeFromNativeSQLResultColletion(IList<object> list, string columnName)
        {
            KeyValuePair<string, object> valuePair = list.Cast<IDictionary<string, object>>()
                .SelectMany(x => x.Where(y => y.Key == columnName)).FirstOrDefault(x => x.Value != null);

            object value = valuePair.Value;

            return value != null ? value.GetType() : typeof(string);
        }

        public static DataTable CreateTable(IList list)
        {
            DataTable table = new DataTable();
            int numberCoumns = list.Cast<Object[]>().Select(x => x.Cast<Object>().Count()).First();
            int i = 0;

            for (i = 0; i < numberCoumns; i++)
            {
                Object objTemplate = null;

                foreach (var array in list.Cast<Object[]>())
                {
                    if (array[i] != null)
                    {
                        objTemplate = array[i];
                        break;
                    }
                    if (objTemplate != null) break;
                }

                table.Columns.Add(null, objTemplate == null ? typeof(string)
                    : objTemplate.GetType());
            }

            return table;
        }

        //TODO: Verificar si funciona y es viable.
        DataSet SerializedDataSet(IList list)
        {
            Object dataArray = list.Cast<Object[]>().ToArray();
            XmlSerializer serializer = new XmlSerializer(dataArray.GetType());
            StringWriter sw = new StringWriter();
            serializer.Serialize(sw, dataArray);

            DataSet ds = new DataSet();
            StringReader reader = new StringReader(sw.ToString());
            ds.ReadXml(reader);
            return ds;
        }
    }
}
