using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuduBuddyLibraries.Environment
{
    public static class NamedValue
    {
        public const string LogFile = "TuduBuddyAutomationLog.txt";
        public const string ExcelFileExtension = ".xlsx";
        public const string CsvFileExtensions = ".csv";
        public const string CsvFileDialogFilter = "CSV files|*.csv";
        public const string LineSeparator = "\r\n";

        public static class TestPaperConversion
        {
            public const string RulesConfigFile = @"TestPaperFormattingRules.json";
            public const string AppConfigFile = @"FileConversionConfig.json";
            public const string QuestionText = "QuestionText";
            public const string ImageName = "ImageName";
            public const string Option1 = "Option1";
            public const string Option1ImageName = "Option1ImageName";
            public const string Option2 = "Option2";
            public const string Option2ImageName = "Option2ImageName";
            public const string Option3 = "Option3";
            public const string Option3ImageName = "Option3ImageName";
            public const string Option4 = "Option4";
            public const string Option4ImageName = "Option4ImageName";
            public const string DifficultyLevel = "DifficultyLevel";
            public const string ExamCategory_Id = "ExamCategory_Id";
        }

        public static class PersonalInfoExtractor
        {
            public const string CsvColumnDelimiter = ";";
            public const string PublicDomainConfig = @"PublicDomainConfig.json";
            public const string MailIdentifier = "@";
            public const string Domain = "domain";
            public const string SummaryFileName = "DomainListSummary.txt";
        }
    }
}
