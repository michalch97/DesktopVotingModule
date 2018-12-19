using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class GoToVotePage : ICommand
    {
        private MenuViewModel viewModel;
        public GoToVotePage(MenuViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.VotePage();
        }

        public event EventHandler CanExecuteChanged;
    }
}