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
            BallotSingleton.selectedBallot = new Ballot();
            PageSingleton.PageSource = "Pages/VoteSelectPage.xaml";
        }

        public event EventHandler CanExecuteChanged;
    }
}