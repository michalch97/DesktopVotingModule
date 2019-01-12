using System;
using System.Windows.Input;
using DesktopVotingModuleModel;

namespace DesktopVotingModuleViewModel
{
    public class BackToVoteSelectPage : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BallotSingleton.selectedBallot = new Ballot(0, null, null, false);
            PageSingleton.PageSource = "Pages/VoteSelectPage.xaml";
        }

        public event EventHandler CanExecuteChanged;
    }
}