using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class VoteCandidate : ICommand
    {
        private VoteViewModel viewModel;
        public VoteCandidate(VoteViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Logic there
        }

        public event EventHandler CanExecuteChanged;
    }
}