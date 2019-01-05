using DesktopVotingModuleModel;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class SelectVote : ICommand
    {
        private VoteViewModel viewModel;

        public SelectVote(VoteViewModel viewModel)
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
            if (viewModel.SelectedBallot != null && viewModel.SelectedBallot.SelectedCandidate == null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            Task.Run(async () => { await viewModel.GetVote(); });
        }

        public event EventHandler CanExecuteChanged;
    }
}