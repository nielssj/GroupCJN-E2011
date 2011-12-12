﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DigitalVoterList.PollingTable;


namespace DigitalVoterList
{
    public partial class SetupWindow : Form
    {
        private SetupInfo si;

        public SetupWindow(SetupInfo si)
        {
            InitializeComponent();

            this.si = si;

            ipTextBox.Text = this.si.Ip;
            tableBox.Text = this.si.TableNo.ToString();
        }

        public SetupWindow()
        {
            this.InitializeComponent();
        }

        private void Form1_Closed()
        {
            Application.Exit();
        }
    }
}
