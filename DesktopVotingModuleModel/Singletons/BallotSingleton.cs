using System.Collections.ObjectModel;

namespace DesktopVotingModuleModel
{
    public class BallotSingleton
    {
        public static ObservableCollection<Ballot> ballots;
        public static Ballot selectedBallot;

        public static BallotSingleton Instance { get; }
        static BallotSingleton()
        {
            ballots = new ObservableCollection<Ballot>();
            selectedBallot = new Ballot();
            Instance = new BallotSingleton();
        }
    }
}