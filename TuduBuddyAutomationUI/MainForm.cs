using System;
using System.Windows.Forms;
using Common.Logger;

namespace TuduBuddyAutomation.UI
{
    public partial class MainForm : Form
    {
        FormTestFileConvertor testFileConvertorForm = null;
        FormPersonalInfoExtractor personalInfoExtractionForm = null;
        readonly Logger logger = Logger.GetInstance();

        public MainForm()
        {
            InitializeComponent();
            logger.Clear();
            logger.InitLoggingInfo();
        }

        private void RadBtnTestPaperConversionFeature_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnTestPaperConversionFeature.Checked == true)
                radBtnInfoExtractorFeature.Checked = false;
        }

        private void RadBtnInfoExtractorFeature_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnInfoExtractorFeature.Checked == true)
                radBtnTestPaperConversionFeature.Checked = false;
        }

        private void BtnConfirmFeatureSelection_Click(object sender, EventArgs e)
        {
            logger.AppendLog("Feature selection: ");

            if (radBtnInfoExtractorFeature.Checked == true)
            {
                logger.AppendLog("Information extraction by email domain name - CSV to Excel");

                if (personalInfoExtractionForm == null)
                {
                    personalInfoExtractionForm = new FormPersonalInfoExtractor();
                }

                personalInfoExtractionForm.Show();
            }
            else if(radBtnTestPaperConversionFeature.Checked == true)
            {
                logger.AppendLog("Test paper conversion - Word to Excel");

                if (testFileConvertorForm == null)
                {
                    testFileConvertorForm = new FormTestFileConvertor();
                }

                testFileConvertorForm.Show();
            }
        }
    }
}
