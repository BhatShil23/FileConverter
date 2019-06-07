using System;
using DataWriter;
using Common.Logger;
using Common.Util;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using TuduBuddy.PersonalInfoExtractor;
using TuduBuddyLibraries.Environment;

namespace TuduBuddyAutomation.UI
{
    public partial class FormPersonalInfoExtractor : Form
    {
        readonly OpenFileDialog openFileDialog = new OpenFileDialog();
        readonly Logger logger = Logger.GetInstance();
        readonly ApplicationEnvironment appEnv = new ApplicationEnvironment();
        readonly PublicDomainConfig domainConfig = new PublicDomainConfig();

        public FormPersonalInfoExtractor()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = NamedValue.CsvFileDialogFilter;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtBoxInput.Text = openFileDialog.FileName;
            }
        }

        private void BtnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                btnExtract.Enabled = false;
                string inputFile = txtBoxInput.Text;

                List<string> publicDomainList = domainConfig.GetPublicDomainList();

                logger.AppendLog(string.Empty);
                logger.AppendLog("Input file: " + inputFile);

                string outputDir = appEnv.CreateOutputDirectory(Path.GetDirectoryName(inputFile));
                appEnv.InitLogFile(outputDir);

                logger.AppendLog("Public domain list from config..");
                
                foreach(string domainName in  publicDomainList)
                {
                    logger.AppendLog(domainName);
                }
            
                logger.AppendLog(string.Empty);

                PersonalInfoExtractor personalInfoExtractor = new PersonalInfoExtractor(inputFile, publicDomainList);
                DataTable dt = personalInfoExtractor.GetPersonalInfoWithPublicDomain();

                string[] fileData = personalInfoExtractor.GetDataFromCsvFile();
                PersonalInfoSummary summary = new PersonalInfoSummary(fileData, 
                    NamedValue.PersonalInfoExtractor.CsvColumnDelimiter);

                List<DomainSummary> domainListSummary = summary.GetSummary();
                DisplaySummaryLog(outputDir, domainListSummary);
                
                logger.AppendLog("");

                string output = appEnv.GetOutputFileName(inputFile, outputDir, NamedValue.ExcelFileExtension);

                ExcelWriter excelWriter = new ExcelWriter(output);
                excelWriter.WriteData(dt);

                MessageBox.Show("Output generated.", "TuduBuddy Automation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TuduBuddy Automation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                appEnv.SaveLogToFile();
                btnExtract.Enabled = true;
            }
        }

        private void DisplaySummaryLog(string outputDir, List<DomainSummary> domainSummary)
        {
            List<string> domainListSummary = new List<string>();

            string summaryFile = outputDir + @"\" + NamedValue.PersonalInfoExtractor.SummaryFileName;

            foreach (DomainSummary summary in domainSummary)
            {
                domainListSummary.Add("Domain name: " + summary.DomainName);
                domainListSummary.Add("Email usage: " + summary.Count);
                domainListSummary.Add(string.Empty);
            }

            appEnv.SaveDataToTextFile(summaryFile, domainListSummary.ToArray());
        }
    }
}
