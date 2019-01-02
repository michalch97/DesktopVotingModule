using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class GoToVoteSelectPage : ICommand
    {
        private VoteCandidateViewModel viewModel;
        public GoToVoteSelectPage(VoteCandidateViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Back();
        }

        public event EventHandler CanExecuteChanged;
    }
}