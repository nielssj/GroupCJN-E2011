namespace DigitalVoterList
{
    using DigitalVoterList.PollingTable.View.Root_elements;

    partial class UnRegAndCancelUC
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
            this.unregPanel = new System.Windows.Forms.Panel();
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
            // unregPanel
            // 
            this.unregPanel.Location = new System.Drawing.Point(0, 0);
            this.unregPanel.Name = "unregPanel";
            this.unregPanel.Size = new System.Drawing.Size(162, 62);
            this.unregPanel.TabIndex = 2;
            this.unregPanel.Controls.Add(new UnRegBtn());
            // 
            // UnRegAndCancelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelPanel);
            this.Controls.Add(this.unregPanel);
            this.Name = "UnRegAndCancelUC";
            this.Size = new System.Drawing.Size(330, 62);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel cancelPanel;
        private System.Windows.Forms.Panel unregPanel;
    }
}
