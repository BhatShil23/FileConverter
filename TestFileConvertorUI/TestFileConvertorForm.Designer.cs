namespace TestFileConvertorUI
{
    partial class FormTestFileConvertor
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
            this.radBtnSingle = new System.Windows.Forms.RadioButton();
            this.radBtnMultiple = new System.Windows.Forms.RadioButton();
            this.lblFileConversion = new System.Windows.Forms.Label();
            this.chkBoxOverwriteFile = new System.Windows.Forms.CheckBox();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.rtBoxLogWindow = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastSavedConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radBtnSingle
            // 
            this.radBtnSingle.AutoSize = true;
            this.radBtnSingle.Location = new System.Drawing.Point(15, 62);
            this.radBtnSingle.Name = "radBtnSingle";
            this.radBtnSingle.Size = new System.Drawing.Size(54, 17);
            this.radBtnSingle.TabIndex = 0;
            this.radBtnSingle.TabStop = true;
            this.radBtnSingle.Text = "Single";
            this.radBtnSingle.UseVisualStyleBackColor = true;
            this.radBtnSingle.CheckedChanged += new System.EventHandler(this.RadBtnSingle_CheckedChanged);
            // 
            // radBtnMultiple
            // 
            this.radBtnMultiple.AutoSize = true;
            this.radBtnMultiple.Location = new System.Drawing.Point(15, 85);
            this.radBtnMultiple.Name = "radBtnMultiple";
            this.radBtnMultiple.Size = new System.Drawing.Size(61, 17);
            this.radBtnMultiple.TabIndex = 2;
            this.radBtnMultiple.TabStop = true;
            this.radBtnMultiple.Text = "Multiple";
            this.radBtnMultiple.UseVisualStyleBackColor = true;
            this.radBtnMultiple.CheckedChanged += new System.EventHandler(this.RadBtnMultiple_CheckedChanged);
            // 
            // lblFileConversion
            // 
            this.lblFileConversion.AutoSize = true;
            this.lblFileConversion.Location = new System.Drawing.Point(12, 35);
            this.lblFileConversion.Name = "lblFileConversion";
            this.lblFileConversion.Size = new System.Drawing.Size(79, 13);
            this.lblFileConversion.TabIndex = 3;
            this.lblFileConversion.Text = "File Conversion";
            // 
            // chkBoxOverwriteFile
            // 
            this.chkBoxOverwriteFile.AutoSize = true;
            this.chkBoxOverwriteFile.Location = new System.Drawing.Point(15, 118);
            this.chkBoxOverwriteFile.Name = "chkBoxOverwriteFile";
            this.chkBoxOverwriteFile.Size = new System.Drawing.Size(120, 17);
            this.chkBoxOverwriteFile.TabIndex = 4;
            this.chkBoxOverwriteFile.Text = "Overwrite output file";
            this.chkBoxOverwriteFile.UseVisualStyleBackColor = true;
            this.chkBoxOverwriteFile.CheckedChanged += new System.EventHandler(this.ChkBoxOverwriteFile_CheckedChanged);
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Location = new System.Drawing.Point(203, 64);
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(272, 20);
            this.txtBoxInput.TabIndex = 5;
            this.txtBoxInput.TextChanged += new System.EventHandler(this.TxtBoxInput_TextChanged);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(200, 35);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(31, 13);
            this.lblInput.TabIndex = 6;
            this.lblInput.Text = "Input";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(500, 62);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(109, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(366, 102);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(109, 23);
            this.btnConvert.TabIndex = 8;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // rtBoxLogWindow
            // 
            this.rtBoxLogWindow.Location = new System.Drawing.Point(12, 150);
            this.rtBoxLogWindow.Name = "rtBoxLogWindow";
            this.rtBoxLogWindow.ReadOnly = true;
            this.rtBoxLogWindow.Size = new System.Drawing.Size(619, 255);
            this.rtBoxLogWindow.TabIndex = 9;
            this.rtBoxLogWindow.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(537, 411);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(643, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastSavedConfigurationToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Configuration";
            // 
            // lastSavedConfigurationToolStripMenuItem
            // 
            this.lastSavedConfigurationToolStripMenuItem.Name = "lastSavedConfigurationToolStripMenuItem";
            this.lastSavedConfigurationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lastSavedConfigurationToolStripMenuItem.Text = "Load";
            this.lastSavedConfigurationToolStripMenuItem.Click += new System.EventHandler(this.LastSavedConfigurationToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // FormTestFileConvertor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 446);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rtBoxLogWindow);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtBoxInput);
            this.Controls.Add(this.chkBoxOverwriteFile);
            this.Controls.Add(this.lblFileConversion);
            this.Controls.Add(this.radBtnMultiple);
            this.Controls.Add(this.radBtnSingle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTestFileConvertor";
            this.Text = "Test File Convertor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radBtnSingle;
        private System.Windows.Forms.RadioButton radBtnMultiple;
        private System.Windows.Forms.Label lblFileConversion;
        private System.Windows.Forms.CheckBox chkBoxOverwriteFile;
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.RichTextBox rtBoxLogWindow;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastSavedConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

