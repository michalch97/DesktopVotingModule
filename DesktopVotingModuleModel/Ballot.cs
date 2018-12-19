using System.Collections.Generic;

namespace DesktopVotingModuleModel
{
    public class Ballot
    {
        public bool state;
        public string candidatesSize;
        public int id;
        public List<Candidate> candidates;

        public Ballot()
        {
            candidates = new List<Candidate>();
        }
    }
}