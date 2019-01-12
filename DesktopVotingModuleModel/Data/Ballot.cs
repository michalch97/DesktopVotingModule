using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesktopVotingModuleModel
{
    public class Ballot
    {
        public int id;
        public string name;
        public string candidatesSize;
        public bool state;
        public ObservableCollection<Candidate> candidates;
        
        public Candidate selectedCandidate;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Candidate SelectedCandidate
        {
            get { return selectedCandidate; }
            set { selectedCandidate = value; }
        }

        public DateTime EndDate { get; set; }

        public Ballot()
        {
            candidates = new ObservableCollection<Candidate>();
            EndDate = DateTime.Now;
        }
    }
}