namespace DigitalVoterList
{
    using DigitalVoterList.PollingTable.View.Root_elements;

    partial class WarningUC
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
            ///The panels to hold the User Controls
            this.RegAndCancelPanel = new System.Windows.Forms.Panel();
            this.WarningMessagePanel = new System.Windows.Forms.Panel();
           
            ///The user controls
            this.RegAndCancelUC = new RegAndCancelUC();
            this.RegAndCancelUC.RegisterBtn.Hide(); ///Hides the register button soit cannot be chosen when the voter is alredy registered.

            this.WarningMsgUC = new WarningMsg();

            ///
            this.RegAndCancelPanel.SuspendLayout();
            this.WarningMessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegAndCancelPanel
            // 
            this.RegAndCancelPanel.Controls.Add(this.RegAndCancelUC);
            this.RegAndCancelPanel.Location = new System.Drawing.Point(0, 62);
            this.RegAndCancelPanel.Name = "RegAndCancelPanel";
            this.RegAndCancelPanel.Size = new System.Drawing.Size(330, 62);
            this.RegAndCancelPanel.TabIndex = 1;
            // 
            // WarningMessagePanel
            // 
            this.WarningMessagePanel.Controls.Add(this.WarningMsgUC);
            this.WarningMessagePanel.Location = new System.Drawing.Point(0, 0);
            this.WarningMessagePanel.Name = "WarningMessagePanel";
            this.WarningMessagePanel.Size = new System.Drawing.Size(300, 52);
            this.WarningMessagePanel.TabIndex = 2;
            // 
            // RegAndCancelUC
            // 
            this.RegAndCancelUC.Location = new System.Drawing.Point(0, 0);
            this.RegAndCancelUC.Name = "RegAndCancelUC";
            this.RegAndCancelUC.Size = new System.Drawing.Size(330, 62);
            this.RegAndCancelUC.TabIndex = 0;
            // 
            // WarningUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WarningMessagePanel);
            this.Controls.Add(this.RegAndCancelPanel);
            this.Name = "WarningUC";
            this.Size = new System.Drawing.Size(330, 124);
            this.RegAndCancelPanel.ResumeLayout(false);
            this.WarningMessagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel RegAndCancelPanel;
        private System.Windows.Forms.Panel WarningMessagePanel;
        private System.Windows.Forms.Button UnlockBtn;
        private RegAndCancelUC RegAndCancelUC;
        private WarningMsg WarningMsgUC;
    }
}
