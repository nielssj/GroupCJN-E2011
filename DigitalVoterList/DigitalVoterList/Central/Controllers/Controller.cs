namespace DigitalVoterList.Central.Controllers
{
    using System.Collections.Generic;

    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;

    /// <summary>
    /// The main 'controller' of the application. 
    /// It has the sole responsibility of managing instances of the sub-controllers.
    /// </summary>
    public class Controller
    {
        /// <summary> Voter Card Generator Controllers (Abbreviated VCG) </summary>
        private List<VoterCardGeneratorController> vcgControllers = new List<VoterCardGeneratorController>();
        /// <summary> Voter Box Manager Controllers (Abbreviated VBM) </summary>
        private List<VoterBoxManagerController> vbmControllers = new List<VoterBoxManagerController>();
        /// <summary> Voter Selection Controller (Abbreviated VS) </summary>
        private VoterSelectionController vsController;

        private Model model;
        private View view;

        /// <summary> Initializes a new instance of the <see cref="Controller"/> class. </summary>
        /// <param name="model">The model object to rebort to.</param>
        /// <param name="view">The view to listen to.</param>
        public Controller(Model model, View view)
        {
            this.model = model;
            this.view = view;

            // Subscribe to View.
            view.SubViewOpened += ViewOpened;

            // Initiate default sub-controller.
            VoterSelectionWindow vsView = view.VoterSelectionView;
            vsView.AddVCGClickedHandler(model.OpenVCG);
            vsController = new VoterSelectionController(model.VoterSelection, view.VoterSelectionView);
        }

        public void ViewOpened(Model.ChangeType type, ISubModel model, ISubView view)
        {
            switch(type)
            {
                case Model.ChangeType.VCG :
                    var vcgModel = (VoterCardGenerator)model;
                    var vcgView = (VoterCardGeneratorWindow)view;
                    vcgControllers.Add(new VoterCardGeneratorController(vcgModel, vcgView));
                    break;
            }
        }
    }
}
