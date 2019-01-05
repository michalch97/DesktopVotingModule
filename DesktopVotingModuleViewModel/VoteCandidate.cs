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
            this.viewModel.PropertyChanged += (s, e) =>
            {
                if (this.CanExecuteChanged != null)
                {
                    this.CanExecuteChanged(this, new EventArgs());
                }
            };
        }
        public bool CanExecute(object parameter)
        {
            return viewModel.SelectedCandidate != null;
        }

        public void Execute(object parameter)
        {
            Task.Run(async () => { await viewModel.Vote(); });
        }

        public event EventHandler CanExecuteChanged;
    }
}