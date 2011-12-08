namespace DigitalVoterList.PollingTable.View.Root_elements
{
    using System.Windows.Forms;

    partial class RegAndCancelUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelPanel = new System.Windows.Forms.Panel();
            this.registerPanel = new System.Windows.Forms.Panel();
            this.registerBtn = new RegisterBtn();
            this.SuspendLayout();
            // 
            // cancelPanel
            // 
            this.cancelPanel.Location = new System.Drawing.Point(168, 0);
            this.cancelPanel.Name = "cancelPanel";
            this.cancelPanel.Size = new System.Drawing.Size(162, 62);
            this.cancelPanel.TabIndex = 3;
            this.cancelPanel.Controls.Add(new CancelBtn());
            // 
            // registerPanel
            // 
            this.registerPanel.Location = new System.Drawing.Point(0, 0);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.Size = new System.Drawing.Size(162, 62);
            this.registerPanel.TabIndex = 2;
            this.registerPanel.Controls.Add(registerBtn);
            // 
            // RegAndCancelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelPanel);
            this.Controls.Add(this.registerPanel);
            this.Name = "RegAndCancelUC";
            this.Size = new System.Drawing.Size(330, 62);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel cancelPanel;
        private System.Windows.Forms.Panel registerPanel;
        //Field for the register button. 
        private RegisterBtn registerBtn;

        public RegisterBtn RegisterBtn
        {
            get
            {
                return registerBtn;
            }
        }
    }
}
