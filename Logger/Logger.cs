using System;
using System.Text;

namespace Common.Logger
{
    public class Logger
    {
        readonly private static StringBuilder logData = new StringBuilder();
        private static Logger logger = null;
        public string FileName = string.Empty;

        private Logger()
        {
            InitLoggingInfo();
        }

        public void InitLoggingInfo()
        {
            AppendLog(DateTime.Now.ToLongDateString());
            AppendLog(DateTime.Now.ToLongTimeString());
            AppendLog(Environment.UserName);
            AppendLog(string.Empty);
        }

        public static Logger GetInstance()
        {
            if (logger == null)
                logger = new Logger();

            return logger;
        }

        public void AppendLog(string data)
        {
            logData.Append(data);
            logData.Append("\n");
        }

        public void AppendError(string data)
        {
            logData.Append("Error: "+data);
            logData.Append("\n");
        }

        public string GetLog()
        {
            return logData.ToString();
        }

        public void Clear()
        {
            logData.Clear();
        }
    }
}
