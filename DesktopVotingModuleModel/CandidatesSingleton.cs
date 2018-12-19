using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVotingModuleModel
{
    public class CandidatesSingleton
    {
        public static ObservableCollection<Candidate> candidatesCollection;

        public static CandidatesSingleton Instance { get; }
        static CandidatesSingleton()
        {
            candidatesCollection = new ObservableCollection<Candidate>();
            Instance = new CandidatesSingleton();
        }
    }
}