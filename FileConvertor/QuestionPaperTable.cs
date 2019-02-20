using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileConvertor
{
    public class QuestionPaperTable
    {
        DataTable dataTable = null;
        private QuestionPaper questionPaper = null;

        public QuestionPaperTable(QuestionPaper questionPaper)
        {
            dataTable = new DataTable();
            this.questionPaper = questionPaper;
        }

        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(NamedValue.QuestionText);
            dt.Columns.Add(NamedValue.ImageName);
            dt.Columns.Add(NamedValue.Option1);
            dt.Columns.Add(NamedValue.Option1ImageName);
            dt.Columns.Add(NamedValue.Option2);
            dt.Columns.Add(NamedValue.Option2ImageName);
            dt.Columns.Add(NamedValue.Option3);
            dt.Columns.Add(NamedValue.Option3ImageName);
            dt.Columns.Add(NamedValue.Option4);
            dt.Columns.Add(NamedValue.Option4ImageName);
            dt.Columns.Add(NamedValue.DifficultyLevel);
            dt.Columns.Add(NamedValue.ExamCategory_Id);

            foreach(Question question in questionPaper.QuestionList)
            {
                DataRow drow = dt.NewRow();
                drow[NamedValue.QuestionText] = question.Description;
                drow[NamedValue.ImageName] = question.Image;
                
                if(question.OptionType == OptionType.Image)
                {
                    drow[NamedValue.Option1ImageName] = question.OptionList[0];

                    if (question.OptionList.Count == 2)
                    {
                        drow[NamedValue.Option2ImageName] = question.OptionList[1];
                        drow[NamedValue.Option3ImageName] = string.Empty;
                        drow[NamedValue.Option4ImageName] = string.Empty;
                    }

                    if (question.OptionList.Count == 3)
                    {
                        drow[NamedValue.Option2ImageName] = question.OptionList[1];
                        drow[NamedValue.Option3ImageName] = question.OptionList[2];
                        drow[NamedValue.Option4ImageName] = string.Empty;
                    }

                    if (question.OptionList.Count == 4)
                    {
                        drow[NamedValue.Option2ImageName] = question.OptionList[1];
                        drow[NamedValue.Option3ImageName] = question.OptionList[2];
                        drow[NamedValue.Option4ImageName] = question.OptionList[3];
                    }

                    drow[NamedValue.Option1] = string.Empty;
                    drow[NamedValue.Option2] = string.Empty;
                    drow[NamedValue.Option3] = string.Empty;
                    drow[NamedValue.Option4] = string.Empty;
                }
                else
                {
                    drow[NamedValue.Option1ImageName] = string.Empty;
                    drow[NamedValue.Option2ImageName] = string.Empty;
                    drow[NamedValue.Option3ImageName] = string.Empty;
                    drow[NamedValue.Option4ImageName] = string.Empty;

                    drow[NamedValue.Option1] = question.OptionList[0];

                    if (question.OptionList.Count == 2)
                    {
                        drow[NamedValue.Option2] = question.OptionList[1];
                        drow[NamedValue.Option3] = string.Empty;
                        drow[NamedValue.Option4] = string.Empty;
                    }

                    if (question.OptionList.Count == 3)
                    {
                        drow[NamedValue.Option2] = question.OptionList[1];
                        drow[NamedValue.Option3] = question.OptionList[2];
                        drow[NamedValue.Option4] = string.Empty;
                    }

                    if (question.OptionList.Count == 4)
                    {
                        drow[NamedValue.Option2] = question.OptionList[1];
                        drow[NamedValue.Option3] = question.OptionList[2];
                        drow[NamedValue.Option4] = question.OptionList[3];
                    }
                }

                drow[NamedValue.DifficultyLevel] = question.DifficultyLevel;
                drow[NamedValue.ExamCategory_Id] = question.CategoryId;

                dt.Rows.Add(drow);
            }

            return dt;
        }
    }
}
