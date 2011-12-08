namespace DigitalVoterList.Central.Views
{
    partial class VoterBoxManagerWindow
    {
        public VoterBoxManagerWindow()
        {
            this.progressBar1.Step = 1;
            this.progressBar1.Maximum = 5;
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoterBoxManagerWindow));
            this.label2 = new System.Windows.Forms.Label();
            this.validateButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.progressTF = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.connectButton = new System.Windows.Forms.Button();
            this.adressTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Progress:";
            // 
            // validateButton
            // 
            this.validateButton.Location = new System.Drawing.Point(161, 199);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(68, 23);
            this.validateButton.TabIndex = 14;
            this.validateButton.Text = "Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(235, 199);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(63, 23);
            this.uploadButton.TabIndex = 13;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            // 
            // progressTF
            // 
            this.progressTF.Location = new System.Drawing.Point(14, 40);
            this.progressTF.Multiline = true;
            this.progressTF.Name = "progressTF";
            this.progressTF.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.progressTF.Size = new System.Drawing.Size(286, 111);
            this.progressTF.TabIndex = 12;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 170);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(284, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(225, 11);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 10;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // adressTB
            // 
            this.adressTB.Location = new System.Drawing.Point(98, 13);
            this.adressTB.Name = "adressTB";
            this.adressTB.Size = new System.Drawing.Size(119, 20);
            this.adressTB.TabIndex = 9;
            this.adressTB.Text = "192.168.20.11";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Target address:";
            // 
            // VoterBoxManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 233);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.progressTF);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.adressTB);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VoterBoxManagerWindow";
            this.Text = "Voter Box Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.TextBox progressTF;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox adressTB;
        private System.Windows.Forms.Label label1;

        public string Address
        {
            get
            {
                return adressTB.Text;
            }
        }

        public delegate void ButtonHandler();

        public void AddValidateHandler(ButtonHandler h)
        {
            this.validateButton.Click += (o, eA) => h();
        }

        public void AddUploadHandler(ButtonHandler h)
        {
            this.uploadButton.Click += (o, eA) => h();
        }

        public void AddConnectHandler(ButtonHandler h)
        {
            this.connectButton.Click += (o, eA) => h();
        }

        public void UpdateProgress()
        {
            this.progressBar1.PerformStep();
        }

        public void UpdateProgressText(string text)
        {
            this.progressTF.Text += text + "\n";
        }
    }
}