namespace DigitalVoterList.Central.Views
{
    using System.Collections.Generic;

    using DigitalVoterList.Central.Models;

    /// <summary>
    /// The main 'view' of the application. 
    /// It has the sole responsibility of managing instances of the sub-views (windows forms).
    /// </summary>
    public class View
    {
        /// <summary> Voter Card Generator Views (Abbreviated VCG) </summary>
        private readonly List<VoterCardGeneratorWindow> vcgViews = new List<VoterCardGeneratorWindow>();
        /// <summary> Voter Box Manager Views (Abbreviated VBM) </summary>
        private readonly List<VoterBoxManagerWindow> vbmViews = new List<VoterBoxManagerWindow>();
        /// <summary> Voter Selection Views (Abbreviated VS) </summary>
        private readonly VoterSelectionWindow vsView;

        private Model model;

        public View(Model model)
        {
            this.model = model;
            
            // Subscribe to changes in the model.
            model.SubModelOpened += OpenView;

            // Initiate default sub-view
            this.vsView = new VoterSelectionWindow(model.VoterSelection);
        }

        public VoterSelectionWindow VoterSelectionView { get { return vsView; } }

        public delegate void ViewChangedHandler(Model.ChangeType type, ISubModel model, ISubView view);

        /// <summary> Notify me when a submodel has been opened. </summary>
        public event ViewChangedHandler SubViewOpened;
        /// <summary> Notify me when a submodel has been closed. </summary>
        public event ViewChangedHandler SubViewClosed;

        private void OpenView(Model.ChangeType type, ISubModel model)
        {
            switch(type)
            {
                case Model.ChangeType.VCG :
                    OpenVCGView((VoterCardGenerator) model);
                    break;
            }
        }

        private void OpenVCGView(VoterCardGenerator vcg)
        {
            var vcgWindow = new VoterCardGeneratorWindow(vcg);
            vcgViews.Add(vcgWindow);
            SubViewOpened(Model.ChangeType.VCG, vcg, vcgWindow);
        }
    }
}
