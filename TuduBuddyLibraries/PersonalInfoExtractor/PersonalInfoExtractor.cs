using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using DataProcessor;
using System.Linq;
using Validator;
using DataReader;
using DataWriter;
using TuduBuddyLibraries.Environment;
using Common.Logger; 

namespace TuduBuddy.PersonalInfoExtractor
{
    public class PersonalInfoExtractor
    {
        readonly CsvProcessor csvProcessor = new CsvProcessor();
        readonly Logger logger = Logger.GetInstance();

        public List<string> PublicDomainList { get; private set; }
        public string FileName { get; private set; }
        public string OutputFileName { get; private set; }

        readonly private string lineSeparator = NamedValue.LineSeparator;
        readonly private string delimiter = NamedValue.PersonalInfoExtractor.CsvColumnDelimiter;

        public PersonalInfoExtractor(string csvFilePath, List<string> publicDomainList)
        {
            this.FileName = csvFilePath;
            this.PublicDomainList = publicDomainList;
        }

        public DataTable GetPersonalInfoWithPublicDomain()
        {
            DataTable dt = new DataTable();

            logger.AppendLog("Checking file path..");
            if (File.Exists(this.FileName))
            {
                logger.AppendLog("File found.");

                string[] inputData = GetDataFromCsvFile();

                List<string> matchingData = new List<string>();
                logger.AppendLog("Adding column header..");

                matchingData.Add(inputData[0]);
                foreach (string publicDomain in this.PublicDomainList)
                {
                    logger.AppendLog("Scanning for email ids with domain name: " + publicDomain);

                    var filteredData = inputData.Where(r => r.Contains(publicDomain));
                    matchingData.AddRange(filteredData);
                }

                dt = csvProcessor.GetDataTableFromCsv(matchingData.ToArray(), delimiter);
            }
            else
            {
                logger.AppendError("File not found.");
            }

            return dt;
        }

        public string[] GetDataFromCsvFile()
        {
            logger.AppendLog("Reading data from " + this.FileName);
            CsvReader csvReader = new CsvReader(this.FileName);

            FileValidationError validationError = csvReader.ValidateFile();
            if (validationError != FileValidationError.NoError)
            {
                logger.AppendError("CSV file validation error.");
            }

            string fileData = csvReader.ReadData();

            string[] inputData = fileData.Split(new string[] { lineSeparator },
                StringSplitOptions.None);

            return inputData;
        }
    }
}
