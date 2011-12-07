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
            this.RegAndCancelPanel = new System.Windows.Forms.Panel();
            this.warningMessagePanel = new System.Windows.Forms.Panel();
            this.UnlockBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RegAndCancelPanel
            // 
            this.RegAndCancelPanel.Location = new System.Drawing.Point(0, 62);
            this.RegAndCancelPanel.Name = "RegAndCancelPanel";
            this.RegAndCancelPanel.Size = new System.Drawing.Size(330, 62);
            this.RegAndCancelPanel.TabIndex = 1;

            //change the colour of the register button to grey.
            RegAndCancelUC RegAndCancel = new RegAndCancelUC();
            RegAndCancel.RegisterBtn.BackColor = System.Drawing.Color.DarkGray;
            this.RegAndCancelPanel.Controls.Add(RegAndCancel);
            // 
            // warningMessagePanel
            // 
            this.warningMessagePanel.Location = new System.Drawing.Point(0, 0);
            this.warningMessagePanel.Name = "warningMessagePanel";
            this.warningMessagePanel.Size = new System.Drawing.Size(300, 52);
            this.warningMessagePanel.TabIndex = 2;
            this.warningMessagePanel.Controls.Add(new WarningMsg());
            // 
            // UnlockBtn
            // 
            this.UnlockBtn.Image = global::DigitalVoterList.Properties.Resources.lock_open;
            this.UnlockBtn.Location = new System.Drawing.Point(300, 0);
            this.UnlockBtn.Name = "UnlockBtn";
            this.UnlockBtn.Size = new System.Drawing.Size(30, 30);
            this.UnlockBtn.TabIndex = 3;
            this.UnlockBtn.UseVisualStyleBackColor = true;
            // 
            // WarningUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UnlockBtn);
            this.Controls.Add(this.warningMessagePanel);
            this.Controls.Add(this.RegAndCancelPanel);
            this.Name = "WarningUC";
            this.Size = new System.Drawing.Size(330, 124);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel RegAndCancelPanel;
        private System.Windows.Forms.Panel warningMessagePanel;
        private System.Windows.Forms.Button UnlockBtn;
    }
}
