using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;

namespace SampleService.Common.Concrete
{
    public class CustomHelper
    {
        public bool UpdateZipUsingMemoryStream(ZipFile zipFile, string fileName, MemoryStream memoryStream)
        {
            CustomStaticDataSource ds = new();
            zipFile.BeginUpdate();
            ds.SetStream(memoryStream);
            zipFile.Add(ds, fileName);
            zipFile.CommitUpdate();
            return true;
        }

        public DataTable RemoveEmptyRowsFromDataTable(DataTable dt)
        {
            var rows = dt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull || string.Compare(field.ToString()?.Trim(), string.Empty) == 0));
            if (rows.Any()) { return rows.CopyToDataTable(); }
            return dt.Clone();
        }

        public List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private T GetItem<T>(DataRow row)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in row.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.Equals(column.ColumnName.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            var value = row[column.ColumnName] == DBNull.Value ? null : row[column.ColumnName];
                            pro.SetValue(obj, value, null);
                        }
                        catch
                        {
                            var value = row[column.ColumnName] == DBNull.Value ? null : Convert.ToString(row[column.ColumnName]);
                            pro.SetValue(obj, value, null);
                        }
                    }
                }
            }
            return obj;
        }
    }

    public class CustomStaticDataSource : IStaticDataSource
    {
        private Stream _stream;

        public Stream GetSource() { return _stream; }

        public void SetStream(Stream inputStream)
        {
            _stream = inputStream;
            _stream.Position = 0;
        }
    }
}
