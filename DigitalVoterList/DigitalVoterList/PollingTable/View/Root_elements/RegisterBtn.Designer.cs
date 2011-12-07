namespace DigitalVoterList.PollingTable.View.Root_elements
{
    partial class RegisterBtn
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
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.LightGreen;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.Location = new System.Drawing.Point(0, 0);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(162, 62);
            this.registerButton.TabIndex = 21;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;
            // 
            // RegisterBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.registerButton);
            this.Name = "RegisterBtn";
            this.Size = new System.Drawing.Size(162, 62);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button registerButton;

    }
}
