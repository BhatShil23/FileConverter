using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using DataReader;
using DataWriter;
using Validator;
using Common.Logger;

namespace TestMaterial
{
    public class TestFileConvertor
    {
        private Config config = null;
        Logger logger = Logger.GetInstance();

        public TestFileConvertor(Config config)
        {
            this.config = config;
        }

        public void Convert()
        {
            if(config.FileConversionOption == FileConversionOption.Single)
            {
                logger.AppendLog("Checking file path...");
                if (!File.Exists(config.Input))
                {
                    logger.AppendError("File not found.");
                    throw new FileNotFoundException();
                }

                logger.AppendLog("File found.");

                string outputDir = CreateOutputDirectory(Path.GetDirectoryName(config.Input));
                InitLogFile(outputDir);
                string outputFile = GetOutputFileName(config.Input, outputDir);

                if(File.Exists(outputFile))
                {
                    if (config.OverwriteOutputFile == FileOverWriteFlag.no)
                    {
                        logger.AppendLog("Output file exists. Overwriting file is unselected.");
                        logger.AppendLog("Skipping file conversion.");
                        return;
                    }   
                }

                ConvertFile(config.Input, outputFile);                
            }
            else if(config.FileConversionOption == FileConversionOption.Multiple)
            {
                logger.AppendLog("Checking input directory path...");
                bool bResult = ValidateDirectory(config.Input);
                logger.AppendLog("Input directory found.");

                if (bResult)
                {
                    string outputDir = CreateOutputDirectory(config.Input);
                    InitLogFile(outputDir);

                    logger.AppendLog("Selected input folder -" + config.Input);
                    logger.AppendLog("Looking for word documents in the selected folder...");
                    logger.AppendLog(string.Empty);
                    string[] files = Directory.GetFiles(config.Input, "*.docx");
                    if(files.Length == 0)
                    {
                        string errorMsg = "No matching files found. "+
                            "Please ensure input file is available for conversion.";

                        logger.AppendError(errorMsg);
                        throw new Exception(errorMsg);
                    }

                    foreach (string file in files)
                    {
                        logger.AppendLog("FIle: "+file);
                        string outputFile = GetOutputFileName(file, outputDir);

                        if(config.OverwriteOutputFile == FileOverWriteFlag.no && File.Exists(outputFile))
                        {
                            logger.AppendLog("Output file exists. Overwriting file is unselected.");
                            logger.AppendLog("Skipping file conversion.");
                            logger.AppendLog(outputFile);
                        }
                        else
                        {
                            ConvertFile(file, outputFile);
                            logger.AppendLog("***************************************");
                            logger.AppendLog(string.Empty);
                        }
                    }
                }
            }
            else
            {
                string errorMsg = "Incorrect File Conversion option selected." +
                    " File conversion option should be Single or Multiple.";
                logger.AppendLog(errorMsg);
                throw new Exception(errorMsg);
            }

            logger.AppendLog(string.Empty);
        }


        private void ConvertFile(string inputFile, string outputFile)
        {
            string fileName = Path.GetFileName(inputFile);
            string fileData = string.Empty;

            WordReader wordReader = new WordReader(inputFile);
            fileData = wordReader.ReadData();

            if (string.IsNullOrWhiteSpace(fileData))
            {
                logger.AppendLog("Blank file.");
                logger.AppendError("Aborting file conversion. Please ensure file contains appropriate data.");
                return;
            }

            logger.AppendLog("Getting formatting rules from config file...");

            QuestionPaperFormattingRules formattingRules;
            try
            {
                using (StreamReader r = new StreamReader(NamedValue.RulesConfigFile))
                {
                    string json = r.ReadToEnd();
                    formattingRules = JsonConvert.DeserializeObject<QuestionPaperFormattingRules>(json);
                }

                logger.AppendLog("Formatting rules successully retrieved.");
            }
            catch
            {
                string errorMessage = "Error reading Rules.json file."+
                    " Ensure file is present and correct options are chosen.";
                logger.AppendError(errorMessage);
                throw new Exception(errorMessage);
            }

            logger.AppendLog(string.Empty);
            logger.AppendLog("Validating file format...");
            QuestionPaperFormatValidator formatValidator = new QuestionPaperFormatValidator(
                fileData, formattingRules);
            List<FileFormattingError> errorList = formatValidator.Validate();

            logger.AppendLog(string.Empty);
            logger.AppendLog("Validated file format.");
            if (errorList.Count() == 0)
            {
                logger.AppendLog("No errors found.");
                logger.AppendLog(string.Empty);
                logger.AppendLog("Beginning file conversion...");
                logger.AppendLog("Processing file...");
                QuestionPaperParser questionPaperParser = new QuestionPaperParser(fileData, formattingRules);
                QuestionPaper questionPaper = questionPaperParser.GetQuestionPaperFromText();
                questionPaper.Name = fileName;

                QuestionPaperTable testDt = new QuestionPaperTable(questionPaper);
                DataTable dataTable = testDt.GetDataTable();

                logger.AppendLog("Writing data to excel file...");
                ExcelWriter dataWriter = new ExcelWriter(outputFile);
                dataWriter.WriteData(dataTable);

                logger.AppendLog("Output file generated.");
                logger.AppendLog("outputFile: "+outputFile);
                logger.AppendLog("File conversion successful.");
            }
            else
            {
                logger.AppendError("Format error.");
                logger.AppendLog(string.Empty);
                logger.AppendLog("Error summary...");
                logger.AppendLog("------------------------------");
                          
                foreach (FileFormattingError error in errorList)
                {
                    logger.AppendLog("Question " + (error.questionNumber+1).ToString());
                    foreach(string errorMessage in error.ErrorMessage)
                    {
                        logger.AppendLog(errorMessage.ToString());
                    }

                    logger.AppendLog(string.Empty);
                }

                logger.AppendError("File conversion failed. Correct the format and try again.");
            }
        }



        private bool ValidateDirectory(string dirPath)
        {
            if ((!Directory.Exists(dirPath)) || string.IsNullOrEmpty(dirPath))
                throw new ApplicationException(
                    FileValidationError.DirectoryNotFound.ToString() + "-" + dirPath);

            return true;
        }

        private string CreateOutputDirectory(string inputDirectory)
        {
            string outputDirectory = inputDirectory + @"\output";
            if (!Directory.Exists(outputDirectory))
            {
                logger.AppendLog("Creating output directory. " + outputDirectory);
                Directory.CreateDirectory(outputDirectory);
            }

            return outputDirectory;
        }

        private void InitLogFile(string outputDir)
        {
            string logFile = outputDir + @"\" + NamedValue.ConversionLogFile;
            logger.FileName = logFile;
        }

        private string GetOutputFileName(string inputFile, string outputDirectory)
        {
            string outputFile = outputDirectory + @"\" +
                Path.GetFileNameWithoutExtension(inputFile) + ".xlsx";

            return outputFile;
        }
    }
}
