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


        public Vote(string name, ObservableCollection<Candidate> candidates, DateTime start, DateTime end)
        {
            this.Name = name;
            this.Candidates = candidates;
            this.StartDate = start;
            this.EndDate = end;
        }

        public Vote()
        {
            this.Name = "Głosowanie";
        }
    }
}
