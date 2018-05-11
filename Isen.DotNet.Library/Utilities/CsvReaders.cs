using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using CsvHelper;
using System.Linq;

namespace Isen.DotNet.Library.Utilities
{
    public class CsvReaders<T> where T : class
    {
        public static DataTable GetCsvData(string localDestination)
        {
            var dt = new DataTable();
            try{
                if (File.Exists(localDestination))
                {
                    using (StreamReader streamReader = new StreamReader(localDestination))
                    {
                        var reader = new CsvReader(streamReader); 
                        IEnumerable<T> records = reader.GetRecords<T>();
                    }
                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}