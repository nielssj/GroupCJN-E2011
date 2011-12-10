namespace DigitalVoterList.Central.Models
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// The main 'model' of the application. 
    /// It has the sole responsibility of managing instances of the sub-models.
    /// </summary>
    public class Model
    {
        private readonly VoterSelection voterSelection = new VoterSelection();
        private readonly List<ISubModel> subModels = new List<ISubModel>();

        public delegate void ModelChangedHandler(ChangeType type, ISubModel model);

        /// <summary> Notify me when a submodel has been opened. </summary>
        public event ModelChangedHandler SubModelOpened;

        /// <summary> Describes a kind of sub-model. </summary>
        public enum ChangeType { VCG, VBM };

        /// <summary> May I have the voter selection model? </summary>
        public VoterSelection VoterSelection { get { return voterSelection; } }

        /// <summary>
        /// Open a new submodel of a given type.
        /// </summary>
        /// <param name="type">The type of submodel to be opened.</param>
        public void OpenSubModel(ChangeType type)
        {
            ISubModel subModel = null;
            switch(type)
            {
                case ChangeType.VCG:
                    subModel = new VoterCardGenerator(VoterSelection.CurrentFilter);
                    break;
                case ChangeType.VBM:
                    subModel = new VoterBoxManager(VoterSelection.CurrentFilter);
                    break;
            }
            this.subModels.Add(subModel);
            SubModelOpened(type, subModel);
        }

        /// <summary>
        /// Close this submodel.
        /// </summary>
        /// <param name="subModel">The submodel to be closed.</param>
        public void CloseSubModel(ISubModel subModel)
        {
            this.subModels.Remove(subModel);
        }
    }
}
