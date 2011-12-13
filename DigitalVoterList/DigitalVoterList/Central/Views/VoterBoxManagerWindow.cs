using System;
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

        public string Address
        {
            get
            {
                return adressTB.Text;
            }
        }

        public string Port
        {
            get
            {
                return portBox.Text;
            }
        }

        public string User
        {
            get
            {
                return userBox.Text;
            }
        }

        public string Password
        {
            get
            {
                return pwBox.Text;
            }
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

        public delegate void ButtonHandler();

        public void AddValidateHandler(ButtonHandler h)
        {
            this.validateButton.Click += (o, eA) => h();
        }

        public void AddUploadHandler(ButtonHandler h)
        {
            this.uploadButton.Click += (o, eA) => h();
        }

        public void AddConnectHandler(ButtonHandler h)
        {
            this.connectButton.Click += (o, eA) => h();
        }

        public void UpdateProgress()
        {
            this.progressBar1.PerformStep();
        }

        public void UpdateProgressText(string text)
        {
            this.progressTF.Text += text + Environment.NewLine;
            this.progressTF.SelectionStart = this.progressTF.Text.Length;
            this.progressTF.ScrollToCaret();
        }
    }
}
