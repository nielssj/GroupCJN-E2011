namespace DigitalVoterList.Central.Views
{
    partial class VoterCardGeneratorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoterCardGeneratorWindow));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pbrGroups = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.pbrVoters = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbLimit = new System.Windows.Forms.CheckBox();
            this.chbProperty = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxProperty = new System.Windows.Forms.ComboBox();
            this.txbLimit = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txbDestination = new System.Windows.Forms.TextBox();
            this.destinationFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.lblCurrentGroup = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(104, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(176, 265);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(81, 23);
            this.btnGenerate.TabIndex = 15;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Overall progress:";
            // 
            // pbrGroups
            // 
            this.pbrGroups.Location = new System.Drawing.Point(13, 229);
            this.pbrGroups.Name = "pbrGroups";
            this.pbrGroups.Size = new System.Drawing.Size(244, 23);
            this.pbrGroups.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Group progress:";
            // 
            // pbrVoters
            // 
            this.pbrVoters.Location = new System.Drawing.Point(12, 179);
            this.pbrVoters.Name = "pbrVoters";
            this.pbrVoters.Size = new System.Drawing.Size(244, 23);
            this.pbrVoters.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbLimit);
            this.groupBox1.Controls.Add(this.chbProperty);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxProperty);
            this.groupBox1.Controls.Add(this.txbLimit);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 76);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group By";
            // 
            // chbLimit
            // 
            this.chbLimit.AutoSize = true;
            this.chbLimit.Location = new System.Drawing.Point(8, 47);
            this.chbLimit.Name = "chbLimit";
            this.chbLimit.Size = new System.Drawing.Size(47, 17);
            this.chbLimit.TabIndex = 6;
            this.chbLimit.Text = "Limit";
            this.chbLimit.UseVisualStyleBackColor = true;
            // 
            // chbProperty
            // 
            this.chbProperty.AutoSize = true;
            this.chbProperty.Checked = true;
            this.chbProperty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbProperty.Location = new System.Drawing.Point(8, 21);
            this.chbProperty.Name = "chbProperty";
            this.chbProperty.Size = new System.Drawing.Size(65, 17);
            this.chbProperty.TabIndex = 5;
            this.chbProperty.Text = "Property";
            this.chbProperty.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "voters / file";
            // 
            // cbxProperty
            // 
            this.cbxProperty.FormattingEnabled = true;
            this.cbxProperty.Items.AddRange(new object[] {
            "Municipality",
            "Polling Station",
            "Alphabet",
            "City"});
            this.cbxProperty.Location = new System.Drawing.Point(94, 19);
            this.cbxProperty.Name = "cbxProperty";
            this.cbxProperty.Size = new System.Drawing.Size(142, 21);
            this.cbxProperty.TabIndex = 3;
            this.cbxProperty.Text = "Municipality";
            // 
            // txbLimit
            // 
            this.txbLimit.Location = new System.Drawing.Point(94, 45);
            this.txbLimit.Name = "txbLimit";
            this.txbLimit.Size = new System.Drawing.Size(65, 20);
            this.txbLimit.TabIndex = 2;
            this.txbLimit.Text = "1000";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txbDestination);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 52);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination folder";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(179, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(56, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txbDestination
            // 
            this.txbDestination.Location = new System.Drawing.Point(7, 19);
            this.txbDestination.Name = "txbDestination";
            this.txbDestination.Size = new System.Drawing.Size(166, 20);
            this.txbDestination.TabIndex = 0;
            this.txbDestination.Text = "C:\\VoterCards";
            // 
            // destinationFolderBrowser
            // 
            this.destinationFolderBrowser.SelectedPath = "C:\\";
            // 
            // lblCurrentGroup
            // 
            this.lblCurrentGroup.Location = new System.Drawing.Point(100, 163);
            this.lblCurrentGroup.Name = "lblCurrentGroup";
            this.lblCurrentGroup.Size = new System.Drawing.Size(156, 13);
            this.lblCurrentGroup.TabIndex = 18;
            this.lblCurrentGroup.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // VoterCardGeneratorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 299);
            this.Controls.Add(this.lblCurrentGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbrGroups);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbrVoters);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VoterCardGeneratorWindow";
            this.Text = "Voter Card Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbrGroups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbrVoters;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxProperty;
        private System.Windows.Forms.TextBox txbLimit;
        private System.Windows.Forms.CheckBox chbLimit;
        private System.Windows.Forms.CheckBox chbProperty;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txbDestination;
        private System.Windows.Forms.FolderBrowserDialog destinationFolderBrowser;
        private System.Windows.Forms.Label lblCurrentGroup;
    }
}