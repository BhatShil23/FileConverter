using System;
using System.IO;
using System.Data;
using Common.Logger;
using Validator;
using Common.Util;
using DataWriter;

namespace TuduBuddyLibraries.Environment
{
    public class ApplicationEnvironment
    {
        readonly Logger logger = Logger.GetInstance();

        public string CreateOutputDirectory(string inputDirectory)
        {
            string outputDirectory = inputDirectory + @"\output";
            if (!Directory.Exists(outputDirectory))
            {
                logger.AppendLog("Creating output directory. " + outputDirectory);
                Directory.CreateDirectory(outputDirectory);
            }

            return outputDirectory;
        }

        public void InitLogFile(string outputDir)
        {
            string logFile = outputDir + @"\" + NamedValue.LogFile;
            logger.FileName = logFile;
        }

        public string GetOutputFileName(string inputFile, string outputDirectory, string fileExtension)
        {
            string outputFile = outputDirectory + @"\" +
                Path.GetFileNameWithoutExtension(inputFile) + fileExtension;

            return outputFile;
        }

        public bool ValidateDirectory(string dirPath)
        {
            if ((!Directory.Exists(dirPath)) || string.IsNullOrEmpty(dirPath))
                throw new ApplicationException(
                    FileValidationError.DirectoryNotFound.ToString() + "-" + dirPath);

            return true;
        }

        public void SaveLogToFile()
        {
            SaveDataToTextFile(logger.FileName, logger.GetLog());
        }

        public void SaveDataToTextFile(string inputFilePath, string fileData)
        {
            if (!CommonUtil.IsEmptyOrWhiteSpace(logger.FileName))
            {
                if (!File.Exists(inputFilePath))
                {
                    File.Create(inputFilePath).Close();
                }

                File.WriteAllText(inputFilePath, fileData);
            }
        }

        public void SaveDataToTextFile(string inputFilePath, string[] fileData)
        {
            if (!CommonUtil.IsEmptyOrWhiteSpace(logger.FileName))
            {
                if (!File.Exists(inputFilePath))
                {
                    File.Create(inputFilePath).Close();
                }

                File.WriteAllLines(inputFilePath, fileData);
            }
        }

        public void SaveDataToFile(string inputPath, DataTable dt)
        {
            string inputDir = Path.GetDirectoryName(inputPath);
            string outputDir = CreateOutputDirectory(inputDir);

            string outputFileName = GetOutputFileName(inputPath, outputDir, NamedValue.ExcelFileExtension);

            ExcelWriter excelWriter = new ExcelWriter(outputFileName);
            excelWriter.WriteData(dt);
        }
    }
}
