using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class VoteCandidate : ICommand
    {
        private VoteCandidateViewModel viewModel;
        public VoteCandidate(VoteCandidateViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Task.Run(async () => { await viewModel.Vote(); });
        }

        public event EventHandler CanExecuteChanged;
    }
}