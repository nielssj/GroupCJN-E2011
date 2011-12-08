namespace DigitalVoterList.PollingTable.Log
{
    partial class LogWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.logsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.activityBox = new System.Windows.Forms.ComboBox();
            this.cprBox = new System.Windows.Forms.TextBox();
            this.tableBox = new System.Windows.Forms.TextBox();
            this.idBox = new System.Windows.Forms.TextBox();
            this.timeTo = new System.Windows.Forms.DateTimePicker();
            this.timeFrom = new System.Windows.Forms.DateTimePicker();
            this.refreshButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cprDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeDataGridViewTextBoxColumn,
            this.tableDataGridViewTextBoxColumn,
            this.cprDataGridViewTextBoxColumn,
            this.activityDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.logsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(15, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(548, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // logsBindingSource
            // 
            this.logsBindingSource.DataSource = typeof(DBComm.DBComm.DO.LogDO);
            // 
            // activityBox
            // 
            this.activityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activityBox.FormattingEnabled = true;
            this.activityBox.Items.AddRange(new object[] {
            "",
            "W",
            "R"});
            this.activityBox.Location = new System.Drawing.Point(482, 49);
            this.activityBox.Name = "activityBox";
            this.activityBox.Size = new System.Drawing.Size(65, 21);
            this.activityBox.TabIndex = 2;
            // 
            // cprBox
            // 
            this.cprBox.Location = new System.Drawing.Point(357, 49);
            this.cprBox.Name = "cprBox";
            this.cprBox.Size = new System.Drawing.Size(96, 20);
            this.cprBox.TabIndex = 3;
            // 
            // tableBox
            // 
            this.tableBox.Location = new System.Drawing.Point(259, 49);
            this.tableBox.Name = "tableBox";
            this.tableBox.Size = new System.Drawing.Size(93, 20);
            this.tableBox.TabIndex = 4;
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(57, 49);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(96, 20);
            this.idBox.TabIndex = 6;
            // 
            // timeTo
            // 
            this.timeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeTo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timeTo.Location = new System.Drawing.Point(159, 62);
            this.timeTo.Name = "timeTo";
            this.timeTo.ShowUpDown = true;
            this.timeTo.Size = new System.Drawing.Size(95, 20);
            this.timeTo.TabIndex = 7;
            // 
            // timeFrom
            // 
            this.timeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timeFrom.Location = new System.Drawing.Point(159, 36);
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.ShowUpDown = true;
            this.timeFrom.Size = new System.Drawing.Size(95, 20);
            this.timeFrom.TabIndex = 8;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(467, 14);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(386, 14);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 10;
            this.resetButton.Text = "Reset filters";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.refreshButton);
            this.groupBox1.Controls.Add(this.resetButton);
            this.groupBox1.Location = new System.Drawing.Point(15, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 86);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            dataGridViewCellStyle2.Format = "MM/dd-yyyy HH:mm:ss";
            dataGridViewCellStyle2.NullValue = null;
            this.timeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeDataGridViewTextBoxColumn.Width = 126;
            // 
            // tableDataGridViewTextBoxColumn
            // 
            this.tableDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tableDataGridViewTextBoxColumn.DataPropertyName = "Table";
            this.tableDataGridViewTextBoxColumn.HeaderText = "Table";
            this.tableDataGridViewTextBoxColumn.Name = "tableDataGridViewTextBoxColumn";
            this.tableDataGridViewTextBoxColumn.ReadOnly = true;
            this.tableDataGridViewTextBoxColumn.Width = 126;
            // 
            // cprDataGridViewTextBoxColumn
            // 
            this.cprDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cprDataGridViewTextBoxColumn.DataPropertyName = "Cpr";
            this.cprDataGridViewTextBoxColumn.HeaderText = "Cpr";
            this.cprDataGridViewTextBoxColumn.Name = "cprDataGridViewTextBoxColumn";
            this.cprDataGridViewTextBoxColumn.ReadOnly = true;
            this.cprDataGridViewTextBoxColumn.Width = 126;
            // 
            // activityDataGridViewTextBoxColumn
            // 
            this.activityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.activityDataGridViewTextBoxColumn.DataPropertyName = "Activity";
            this.activityDataGridViewTextBoxColumn.HeaderText = "Activity";
            this.activityDataGridViewTextBoxColumn.Name = "activityDataGridViewTextBoxColumn";
            this.activityDataGridViewTextBoxColumn.ReadOnly = true;
            this.activityDataGridViewTextBoxColumn.Width = 126;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(15, 450);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 42);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total No. Votes";
            // 
            // LogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 504);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.timeFrom);
            this.Controls.Add(this.timeTo);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.tableBox);
            this.Controls.Add(this.cprBox);
            this.Controls.Add(this.activityBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "LogWindow";
            this.Text = "LogWindow";
            this.Load += new System.EventHandler(this.LogWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource logsBindingSource;
        private System.Windows.Forms.ComboBox activityBox;
        private System.Windows.Forms.TextBox cprBox;
        private System.Windows.Forms.TextBox tableBox;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.DateTimePicker timeTo;
        private System.Windows.Forms.DateTimePicker timeFrom;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cprDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}