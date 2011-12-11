using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalVoterList.Central.Views
{
    using DigitalVoterList.Central.Models;

    public partial class VoterBoxManagerWindow : Form, ISubView
    {
        private VoterBoxManager model;

        public VoterBoxManagerWindow(VoterBoxManager model)
        {
            InitializeComponent();

            this.model = model;
        }

        /// <summary> Notify me when the window is closing. </summary>
        /// <param name="handler">The handler to be called upon closing.</param>
        public void AddClosingHandler(Action<ISubModel> handler)
        {
            this.Disposed += (o, eA) => handler(model);
        }

        public ISubModel GetModel()
        {
            return model;
        }
    }
}
