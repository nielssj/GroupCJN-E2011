namespace DigitalVoterList.Central.Views
{
    using System.Windows.Forms;

    partial class ServerSetupWindow
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
            this.userBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.adressBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.dbBox = new System.Windows.Forms.TextBox();
            this.dbLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userBox
            // 
            this.userBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userBox.Location = new System.Drawing.Point(109, 82);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(112, 20);
            this.userBox.TabIndex = 3;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(12, 35);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 12;
            this.portLabel.Text = "Port:";
            // 
            // portBox
            // 
            this.portBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portBox.Location = new System.Drawing.Point(109, 32);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(112, 20);
            this.portBox.TabIndex = 1;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(12, 85);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(32, 13);
            this.userLabel.TabIndex = 10;
            this.userLabel.Text = "User:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(12, 9);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(81, 13);
            this.addressLabel.TabIndex = 9;
            this.addressLabel.Text = "Target address:";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(145, 136);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 5;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            // 
            // adressBox
            // 
            this.adressBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adressBox.Location = new System.Drawing.Point(109, 6);
            this.adressBox.Name = "adressBox";
            this.adressBox.Size = new System.Drawing.Size(112, 20);
            this.adressBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordBox.Location = new System.Drawing.Point(109, 108);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(112, 20);
            this.passwordBox.TabIndex = 4;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 111);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(87, 13);
            this.passwordLabel.TabIndex = 14;
            this.passwordLabel.Text = "Admin password:";
            // 
            // dbBox
            // 
            this.dbBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbBox.Location = new System.Drawing.Point(109, 57);
            this.dbBox.Name = "dbBox";
            this.dbBox.Size = new System.Drawing.Size(112, 20);
            this.dbBox.TabIndex = 2;
            // 
            // dbLabel
            // 
            this.dbLabel.AutoSize = true;
            this.dbLabel.Location = new System.Drawing.Point(12, 60);
            this.dbLabel.Name = "dbLabel";
            this.dbLabel.Size = new System.Drawing.Size(53, 13);
            this.dbLabel.TabIndex = 16;
            this.dbLabel.Text = "Db name:";
            // 
            // ServerSetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 162);
            this.Controls.Add(this.dbBox);
            this.Controls.Add(this.dbLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.adressBox);
            this.Name = "ServerSetupWindow";
            this.Text = "SetupWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userBox;

        public string TableBox
        {
            get
            {
                return this.portBox.Text;
            }
            set
            {
                this.portBox.Text = value;
            }
        }

        public string IpTextBox
        {
            get
            {
                return this.adressBox.Text;
            }
            set
            {
                this.adressBox.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return this.userBox.Text;
            }
            set
            {
                userBox.Text = value;
            }
        }

        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox adressBox;
        private TextBox passwordBox;
        private Label passwordLabel;
        private TextBox dbBox;
        private Label dbLabel;

        public Button ConnectBtn
        {
            get
            {
                return connectBtn;
            }
        }



    }
}