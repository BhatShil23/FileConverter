using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaterial
{
    public enum OptionType
    {
        Text,
        Image
    }

    public class Question
    {
        public string Description { get; private set; }
        public string Image { get; private set; }
        public OptionType OptionType { get; private set; }
        public string DifficultyLevel { get; private set; }
        public string CategoryId { get; private set; }
        public List<string> OptionList { get; private set; }


        public Question()
        {
            this.Description = string.Empty;
            this.Image = string.Empty;
            this.OptionList = new List<string>();
            this.OptionType = OptionType.Text;
            this.CategoryId = string.Empty;
            this.DifficultyLevel = string.Empty;
        }

        public Question(Question question)
        {
            this.Description = question.Description;
            this.OptionType = question.OptionType;
            this.Image = question.Image;
            this.OptionList = new List<string>();
            this.OptionList.AddRange(question.OptionList);

            this.DifficultyLevel = question.DifficultyLevel;
            this.CategoryId = question.CategoryId;
        }


        public void SetDescription(string description)
        {
            this.Description = description;
        }

        public void SetImage(string image)
        {
            this.Image = image;
        }


        public void SetOptionType(OptionType optionType)
        {
            this.OptionType = optionType;
        }

        public void SetOptionList(List<string> optionList)
        {
            this.OptionList.Clear();
            this.OptionList.AddRange(optionList);
        }

        public void AddOption(string option)
        {
            this.OptionList.Add(option);
        }


        public void SetDifficultyLevel(string difficultyLevel)
        {
            this.DifficultyLevel = difficultyLevel;
        }

        public void SetCategoryId(string categoryId)
        {
            this.CategoryId = categoryId;
        }
    }
}
