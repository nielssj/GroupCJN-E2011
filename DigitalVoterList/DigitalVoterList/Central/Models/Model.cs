namespace DigitalVoterList.Central.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The main 'model' of the application. 
    /// It has the sole responsibility of managing instances of the sub-models.
    /// </summary>
    public class Model
    {
        private readonly VoterSelection voterSelection = new VoterSelection();
        private readonly List<VoterCardGenerator> voterCardGenerators = new List<VoterCardGenerator>();
        private readonly List<VoterBoxManager> voterBoxManagers = new List<VoterBoxManager>();
        
        public delegate void ModelChangedHandler(ChangeType type, ISubModel model);

        /// <summary> Notify me when a submodel has been opened. </summary>
        public event ModelChangedHandler SubModelOpened;

        /// <summary> Describes what kind of sub-model has been opened. </summary>
        public enum ChangeType { VCG, VBM };

        /// <summary> May I have the voter selection model? </summary>
        public VoterSelection VoterSelection { get { return voterSelection; } }

        /// <summary> 
        /// Open a new 'Voter Card Generator'. 
        /// </summary>
        /// <returns>The new 'Voter Card Generator'.</returns>
        public void OpenVCG(object sender, EventArgs e)
        {
            var vcg = new VoterCardGenerator();
            voterCardGenerators.Add(vcg);
            SubModelOpened(ChangeType.VCG, vcg);
        }
        
        /// <summary>
        /// Close a given 'Voter Card Generator'.
        /// </summary>
        /// <param name="target">The 'Voter Card Generator' to be closed.</param>
        public void CloseVCG(VoterCardGenerator target)
        {
            voterCardGenerators.Remove(target);
        }

        /// <summary>
        /// Open a new 'Voter Box Manager'.
        /// </summary>
        /// <returns>The new 'Voter Box Manager'.</returns>
        public void OpenVBM(object sender, EventArgs e)
        {
            var vbm = new VoterBoxManager(VoterSelection.CurrentFilter);
            voterBoxManagers.Add(vbm);
            SubModelOpened(ChangeType.VBM, vbm);
        }

        /// <summary>
        /// Close a given 'Voter Box Manager'.
        /// </summary>
        /// <param name="target">The 'Voter Box Manager' to be closed.</param>
        public void CloseVBM(VoterBoxManager target)
        {
            voterBoxManagers.Remove(target);
        }
    }
}
