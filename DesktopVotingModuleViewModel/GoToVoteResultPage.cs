using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class GoToVoteResultPage : ICommand
    {
        public GoToVoteResultPage()
        {

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PageController.PageSource = "VoteResultSelectPage.xaml";
        }

        public event EventHandler CanExecuteChanged;
    }
}