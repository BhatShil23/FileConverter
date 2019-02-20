using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonUtil;

namespace FileUtil
{
    public class FileValidator
    {
        public static bool IsFileNameSet(string fileName)
        {
            bool bResult = false;

            if (string.IsNullOrEmpty(fileName))
            {
                bResult = false;
            }
            else
            {
                bResult = true;
            }

            return bResult;
        }

        public static bool IsFilePathValid(string filePath)
        {
            bool bResult = false;

            if (File.Exists(filePath))
            {
                bResult = true;
            }
            else
            {
                bResult = false;
            }

            return bResult;
        }

        public static bool IsFileExtensionValid(string fileName, List<string> fileExtensions)
        {
            bool bResult = false;

            string FileExtension = Path.GetExtension(fileName);

            if (fileExtensions.Contains(FileExtension))
            {
                bResult = true;
            }
            else
            {
                bResult = false;
            }

            return bResult;
        }

        public static FileValidationError Validate(string fileName, List<string> fileExtensions)
        {
            FileValidationError errorMessage = FileValidationError.NotChecked;

            bool bResult = IsFileNameSet(fileName);
            if(bResult == false)
            {
                errorMessage = FileValidationError.NameNotSet;
                return errorMessage;
            }

            bResult = IsFilePathValid(fileName);
            if(bResult == false)
            {
                errorMessage = FileValidationError.InvalidPath;
                return errorMessage;
            }

            if (fileExtensions != null && fileExtensions.Count > 0)
            {
                bResult = IsFileExtensionValid(fileName, fileExtensions);
                if (bResult == false)
                {
                    errorMessage = FileValidationError.IncorrectFileExtension;
                    return errorMessage;
                }
            }

            errorMessage = FileValidationError.NoError;
            return errorMessage = FileValidationError.NoError;
        }
    }
}
