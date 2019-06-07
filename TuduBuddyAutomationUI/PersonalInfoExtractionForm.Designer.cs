namespace TuduBuddyAutomation.UI
{
    partial class FormPersonalInfoExtractor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.labelInput = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.lblPublicDomain = new System.Windows.Forms.Label();
            this.grpBoxInput = new System.Windows.Forms.GroupBox();
            this.grpBoxInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(526, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Location = new System.Drawing.Point(57, 27);
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(284, 20);
            this.txtBoxInput.TabIndex = 2;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(6, 32);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(31, 13);
            this.labelInput.TabIndex = 3;
            this.labelInput.Text = "Input";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(357, 24);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(104, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(357, 53);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(104, 23);
            this.btnExtract.TabIndex = 5;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.BtnExtract_Click);
            // 
            // lblPublicDomain
            // 
            this.lblPublicDomain.AutoSize = true;
            this.lblPublicDomain.Location = new System.Drawing.Point(230, 173);
            this.lblPublicDomain.Name = "lblPublicDomain";
            this.lblPublicDomain.Size = new System.Drawing.Size(0, 13);
            this.lblPublicDomain.TabIndex = 7;
            // 
            // grpBoxInput
            // 
            this.grpBoxInput.Controls.Add(this.txtBoxInput);
            this.grpBoxInput.Controls.Add(this.labelInput);
            this.grpBoxInput.Controls.Add(this.btnBrowse);
            this.grpBoxInput.Controls.Add(this.btnExtract);
            this.grpBoxInput.Location = new System.Drawing.Point(12, 12);
            this.grpBoxInput.Name = "grpBoxInput";
            this.grpBoxInput.Size = new System.Drawing.Size(499, 94);
            this.grpBoxInput.TabIndex = 11;
            this.grpBoxInput.TabStop = false;
            // 
            // FormPersonalInfoExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 118);
            this.Controls.Add(this.grpBoxInput);
            this.Controls.Add(this.lblPublicDomain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPersonalInfoExtractor";
            this.Text = "Personal Info Extraction Form";
            this.grpBoxInput.ResumeLayout(false);
            this.grpBoxInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Label lblPublicDomain;
        private System.Windows.Forms.GroupBox grpBoxInput;
    }
}