using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FileConvertor
{
    public class QuestionPaperParser
    {
        public string TextData { get; private set; }
        public QuestionPaperFormattingRules FormattingRules { get; private set; }
        public QuestionPaper QuestionPaper { get; private set; }

        public QuestionPaperParser(string textData, 
            QuestionPaperFormattingRules rules)
        {
            this.TextData = textData;
            this.FormattingRules = rules;
        }

        public QuestionPaper GetQuestionPaperFromText()
        {
            QuestionPaper questionPaper = null;

            if (!string.IsNullOrEmpty(this.TextData))
            {
                questionPaper = new QuestionPaper();
                List<string> questionList = GetQuestionList();

                foreach (string questionString in questionList)
                {
                    if (!(questionString.Equals("\n")|| 
                        questionString.Equals(string.Empty)))
                    {
                        Question question = new Question();
                        string description = GetQuestionDescription(questionString);
                        question.SetDescription(GetQuestionDescriptionWithoutImage(description));
                        question.SetImage(GetQuestionImage(description));
                        
                        question.SetOptionList(GetOptions(questionString));
                        question.SetOptionType(GetOptionType(questionString));
                        question.SetDifficultyLevel(GetDifficultyLevel(questionString));
                        question.SetCategoryId(GetCategoryId(questionString));

                        questionPaper.AddQuestion(question);
                    }
                }
            }

            return questionPaper;

        }

        private List<string> GetQuestionList()
        {
            List<string> questionList = this.TextData.Split(
                new string[] { FormattingRules.QuestionSeparator },
                StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            return questionList;
        }


        private string GetQuestionDescription(string questionSection)
        {
            string[] questionComponent = questionSection.Split(new string[] {
                FormattingRules.OptionIdentifier },
                StringSplitOptions.RemoveEmptyEntries);

            string questionDescription = questionComponent[0];
            return questionDescription;
        }

        private string GetQuestionDescriptionWithoutImage(string description)
        {
            if (!description.Contains(FormattingRules.ImageIdentifier))
                return description;
            
            int startIndex = description.IndexOf(FormattingRules.ImageIdentifier);
            int endIndex = description.IndexOf(FormattingRules.EndOfImage);
            int count = (endIndex - (startIndex - FormattingRules.EndOfImage.Length));

            if (endIndex == -1)
            {
                endIndex = description.Length - 1;
                count = (endIndex - startIndex);
            }

            string questionDescriptionWithoutImage = description.Remove(startIndex, count);
            return questionDescriptionWithoutImage;
        }

        private string GetQuestionImage(string questionDescription)
        {
            string questionImage = string.Empty;

            if (!questionDescription.Contains(FormattingRules.ImageIdentifier))
                return questionImage;

            int startIndex = questionDescription.IndexOf(FormattingRules.ImageIdentifier);
            startIndex = startIndex + FormattingRules.ImageIdentifier.Length;

            int endIndex = questionDescription.IndexOf(FormattingRules.EndOfImage);

            if (endIndex == -1)
            {
                questionImage = questionDescription.Substring(startIndex);
            }
            else
            {
                
                questionImage = questionDescription.Substring(startIndex, (endIndex - startIndex));
            }

            return questionImage;
        }

        private List<string> GetOptions(string questionSection)
        {
            List<string> optionList = new List<string>();
            try
            {
                string[] questionComponent = questionSection.Split(new string[] {
                FormattingRules.OptionIdentifier },
                  StringSplitOptions.RemoveEmptyEntries);

                string optionComponent = questionComponent[1];
                string[] options = optionComponent.Split(new string[] {
                FormattingRules.OptionSeparator },
                 StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i <= options.Count() - 1; i++)
                {
                    if (options[i].Equals(FormattingRules.ImageIdentifier) ||
                        options[i].Equals(FormattingRules.TextIdentifier))
                        continue;

                    if (options[i].Contains(FormattingRules.ImageIdentifier))
                        options[i] = options[i].Replace(FormattingRules.ImageIdentifier, string.Empty);

                    if (options[i].Contains(FormattingRules.TextIdentifier))
                        options[i] = options[i].Replace(FormattingRules.TextIdentifier, string.Empty);


                    if (options[i].Contains(FormattingRules.EndOfOption))
                    {
                        if (!options[i].Equals(FormattingRules.EndOfOption))
                        {
                            options[i] = options[i].Replace(FormattingRules.EndOfOption, string.Empty);
                            optionList.Add(options[i]);
                        }

                        break;
                    }

                    optionList.Add(options[i]);
                }
            }
            catch
            {
                throw new Exception("Option identifier not found in the question.\n" + questionSection);
            }

            return optionList;
        }

        private OptionType GetOptionType(string questionSection)
        {
            OptionType optionType = OptionType.Text;

            string[] questionComponent = questionSection.Split(new string[] {
                FormattingRules.OptionIdentifier },
               StringSplitOptions.RemoveEmptyEntries);

            string options = questionComponent[1];
            if (options.Contains(FormattingRules.ImageIdentifier))
                optionType = OptionType.Image;

            return optionType;
        }

        private string GetDifficultyLevel(string questionSection)
        {
            string difficultyLevel = string.Empty;
            string[] splitString1 = null;
            string[] splitString2 = null;
            try
            {
                splitString1 = questionSection.Split(
                    new string[] { FormattingRules.EndOfOption },
                    StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                throw new Exception("End of option not found in the question. -\n" + questionSection);
            }

            try
            {
                splitString2 = splitString1[1].Split(
                    new string[] { FormattingRules.OptionSeparator },
                    StringSplitOptions.RemoveEmptyEntries);

                if (!IsEmptyOrWhiteSpace(splitString2[0]))
                {
                    difficultyLevel = splitString2[0];
                }
                else
                {
                    difficultyLevel = splitString2[1];
                }
            }
            catch
            {
                throw new Exception("Difficulty level not found in the question.-\n" + questionSection);
            }

            return difficultyLevel;
        }

        private string GetCategoryId(string questionSection)
        {
            string examCategoryId = string.Empty;
            string[] splitString1 = null;
            try
            {
                splitString1 = questionSection.Split(
                new string[] { FormattingRules.EndOfOption },
                StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                throw new Exception("End of option not found in the question. -\n" + questionSection);
            }
      
            try
            {
                string[] splitString2 = splitString1[1].Split(
                new string[] { FormattingRules.OptionSeparator },
                StringSplitOptions.RemoveEmptyEntries);

                if (!IsEmptyOrWhiteSpace(splitString2[0]))
                {
                    examCategoryId = splitString2[1];
                }
                else
                {
                    examCategoryId = splitString2[2];
                }
            }
            catch
            {
                throw new Exception("Category ID not found in the question.-\n" + questionSection);
            }

            return examCategoryId;
        }

        private static bool IsEmptyOrWhiteSpace(string value) =>
            value.All(char.IsWhiteSpace);
    }
}
