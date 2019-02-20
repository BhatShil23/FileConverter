using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

using System.IO;
using System.Data;
using Newtonsoft.Json;
using DataReaderWriter;
using FileConvertor;

namespace FileConvertorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputFilePath = txtBoxInput.Text;

                if (!File.Exists(inputFilePath))
                    throw new FileNotFoundException();


                string fileName = System.IO.Path.GetFileName(inputFilePath);

                string outputFile = System.IO.Path.GetDirectoryName(inputFilePath) + @"\" +
                    System.IO.Path.GetFileNameWithoutExtension(inputFilePath) + ".xlsx";

                WordReader wordReader = new WordReader(inputFilePath);
                string fileData = wordReader.ReadData();

                QuestionPaperFormattingRules formattingRules;
                using (StreamReader r = new StreamReader(NamedValue.RulesConfigFile))
                {
                    string json = r.ReadToEnd();
                    formattingRules = JsonConvert.DeserializeObject<QuestionPaperFormattingRules>(json);
                }

                QuestionPaperParser questionPaperParser = new QuestionPaperParser(fileData, formattingRules);
                QuestionPaper questionPaper = questionPaperParser.GetQuestionPaperFromText();
                questionPaper.Name = fileName;

                QuestionPaperTable testDt = new QuestionPaperTable(questionPaper);
                DataTable dataTable = testDt.GetDataTable();

                ExcelWriter dataWriter = new ExcelWriter(outputFile);
                dataWriter.WriteData(dataTable);

                System.Windows.MessageBox.Show("Output file: "+outputFile);
            }
            catch(FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Word Doc|*.docx",
                CheckFileExists = true
            };
          
            if (openFileDialog.ShowDialog() == true)
                txtBoxInput.Text = openFileDialog.FileName;
        }
    }
}
