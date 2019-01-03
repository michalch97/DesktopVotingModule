using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVotingModuleModel
{
    public class Vote
    {
        public string Name { get; set; }
        public ObservableCollection<Candidate> Candidates { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isVoted { get; set; }
        public Candidate votedCandidate { get; set; }


        public Vote(string name, ObservableCollection<Candidate> candidates, DateTime start, DateTime end)
        {
            this.Name = name;
            this.Candidates = candidates;
            this.StartDate = start;
            this.EndDate = end;
            this.isVoted = false;
            this.votedCandidate = null;
        }

        public Vote()
        {
            this.Name = "Głosowanie";
        }

        public void setVotedCandidate(Candidate candidate)
        {
            this.isVoted = true;
            this.votedCandidate = candidate;
        }

        public void clearVotedCandidate()
        {
            this.isVoted = false;
            this.votedCandidate = null;
        }
    }
}
