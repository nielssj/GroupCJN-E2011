namespace DigitalVoterList.Central.Controllers
{
    using System.Collections.Generic;

    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;

    /// <summary>
    /// The main 'controller' of the application. 
    /// It has the sole responsibility of instantiating instances of the sub-controllers.
    /// </summary>
    public class Controller
    {
        private readonly Model model;
        private readonly View view;
        
        /// <summary> Voter Selection Controller (Abbreviated VS) </summary>
        private VoterSelectionController vsController;

        /// <summary> Initializes a new instance of the <see cref="Controller"/> class. </summary>
        /// <param name="model">The model object to rebort to.</param>
        /// <param name="view">The view to listen to.</param>
        public Controller(Model model, View view)
        {
            this.model = model;
            this.view = view;

            // Subscribe to View.
            view.SubViewOpened += ViewOpened;

            this.InitDefault();
        }

        /// <summary> React to a request for a view to be opened; 
        /// Instantiate an appropiate controller. </summary>
        /// <param name="type">The type of view to be opened.</param>
        /// <param name="subModel">The model to be used.</param>
        /// <param name="subView">The View to be used.</param>
        public void ViewOpened(Model.ChangeType type, ISubModel subModel, ISubView subView)
        {
            switch(type)
            {
                case Model.ChangeType.VCG :
                    var vcgModel = (VoterCardGenerator)subModel;
                    var vcgView = (VoterCardGeneratorWindow)subView;
                    vcgView.AddClosingHandler((o, eA) => this.model.CloseVCG(vcgModel));  // Remove references to model upon closing.
                    new VoterCardGeneratorController(vcgModel, vcgView); // Instantiate controller
                    break;
                case Model.ChangeType.VBM :
                    var vbmModel = (VoterBoxManager)subModel;
                    var vbmView = (VoterBoxManagerWindow)subView;
                    vbmView.AddClosingHandler((o, eA) => this.model.CloseVBM(vbmModel));
                    new VoterBoxManagerController(vbmModel, vbmView);
                    break;
            }
        }

        // Initiate default sub-controller.
        private void InitDefault()
        {
            VoterSelectionWindow vsView = view.VoterSelectionView;
            vsView.AddVCGClickedHandler(model.OpenVCG);
            vsView.AddVBMClickedHandler(model.OpenVBM);
            vsController = new VoterSelectionController(model.VoterSelection, view.VoterSelectionView);
        }
    }
}
