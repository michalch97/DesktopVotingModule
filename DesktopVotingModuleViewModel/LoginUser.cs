using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class LoginUser : ICommand
    {
        private LoginViewModel viewModel;
        public LoginUser(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.GetPassword(parameter);
            Task.Run(async () => { await viewModel.Authorize(); });
        }

        public event EventHandler CanExecuteChanged;
    }
}