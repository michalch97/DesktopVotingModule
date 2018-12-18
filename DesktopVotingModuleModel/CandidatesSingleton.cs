using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace DesktopVotingModuleModel
{
    public class CandidatesSingleton
    {
        public static ObservableCollection<Candidate> candidatesCollection = new ObservableCollection<Candidate>();

        public static CandidatesSingleton Instance { get; }
        static CandidatesSingleton()
        {
            Candidate c1 = new Candidate("Pawel Ciupka", 1);
            Candidate c2 = new Candidate("Michal Chmielewski", 2);
            candidatesCollection.Add(c1);
            candidatesCollection.Add(c2);

            Instance = new CandidatesSingleton();

        }
    }
}