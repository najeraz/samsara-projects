
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Samsara.ProjectsAndTendering.Core.Entities;
using System.Reflection;

namespace Samsara.Support.Util
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
                    int i = 0;
                    DataRow row = table.NewRow();

                    foreach (Object obj in objs)
                    {
                        row[i++] = obj == null ? DBNull.Value : obj;
                    }

                    table.Rows.Add(row);
                }

                return table;
            }
            catch (Exception ex) { ex.ToString(); }
            return null;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
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
        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            //System.Diagnostics.Contracts.Contract // Y si la herencia es por medio de una tercera clase base???
            //    .Assert(entityType.IsSubclassOf(typeof(GenericEntity)));

            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection entityPropertiesCollection
                = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor entityProperty in entityPropertiesCollection)
            {
                PropertyInfo primaryKeyType = EntitiesUtil.GetPrimaryKeyPropertyInfo(entityProperty.PropertyType);
                if (primaryKeyType != null)
                {
                    table.Columns.Add(primaryKeyType.Name, primaryKeyType.PropertyType);
                }
                else if (entityProperty.PropertyType.IsGenericType
                    && entityProperty.PropertyType.GetGenericTypeDefinition()
                        .Equals(typeof(Nullable<>)))
                {
                    table.Columns.Add(entityProperty.Name
                        , Nullable.GetUnderlyingType(entityProperty.PropertyType));
                }
                else
                {
                    table.Columns.Add(entityProperty.Name, entityProperty.PropertyType);
                }
            }

            return table;
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
