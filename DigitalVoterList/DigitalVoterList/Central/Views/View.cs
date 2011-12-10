namespace DigitalVoterList.Central.Views
{
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

        private void OpenView(Model.ChangeType type, ISubModel subModel)
        {
            ISubView subView = null;
            switch(type)
            {
                case Model.ChangeType.VCG :
                    subView = new VoterCardGeneratorWindow((VoterCardGenerator)subModel);
                    break;
                case Model.ChangeType.VBM :
                    subView = new VoterBoxManagerWindow((VoterBoxManager)subModel);
                    break;
            }
            SubViewOpened(type, subModel, subView);
        }
    }
}
