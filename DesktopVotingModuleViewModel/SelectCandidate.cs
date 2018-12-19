using DesktopVotingModuleModel;
using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class SelectCandidate : ICommand
    {
        private VoteViewModel viewModel;
        public SelectCandidate(VoteViewModel viewModel, Candidate SelectedCandidate)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Vote();
        }

        public event EventHandler CanExecuteChanged;
    }
}