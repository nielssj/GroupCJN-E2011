namespace DigitalVoterList.Central.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VoterSelection
    {
        private int voterCount;
        private List<string> pollingStations;
        private List<string> municipalities;
        private VoterFilter currentFilter;

        /// <summary> Initializes a new instance of the <see cref="VoterSelection"/> class with prober values for the default selection. </summary>
        public VoterSelection()
        {
            // Call database to get initial values (no selection, ie. entire DB)
            voterCount = 42;
            pollingStations = new List<string>() { "All", "Nørrebrohallen", "Holbergskolen" };
            municipalities = new List<string>() { "All", "Sorø Kommune", "Københavns Kommune" };
            currentFilter = new VoterFilter();
        }

        public delegate void VoterCountHandler(int VoterCount);
        public delegate void PollingStationsHandler(List<String> pollingStations);

        ///<summary> Notify me when the number of voters in the selection changes. </summary>
        public event VoterCountHandler VoterCountChanged;

        /// <summary> Notify me when the available polling station changes. </summary>
        public event PollingStationsHandler PollingStationsChanged;

        /// <summary> What is the number of selected voters? </summary>
        public int VoterCount
        {
            // Set the voter count and notify subscribers.
            private set
            {
                voterCount = value;
                VoterCountChanged(voterCount);
            }
            get
            {
                return voterCount;
            }
        }

        /// <summary> What are the available polling stations? </summary>
        public List<String> PollingStations
        {
            // Set the polling stations and notify subscribers.
            private set
            {
                pollingStations = value;
                PollingStationsChanged(pollingStations);
            }
            get
            {
                return pollingStations;
            }
        }

        /// <summary> What are the available municipalities? </summary>
        public List<String> Municipalities
        {
            get
            {
                return municipalities;
            }
        }

        /// <summary> What is the current filter? </summary>
        public VoterFilter CurrentFilter
        {
            get
            {
                return currentFilter;
            }
        }

        /// <summary> Replace the current voter filter with this voter fitler. </summary>
        public void ReplaceFilter(VoterFilter filter)
        {
            // Get the new selected voter count and available polling stations from Database.
            VoterCount = 999; //<-- DATABASE INPUT EVENTUALLY
            PollingStations = new List<String>(); //<-- DATABASE INPUT EVENTUALLY

            // And finally, replace the filter
            currentFilter = filter;
        }

    }
}