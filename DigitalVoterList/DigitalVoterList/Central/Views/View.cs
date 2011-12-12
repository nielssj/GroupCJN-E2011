namespace DigitalVoterList.Central.Views
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using DigitalVoterList.Central.Models;

    /// <summary>
    /// The main 'view' of the application. 
    /// It has the sole responsibility of managing instances of the sub-views (windows forms).
    /// </summary>
    public class View
    {
        /// <summary> Voter Selection View (Abbreviated VS) </summary>
        private readonly VoterSelectionWindow vsView;
        /// <summary> Currently open sub-views. </summary>
        private readonly List<ISubView> subViews = new List<ISubView>();

        private Model model;

        public View(Model model)
        {
            this.model = model;

            // Subscribe to changes in the model.
            model.SubModelOpened += this.OpenView;
            model.SubModelClosed += this.CloseView;

            // Initiate default sub-view
            this.vsView = new VoterSelectionWindow(model.VoterSelection);
        }

        public delegate void ViewChangedHandler(Model.ChangeType type, ISubView view);

        /// <summary> Notify me when a submodel has been opened. </summary>
        public event ViewChangedHandler SubViewOpened;

        public VoterSelectionWindow VoterSelectionView { get { return vsView; } }

        /// <summary>
        /// Which sub-views are currently open?
        /// </summary>
        /// <returns>An enumerator of the current sub-views.</returns>
        public IEnumerator<ISubView> GetSubViews()
        {
            return subViews.GetEnumerator();
        }

        private void OpenView(Model.ChangeType type, ISubModel subModel)
        {
            ISubView subView = null;
            switch (type)
            {
                case Model.ChangeType.VCG:
                    subView = new VoterCardGeneratorWindow((VoterCardGenerator)subModel);
                    break;
                case Model.ChangeType.VBM:
                    subView = new VoterBoxManagerWindow((VoterBoxManager)subModel);
                    break;
            }
            subViews.Add(subView);
            if (SubViewOpened != null) SubViewOpened(type, subView);
        }

        private void CloseView(ISubModel subModel)
        {
            ISubView subView = subViews.Find(v => v.GetModel().Equals(subModel));
            subViews.Remove(subView);

            var form = (Form)subView;
            if (!form.Disposing) form.Close();
        }

        public void ShowView()
        {
            this.vsView.Show();
        }
    }
}
