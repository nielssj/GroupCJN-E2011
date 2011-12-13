using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalVoterList.PollingTable.View.Root_elements
{
    public partial class CancelBtn : UserControl
    {
        public CancelBtn()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
            try
            {
                Model.cleanUpDAO();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection lost!");
            }
        }
    }
}
