namespace DigitalVoterList
{
    partial class UnregUC
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
            this.unregAndCancelPanel = new System.Windows.Forms.Panel();
            this.TypeInText = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.WarningMsgPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // unregAndCancelPanel
            // 
            this.unregAndCancelPanel.Location = new System.Drawing.Point(0, 122);
            this.unregAndCancelPanel.Name = "unregAndCancelPanel";
            this.unregAndCancelPanel.Size = new System.Drawing.Size(330, 62);
            this.unregAndCancelPanel.TabIndex = 28;
            this.unregAndCancelPanel.Controls.Add(new UnRegAndCancelUC());
            // 
            // TypeInText
            // 
            this.TypeInText.AutoSize = true;
            this.TypeInText.Location = new System.Drawing.Point(3, 55);
            this.TypeInText.Name = "TypeInText";
            this.TypeInText.Size = new System.Drawing.Size(170, 13);
            this.TypeInText.TabIndex = 27;
            this.TypeInText.Text = "Type in the administrator password";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(330, 45);
            this.textBox1.TabIndex = 26;
            // 
            // WarningMsgPanel
            // 
            this.WarningMsgPanel.Location = new System.Drawing.Point(0, 0);
            this.WarningMsgPanel.Name = "WarningMsgPanel";
            this.WarningMsgPanel.Size = new System.Drawing.Size(330, 52);
            this.WarningMsgPanel.TabIndex = 25;
            this.WarningMsgPanel.Controls.Add(new WarningUC());
            // 
            // UnregUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unregAndCancelPanel);
            this.Controls.Add(this.TypeInText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.WarningMsgPanel);
            this.Name = "UnregUC";
            this.Size = new System.Drawing.Size(330, 188);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel unregAndCancelPanel;
        private System.Windows.Forms.Label TypeInText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel WarningMsgPanel;
    }
}
