using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Common.Logger;
using Validator;

namespace DataReader
{
    public class CsvReader : IDataReader
    {
        public string FileName { get; private set; }

        public CsvReader(string fullFileName)
        {
            this.FileName = fullFileName;
        }

        public FileValidationError ValidateFile()
        {
            FileValidationError error = FileValidator.Validate(this.FileName,
                new List<string>() { ".csv" });

            return error;
        }

        public string ReadData()
        {
            string fileData = File.ReadAllText(this.FileName);
            return fileData;
        }
    }
}
