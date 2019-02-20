using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using NPOI.XWPF.UserModel;
using NPOI.XWPF.Extractor;
using CommonUtil;
using FileUtil;

namespace DataReaderWriter
{
    public class WordReader : IDataReader
    {
        private static List<string> SupportedWordFileExtension = null;

        public string FileName { get; private set; }
        

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

            if (ValidateFile() != FileValidationError.NoError)
                return fileData;

            using (FileStream fs = new FileStream(this.FileName,
                FileMode.Open, FileAccess.Read))
            {
                XWPFDocument doc = new XWPFDocument(fs);
                XWPFWordExtractor docExtractor = new XWPFWordExtractor(doc);
                fileData = docExtractor.Text;

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
