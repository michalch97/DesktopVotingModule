using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesktopVotingModuleModel
{
    public class Ballot
    {
        public bool state;
        public string candidatesSize;
        public int id;
        public ObservableCollection<Candidate> candidates;
        public string name;
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
            name = "Domyślna nazwa";
            candidates = new ObservableCollection<Candidate>();
            EndDate = DateTime.Now;
        }
    }
}