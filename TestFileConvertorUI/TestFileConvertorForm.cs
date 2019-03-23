using System;
using System.Windows.Forms;
using System.IO;
using TestMaterial;
using Newtonsoft.Json;
using Common.Logger;
using Common.Util;

namespace TestFileConvertorUI
{
    public partial class FormTestFileConvertor : Form
    {
        Config config = new  Config();
        readonly Logger logger = Logger.GetInstance();
        readonly OpenFileDialog openFileDialog = new OpenFileDialog();
        readonly FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        public FormTestFileConvertor()
        {
            InitializeComponent();
            radBtnSingle.Checked = true;
            config.OverwriteOutputFile = FileOverWriteFlag.no;
        }

        #region UI controls
        private void RadBtnSingle_CheckedChanged(object sender, EventArgs e)
        {
            if(radBtnSingle.Checked == true)
            {
                radBtnMultiple.Checked = false;
                config.FileConversionOption = FileConversionOption.Single;
            }
            else if(radBtnSingle.Checked == false)
            {
                radBtnMultiple.Checked = true;
                config.FileConversionOption = FileConversionOption.Multiple;
            }
        }

        private void RadBtnMultiple_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnMultiple.Checked == true)
            {
                radBtnSingle.Checked = false;

                if (!string.IsNullOrWhiteSpace(txtBoxInput.Text))
                {
                    if (File.Exists(txtBoxInput.Text))
                    {
                        txtBoxInput.Text = Path.GetDirectoryName(txtBoxInput.Text);
                    }
                }
            }
            else if (radBtnMultiple.Checked == false)
            {
                radBtnSingle.Checked = true;
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (radBtnSingle.Checked == true)
            {
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "Word File|*.docx";

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBoxInput.Text = openFileDialog.FileName;
                }
            }
            else if(radBtnMultiple.Checked == true)
            {
                folderBrowserDialog.ShowNewFolderButton = true;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBoxInput.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                btnConvert.Enabled = false;
                config.Input = txtBoxInput.Text;

                logger.Clear();
                logger.InitLogingInfo();
                logger.AppendLog("Following options selected:");
                logger.AppendLog("File conversion option: " + config.FileConversionOption.ToString());
                logger.AppendLog("Input file path: " + config.Input);
                logger.AppendLog("Overwrite output file: " + config.OverwriteOutputFile.ToString());
               
                logger.AppendLog(string.Empty);
                Log(logger.GetLog());

                TestFileConvertor testFileConvertor = new TestFileConvertor(config);
                testFileConvertor.Convert();

                Log(logger.GetLog());
                btnConvert.Enabled = true;
            }
            catch(Exception ex)
            {
                Log(logger.GetLog());
                MessageBox.Show(ex.Message, "Test File Format Convertor", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!CommonUtil.IsEmptyOrWhiteSpace(logger.FileName))
                {
                    if (!File.Exists(logger.FileName))
                    {
                        File.Create(logger.FileName).Close();
                    }

                    File.WriteAllText(logger.FileName, logger.GetLog());
                }
            }
        }

        private void ChkBoxOverwriteFile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxOverwriteFile.Checked == true)
            {
                config.OverwriteOutputFile = FileOverWriteFlag.yes;
            }
            else if (chkBoxOverwriteFile.Checked == false)
            {
                config.OverwriteOutputFile = FileOverWriteFlag.no;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            rtBoxLogWindow.Clear();
        }

        #endregion

        private void SaveDataToConfig()
        {
            string configFile = @"Config.json";

            if (!File.Exists(configFile))
                throw new FileNotFoundException();

            try
            {
                File.WriteAllText(configFile, JsonConvert.SerializeObject(config));
                using (StreamWriter file = File.CreateText(configFile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, config);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error in saving data to config file." +
                    " Ensure corret options are being saved. ";
                logger.AppendLog(errorMessage);

                throw new Exception(errorMessage + ex.Message);
            }
        }

        private void LastSavedConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                logger.AppendLog("Loading configuration...");
                using (StreamReader r = new StreamReader(NamedValue.AppConfigFile))
                {
                    string json = r.ReadToEnd();
                    config = JsonConvert.DeserializeObject<Config>(json);
                }

                logger.AppendLog("Configuration loaded successfully.");
                logger.AppendLog(string.Empty);

                if (config != null)
                {
                    txtBoxInput.Text = config.Input;

                    if (config.OverwriteOutputFile == FileOverWriteFlag.yes)
                        chkBoxOverwriteFile.Checked = true;
                    else
                        chkBoxOverwriteFile.Checked = false;

                    if (config.FileConversionOption == FileConversionOption.Single)
                        radBtnSingle.Checked = true;
                    else
                        radBtnSingle.Checked = false;
                }

                Log(logger.GetLog());
            }
            catch(Exception ex)
            {
                string errorMessage = "Error reading config file." +
                    " Ensure correct options are chosen in the config file.";
                logger.AppendLog(errorMessage);

                MessageBox.Show(ex.Message, "Test File Format Convertor",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Log(string log)
        {
            rtBoxLogWindow.Text = log;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.AppendLog("Saving configuration in file " + NamedValue.AppConfigFile+"...");
            SaveDataToConfig();
            logger.AppendLog("Configuration saved successfully.");
            Log(logger.GetLog());
        }

        private void TxtBoxInput_TextChanged(object sender, EventArgs e)
        {
            config.Input = txtBoxInput.Text;
        }
    }
}
