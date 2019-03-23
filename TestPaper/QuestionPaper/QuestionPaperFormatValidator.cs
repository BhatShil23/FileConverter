using System;
using System.Collections.Generic;
using Common.Util;
using Common.Logger;

namespace TestMaterial
{
    public class QuestionPaperFormatValidator
    {
        private QuestionPaperParser paperParser = null;
        Logger logger = Logger.GetInstance();

        public string TextData { get; private set; }
        public QuestionPaperFormattingRules FormattingRules { get; private set; }

        public QuestionPaperFormatValidator(string fileData,
            QuestionPaperFormattingRules rules)
        {
            this.TextData = fileData;
            this.FormattingRules = rules;

            paperParser = new QuestionPaperParser(this.TextData, this.FormattingRules);
        }

        public List<FileFormattingError> Validate()
        {
            List<FileFormattingError> fileFormatErrorList = new List<FileFormattingError>();
            
            if (!string.IsNullOrEmpty(this.TextData))
            {
                List<string> questionList = paperParser.GetQuestionList();
                
                for(int i = 0; i<= questionList.Count -1; i++)
                {
                    logger.AppendLog("Question - " + (i + 1));
                    if (!(questionList[i].Equals("\n") ||
                            questionList[i].Equals(string.Empty)))
                    {
                        List<string> formatErrorList = new List<string>();

                        FormatError  formatError = ValidateOptionStartTag(questionList[i]);
                        if (formatError != FormatError.None)
                            formatErrorList.Add(formatError.ToString());

                       formatError = ValidateOptionEnd(questionList[i]);
                        if (formatError != FormatError.None)
                            formatErrorList.Add(formatError.ToString());

                        formatError = ValidateQuestionAttributes(questionList[i]);
                        if (formatError != FormatError.None)
                            formatErrorList.Add(formatError.ToString());

                        if (formatErrorList.Count > 0)
                        {
                            fileFormatErrorList.Add(new FileFormattingError(i, formatErrorList));
                        }
                        else
                        {
                            logger.AppendLog("Correct format");
                        }

                        logger.AppendLog(string.Empty);
                    }
                }
            }
            else
            {
                throw new Exception("Empty file.");  
            }

            return fileFormatErrorList;
        }


        private FormatError ValidateOptionStartTag(string question)
        {
            int firstOccurenceIndex = question.IndexOf(this.FormattingRules.OptionIdentifier);
            if (firstOccurenceIndex == -1)
            {
                logger.AppendError(FormatError.OptionStartTagMissing.ToString());
                return FormatError.OptionStartTagMissing;
            }

            int lastOccuranceIndex = question.IndexOf(this.FormattingRules.OptionIdentifier, firstOccurenceIndex+1);
            if (lastOccuranceIndex != -1)
            {
                logger.AppendError(FormatError.MultipleOptionStartTagFound.ToString());
                return FormatError.MultipleOptionStartTagFound;
            }

            return FormatError.None;
        }

        private FormatError ValidateOptionEnd(string question)
        {
            int firstOccurenceIndex = question.IndexOf(this.FormattingRules.EndOfOption);
            if (firstOccurenceIndex == -1)
            {
                logger.AppendError(FormatError.OptionEndTagMissing.ToString());
                return FormatError.OptionEndTagMissing;
            }

            int lastOccuranceIndex = question.IndexOf(this.FormattingRules.EndOfOption, firstOccurenceIndex + 1);
            if (lastOccuranceIndex  != -1)
            {
                logger.AppendError(FormatError.MultipleOptionEndTagFound.ToString());
                return FormatError.MultipleOptionEndTagFound;
            }

            return FormatError.None;
        }

        private FormatError ValidateQuestionAttributes(string question)
        {
            string[] attributes = null;

            try
            {
                attributes = question.Split(
                new string[] { FormattingRules.EndOfOption },
                StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                return FormatError.OptionEndTagMissing;
            }

            if (attributes.Length == 1)
            {
                logger.AppendError(FormatError.AttrbsMissing.ToString());
                return FormatError.AttrbsMissing;
            }

            if (attributes.Length > 1 && CommonUtil.IsEmptyOrWhiteSpace(attributes[1]))
            {
                logger.AppendError(FormatError.AttribFormatError.ToString());
                return FormatError.AttribFormatError;
            }

            string[] attributeOption = attributes[1].Split(
            new string[] { FormattingRules.OptionSeparator },
            StringSplitOptions.RemoveEmptyEntries);

            if (attributeOption.Length == 1)
            {
                if (CommonUtil.IsEmptyOrWhiteSpace(attributeOption[0]))
                {
                    logger.AppendError(FormatError.DifficultyLevelMissing.ToString());
                    return FormatError.DifficultyLevelMissing;
                }
                else
                {
                    logger.AppendError(FormatError.CategoryIdMissing.ToString());
                    return FormatError.CategoryIdMissing;
                }
            }

            if(attributeOption.Length > 2)
            {
                return FormatError.AttribFormatError;
            }

            return FormatError.None;
        }
    }
}
