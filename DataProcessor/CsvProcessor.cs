using System;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace DataProcessor
{
    public class CsvProcessor
    {
        readonly string lineDelimiter = "\r\n";

        public DataTable GetDataTableFromCsv(string csvFileData, string delimiter)
        {
            string[] dataLines = csvFileData.Split(new string[] { lineDelimiter },
                StringSplitOptions.RemoveEmptyEntries);

            DataTable dt = GetDataTableFromCsv(dataLines, delimiter);
            return dt;
        }

        public DataTable GetDataTableFromCsv(string[] csvDataInput, string delimiter)
        {
            string[] columnNames = csvDataInput[0].Split(new string[] { delimiter },
                StringSplitOptions.None);

            DataTable dt = new DataTable();

            foreach (string col in columnNames)
            {
                dt.Columns.Add(col);
            }

            for(int i=1; i<= csvDataInput.Length-1; i++)
            {
                string[] columns = csvDataInput[i].Split(new string[] { delimiter }, StringSplitOptions.None);
                dt.NewRow();
                dt.Rows.Add(columns);
            }

            return dt;
        }
    }
}
