using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace FineOffice.Common.ListHelper
{
    /// <summary>
    /// 集合转换帮助类
    /// </summary>
    public static class ObjectConversion
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element))) { yield return element; }
            }
        }

        /// <summary>
        /// 对象转换
        /// </summary>
        public static R ConvertTo<T, R>(T t)
        {
            R result = default(R);
            result = Activator.CreateInstance<R>();
            PropertyInfo[] resuletProp = result.GetType().GetProperties();

            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyInfo pi in resuletProp)
            {
                foreach (PropertyDescriptor p in properties)
                {
                    if (pi.PropertyType == p.PropertyType && pi.Name == p.Name)
                    {
                        pi.SetValue(result, p.GetValue(t), null);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// list转DataTable
        /// </summary>
        public static DataTable ConvertTo<T>(IList<T> list)
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
        /// List<T>转List<DataRow>
        /// </summary>
        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Table转List
        /// </summary>
        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
                return null;
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }
            return ConvertTo<T>(rows);
        }

        /// <summary>
        /// 行对象转换在泛型对象
        /// </summary>
        public static T CreateItem<T>(DataRow row)
        {
            T result = default(T);
            if (row != null)
            {
                result = Activator.CreateInstance<T>();
                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = result.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        if (prop == null)
                            continue;
                        object value = row[column.ColumnName];
                        if (!value.GetType().ToString().Equals("System.DBNull"))
                        {
                            if (value.GetType().ToString().Equals("System.Decimal"))
                                prop.SetValue(result, Convert.ToDecimal(value.ToString()), null);
                            else
                                prop.SetValue(result, value, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(String.Format("列:{0}转换失败，详细错误{1}", column.ColumnName, ex.Message));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 创建Table对象
        /// </summary>
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

        /// <summary>
        /// 一维数组转为DataTable
        /// </summary>
        public static DataTable ArrayToDataTable(string ColumnName, string[] Array)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(ColumnName, typeof(string));
            for (int i = 0; i < Array.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[ColumnName] = Array[i].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 二维数组转为DataTable
        /// </summary>
        public static DataTable ArrayToDataTable(string[] ColumnNames, string[,] Arrays)
        {
            DataTable dt = new DataTable();

            foreach (string ColumnName in ColumnNames)
            {
                dt.Columns.Add(ColumnName, typeof(string));
            }

            for (int i1 = 0; i1 < Arrays.GetLength(0); i1++)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < ColumnNames.Length; i++)
                {
                    dr[i] = Arrays[i1, i].ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}