using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

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

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }

        public static DataTable CreateTable(IList list)
        {
            DataTable table = new DataTable();
            int numberCoumns = list.Cast<Object[]>()
                .Select(x => x.Cast<Object>().Count()).First();
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
    }
}
