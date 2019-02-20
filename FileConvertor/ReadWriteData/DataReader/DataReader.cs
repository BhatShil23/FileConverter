using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonUtil;

namespace DataReaderWriter
{
    public interface IDataReader
    {
        FileValidationError ValidateFile();
        string ReadData();
    }
}
