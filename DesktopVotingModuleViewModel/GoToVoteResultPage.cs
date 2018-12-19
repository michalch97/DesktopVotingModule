using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class GoToVoteResultPage : ICommand
    {
        private MenuViewModel viewModel;
        public GoToVoteResultPage(MenuViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.VoteResultPage();
        }

        public event EventHandler CanExecuteChanged;
    }
}