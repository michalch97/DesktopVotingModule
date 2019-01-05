using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVotingModuleModel
{
    public class VotesSingleton
    {
        public static ObservableCollection<Vote> voteCollection;

        public static string VoteName;

        public static VotesSingleton Instance { get; }
        static VotesSingleton()
        {
            voteCollection = new ObservableCollection<Vote>();
            Instance = new VotesSingleton();
        }
    }
}