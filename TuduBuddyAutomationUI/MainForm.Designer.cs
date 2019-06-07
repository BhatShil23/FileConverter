namespace TuduBuddyAutomation.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBoxMainFunctions = new System.Windows.Forms.GroupBox();
            this.radBtnInfoExtractorFeature = new System.Windows.Forms.RadioButton();
            this.radBtnTestPaperConversionFeature = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfirmFeatureSelection = new System.Windows.Forms.Button();
            this.grpBoxMainFunctions.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxMainFunctions
            // 
            this.grpBoxMainFunctions.Controls.Add(this.radBtnInfoExtractorFeature);
            this.grpBoxMainFunctions.Controls.Add(this.radBtnTestPaperConversionFeature);
            this.grpBoxMainFunctions.Location = new System.Drawing.Point(12, 27);
            this.grpBoxMainFunctions.Name = "grpBoxMainFunctions";
            this.grpBoxMainFunctions.Size = new System.Drawing.Size(352, 116);
            this.grpBoxMainFunctions.TabIndex = 1;
            this.grpBoxMainFunctions.TabStop = false;
            this.grpBoxMainFunctions.Text = "Choose Automation Feature";
            // 
            // radBtnInfoExtractorFeature
            // 
            this.radBtnInfoExtractorFeature.AutoSize = true;
            this.radBtnInfoExtractorFeature.Location = new System.Drawing.Point(17, 66);
            this.radBtnInfoExtractorFeature.Name = "radBtnInfoExtractorFeature";
            this.radBtnInfoExtractorFeature.Size = new System.Drawing.Size(304, 17);
            this.radBtnInfoExtractorFeature.TabIndex = 1;
            this.radBtnInfoExtractorFeature.TabStop = true;
            this.radBtnInfoExtractorFeature.Text = "Information extraction by email domain name - CSV to Excel";
            this.radBtnInfoExtractorFeature.UseVisualStyleBackColor = true;
            this.radBtnInfoExtractorFeature.CheckedChanged += new System.EventHandler(this.RadBtnInfoExtractorFeature_CheckedChanged);
            // 
            // radBtnTestPaperConversionFeature
            // 
            this.radBtnTestPaperConversionFeature.AutoSize = true;
            this.radBtnTestPaperConversionFeature.Location = new System.Drawing.Point(17, 33);
            this.radBtnTestPaperConversionFeature.Name = "radBtnTestPaperConversionFeature";
            this.radBtnTestPaperConversionFeature.Size = new System.Drawing.Size(207, 17);
            this.radBtnTestPaperConversionFeature.TabIndex = 0;
            this.radBtnTestPaperConversionFeature.TabStop = true;
            this.radBtnTestPaperConversionFeature.Text = "Test paper conversion - Word to Excel";
            this.radBtnTestPaperConversionFeature.UseVisualStyleBackColor = true;
            this.radBtnTestPaperConversionFeature.CheckedChanged += new System.EventHandler(this.RadBtnTestPaperConversionFeature_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(469, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // btnConfirmFeatureSelection
            // 
            this.btnConfirmFeatureSelection.Location = new System.Drawing.Point(382, 87);
            this.btnConfirmFeatureSelection.Name = "btnConfirmFeatureSelection";
            this.btnConfirmFeatureSelection.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmFeatureSelection.TabIndex = 3;
            this.btnConfirmFeatureSelection.Text = "Select";
            this.btnConfirmFeatureSelection.UseVisualStyleBackColor = true;
            this.btnConfirmFeatureSelection.Click += new System.EventHandler(this.BtnConfirmFeatureSelection_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 159);
            this.Controls.Add(this.btnConfirmFeatureSelection);
            this.Controls.Add(this.grpBoxMainFunctions);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Tudubuddy Automation Application";
            this.grpBoxMainFunctions.ResumeLayout(false);
            this.grpBoxMainFunctions.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxMainFunctions;
        private System.Windows.Forms.RadioButton radBtnInfoExtractorFeature;
        private System.Windows.Forms.RadioButton radBtnTestPaperConversionFeature;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button btnConfirmFeatureSelection;
    }
}