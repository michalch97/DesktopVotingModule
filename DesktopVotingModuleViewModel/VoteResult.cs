using System;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class VoteResult : ICommand
    {
        private VoteResultViewModel viewModel;

        public VoteResult(VoteResultViewModel viewModel)
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
            if (viewModel.SelectedBallot != null && !viewModel.SelectedBallot.State)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            this.viewModel.VoteResult();
        }

        public event EventHandler CanExecuteChanged;
    }
}