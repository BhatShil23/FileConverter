using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaterial
{
    public class QuestionPaper
    {
        public string Name { get; set; }
        public List<Question> QuestionList { get; set; }

        public QuestionPaper()
        {
            Name = string.Empty;
            QuestionList = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            this.QuestionList.Add(new Question(question));
        }
    }
}
