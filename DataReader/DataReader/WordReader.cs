using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using NPOI.XWPF.UserModel;
using NPOI.XWPF.Extractor;
using Validator;
using Common.Logger;

namespace DataReader
{
    public class WordReader : IDataReader
    {
        private static List<string> SupportedWordFileExtension = null;
        public string FileName { get; private set; }

        Logger logger = Logger.GetInstance();
        
        public WordReader(string fullFileName)
        {
            this.FileName = fullFileName;
            SupportedWordFileExtension = new List<string>() { ".doc", ".docx" };
        }

        private void InitialiseSupportedExtension()
        {
           
        }

        public string ReadData()
        {
            string fileData = string.Empty;

            logger.AppendLog("Validating file extension..");

            if (ValidateFile() != FileValidationError.NoError)
            {
                logger.AppendError("Incorrect file extension.");
                return fileData;
            }

            logger.AppendLog("Valid file extension.");
            logger.AppendLog("Reading file...");

            try
            {
                using (FileStream fs = new FileStream(this.FileName,
                    FileMode.Open, FileAccess.Read))
                {
                    XWPFDocument doc = new XWPFDocument(fs);
                    XWPFWordExtractor docExtractor = new XWPFWordExtractor(doc);
                    fileData = docExtractor.Text;
                }

                logger.AppendLog("File read successfully.");
            }
            catch(Exception ex)
            {
                string errorMsg = "Error reading word file. Aborting read operation.";
                logger.AppendError(errorMsg);
                throw new Exception(errorMsg + ex.Message);
            }

            return fileData;
        }

        public FileValidationError ValidateFile()
        {
            FileValidationError error = FileValidator.Validate(this.FileName, 
                SupportedWordFileExtension);

            return error;
        }
    }
}
