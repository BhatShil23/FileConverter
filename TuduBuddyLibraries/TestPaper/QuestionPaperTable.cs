using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuduBuddyLibraries.Environment;

namespace TestMaterial
{
    public class QuestionPaperTable
    {
        readonly private QuestionPaper questionPaper = null;

        public QuestionPaperTable(QuestionPaper questionPaper)
        {
            this.questionPaper = questionPaper;
        }

        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(NamedValue.TestPaperConversion.QuestionText);
            dt.Columns.Add(NamedValue.TestPaperConversion.ImageName);
            dt.Columns.Add(NamedValue.TestPaperConversion.Option1);
            dt.Columns.Add(NamedValue.TestPaperConversion.Option1ImageName);
            dt.Columns.Add(NamedValue.TestPaperConversion.Option2);
            dt.Columns.Add(NamedValue.TestPaperConversion.Option2ImageName);
            dt.Columns.Add(NamedValue.TestPaperConversion.Option3);
            dt.Columns.Add(NamedValue.TestPaperConversion.Option3ImageName);
            dt.Columns.Add(NamedValue.TestPaperConversion.Option4);
            dt.Columns.Add(NamedValue.TestPaperConversion.Option4ImageName);
            dt.Columns.Add(NamedValue.TestPaperConversion.DifficultyLevel);
            dt.Columns.Add(NamedValue.TestPaperConversion.ExamCategory_Id);

            foreach(Question question in questionPaper.QuestionList)
            {
                DataRow drow = dt.NewRow();
                drow[NamedValue.TestPaperConversion.QuestionText] = question.Description;
                drow[NamedValue.TestPaperConversion.ImageName] = question.Image;
                
                if(question.OptionType == OptionType.Image)
                {
                    drow[NamedValue.TestPaperConversion.Option1ImageName] = question.OptionList[0];

                    if (question.OptionList.Count == 2)
                    {
                        drow[NamedValue.TestPaperConversion.Option2ImageName] = question.OptionList[1];
                        drow[NamedValue.TestPaperConversion.Option3ImageName] = string.Empty;
                        drow[NamedValue.TestPaperConversion.Option4ImageName] = string.Empty;
                    }

                    if (question.OptionList.Count == 3)
                    {
                        drow[NamedValue.TestPaperConversion.Option2ImageName] = question.OptionList[1];
                        drow[NamedValue.TestPaperConversion.Option3ImageName] = question.OptionList[2];
                        drow[NamedValue.TestPaperConversion.Option4ImageName] = string.Empty;
                    }

                    if (question.OptionList.Count == 4)
                    {
                        drow[NamedValue.TestPaperConversion.Option2ImageName] = question.OptionList[1];
                        drow[NamedValue.TestPaperConversion.Option3ImageName] = question.OptionList[2];
                        drow[NamedValue.TestPaperConversion.Option4ImageName] = question.OptionList[3];
                    }

                    drow[NamedValue.TestPaperConversion.Option1] = string.Empty;
                    drow[NamedValue.TestPaperConversion.Option2] = string.Empty;
                    drow[NamedValue.TestPaperConversion.Option3] = string.Empty;
                    drow[NamedValue.TestPaperConversion.Option4] = string.Empty;
                }
                else
                {
                    drow[NamedValue.TestPaperConversion.Option1ImageName] = string.Empty;
                    drow[NamedValue.TestPaperConversion.Option2ImageName] = string.Empty;
                    drow[NamedValue.TestPaperConversion.Option3ImageName] = string.Empty;
                    drow[NamedValue.TestPaperConversion.Option4ImageName] = string.Empty;

                    drow[NamedValue.TestPaperConversion.Option1] = question.OptionList[0];

                    if (question.OptionList.Count == 2)
                    {
                        drow[NamedValue.TestPaperConversion.Option2] = question.OptionList[1];
                        drow[NamedValue.TestPaperConversion.Option3] = string.Empty;
                        drow[NamedValue.TestPaperConversion.Option4] = string.Empty;
                    }

                    if (question.OptionList.Count == 3)
                    {
                        drow[NamedValue.TestPaperConversion.Option2] = question.OptionList[1];
                        drow[NamedValue.TestPaperConversion.Option3] = question.OptionList[2];
                        drow[NamedValue.TestPaperConversion.Option4] = string.Empty;
                    }

                    if (question.OptionList.Count == 4)
                    {
                        drow[NamedValue.TestPaperConversion.Option2] = question.OptionList[1];
                        drow[NamedValue.TestPaperConversion.Option3] = question.OptionList[2];
                        drow[NamedValue.TestPaperConversion.Option4] = question.OptionList[3];
                    }
                }

                drow[NamedValue.TestPaperConversion.DifficultyLevel] = question.DifficultyLevel;
                drow[NamedValue.TestPaperConversion.ExamCategory_Id] = question.CategoryId;

                dt.Rows.Add(drow);
            }

            return dt;
        }
    }
}
