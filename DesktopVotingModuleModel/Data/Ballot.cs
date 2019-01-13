using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesktopVotingModuleModel
{
    public class Ballot
    {
        private int id;
        private string name;
        private string candidatesSize;
        private bool state;
        private Candidate selectedCandidate;
        public ObservableCollection<Candidate> candidates;

        public int Id
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
        }
        public string CandidatesSize
        {
            get { return candidatesSize; }
        }
        public bool State
        {
            get { return state; }
        }
        public Candidate SelectedCandidate
        {
            get { return selectedCandidate; }
            set { selectedCandidate = value; }
        }

        public string StateToString
        {
            get
            {
                return state ? "Otwarte" : "Zamkniętę";
            }
        }

        public Ballot(int id, string name, string candidatesSize, bool state)
        {
            this.id = id;
            this.name = name;
            this.candidatesSize = candidatesSize;
            this.state = state;
            candidates = new ObservableCollection<Candidate>();
        }
    }
}