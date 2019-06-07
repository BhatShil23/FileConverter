using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logger;

namespace Validator
{
    public class FileValidator
    {
        public static bool IsFileNameSet(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsFilePathValid(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsFileExtensionValid(string fileName, List<string> fileExtensions)
        {
            string FileExtension = Path.GetExtension(fileName);

            if (fileExtensions.Contains(FileExtension))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static FileValidationError Validate(string fileName, List<string> fileExtensions)
        {
            bool bResult = IsFileNameSet(fileName);
            if(bResult == false)
            {
                return FileValidationError.NameNotSet;
            }

            bResult = IsFilePathValid(fileName);
            if(bResult == false)
            {
                return FileValidationError.InvalidPath;
            }

            if (fileExtensions != null && fileExtensions.Count > 0)
            {
                bResult = IsFileExtensionValid(fileName, fileExtensions);
                if (bResult == false)
                {
                    return FileValidationError.IncorrectFileExtension;
                }
            }

            return FileValidationError.NoError;
        }
    }
}
