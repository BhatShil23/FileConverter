using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Validator
{
    public enum FileValidationError
    {
        [Description("File not validated.")]
        NotChecked,

        [Description("Valid File.")]
        NoError,

        [Description("Empty file. File name not set.")]
        NameNotSet,

        [Description("File path invalid.")]
        InvalidPath,

        [Description("File extension does not match the expected file type.")]
        IncorrectFileExtension,

        [Description("Directory not found.")]
        DirectoryNotFound,

    }
}
