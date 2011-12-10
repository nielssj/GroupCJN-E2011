
namespace DigitalVoterList.Test
{
    using System;
    using System.Collections.Generic;
    using DigitalVoterList.Central.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MVCTest
    {
        private Model model;
        

        [TestInitialize]
        public void SetUp()
        {
            this.model = new Model();

            this.model.OpenSubModel(Model.ChangeType.VCG);
            this.model.OpenSubModel(Model.ChangeType.VBM);
        }

        /// <summary> Test that submodels can be opened and retrieved. </summary>
        [TestMethod]
        public void OpenSubModels()
        {
            IEnumerator<ISubModel> en = this.model.GetSubModels();
            
            en.MoveNext();
            Assert.IsInstanceOfType(en.Current, typeof(VoterCardGenerator));

            en.MoveNext();
            Assert.IsInstanceOfType(en.Current, typeof(VoterBoxManager));

            Assert.IsFalse(en.MoveNext());
        }

        /// <summary> 
        /// Test that submodels can be closed and are gone thereafter. 
        /// </summary>
        [TestMethod]
        public void CloseSubModels()
        {
            IEnumerator<ISubModel> en = this.model.GetSubModels();
            en.MoveNext();
            ISubModel vcg = en.Current;

            this.model.CloseSubModel(vcg);

            en = this.model.GetSubModels();
            en.MoveNext();
            Assert.IsInstanceOfType(en.Current, typeof(VoterBoxManager));
            Assert.IsFalse(en.MoveNext());
        }

        /// <summary>
        /// Test that subscribers are notified when submodels are opened.
        /// </summary>
        [TestMethod]
        public void OpenNotifications()
        {
            // Subscribe to open events.
            int opens = 0;
            this.model.SubModelOpened += (t, m) => opens++;
            int closes = 0;
            this.model.SubModelClosed += m => closes++;

            // Open some submodels.
            this.model.OpenSubModel(Model.ChangeType.VCG);  // Open
            Assert.IsTrue(opens == 1);                      // Was I notified?

            this.model.OpenSubModel(Model.ChangeType.VBM);  // Open
            Assert.IsTrue(opens == 2);                      // Was I notified?
        }

        /// <summary>
        /// Test that subscribers are notified when submodels are closed.
        /// </summary>
        [TestMethod]
        public void CloseNotifications()
        {
            // Subscribe to close events.
            int closes = 0;
            this.model.SubModelClosed += m => closes++;

            // Retrieve submodels.
            IEnumerator<ISubModel> en = this.model.GetSubModels();
            en.MoveNext();
            ISubModel sm1 = en.Current;
            en.MoveNext();
            ISubModel sm2 = en.Current;

            // Close them.
            this.model.CloseSubModel(sm1);           // Close
            Assert.IsTrue(closes == 1);              // Was I notified?
            
            this.model.CloseSubModel(sm2);           // CLose
            Assert.IsTrue(closes == 2);              // Was I notified?
        }
    }
}
