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
        /// <summary> Voter Selection View (Abbreviated VS) </summary>
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

        public delegate void ViewChangedHandler(Model.ChangeType type, ISubModel model, ISubView view);

        /// <summary> Notify me when a submodel has been opened. </summary>
        public event ViewChangedHandler SubViewOpened;

        public VoterSelectionWindow VoterSelectionView { get { return vsView; } }

        private void OpenView(Model.ChangeType type, ISubModel model)
        {
            switch(type)
            {
                case Model.ChangeType.VCG :
                    OpenVCGView((VoterCardGenerator) model);
                    break;
                case Model.ChangeType.VBM :
                    OpenVBMView((VoterBoxManager) model);
                    break;
            }
        }

        private void OpenVCGView(VoterCardGenerator vcg)
        {
            var vcgWindow = new VoterCardGeneratorWindow(vcg);
            SubViewOpened(Model.ChangeType.VCG, vcg, vcgWindow);
        }

        private void OpenVBMView(VoterBoxManager vbm)
        {
            var vbmWindow = new VoterBoxManagerWindow(vbm);
            SubViewOpened(Model.ChangeType.VBM, vbm, vbmWindow);
        }
    }
}
