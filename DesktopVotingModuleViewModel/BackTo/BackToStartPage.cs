using System;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;
using DesktopVotingModuleModel;

namespace DesktopVotingModuleViewModel
{
    public class BackToStartPage : ICommand
    {
        public BackToStartPage()
        {

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            UserSingleton.user = new User();
            BallotSingleton.selectedBallot = new Ballot();
            BallotSingleton.ballots = new ObservableCollection<Ballot>();
            PageSingleton.PageSource = "Pages/MenuPage.xaml";
        }

        public event EventHandler CanExecuteChanged;
    }
}