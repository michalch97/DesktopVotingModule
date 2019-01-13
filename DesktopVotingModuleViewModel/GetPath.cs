using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.Win32;

namespace DesktopVotingModuleViewModel
{
    public class GetPath : ICommand
    {
        private VoteResultViewModel viewModel;
        public GetPath(VoteResultViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.GetFolderPath();
            Task.Run(async () => { await viewModel.SetPath(); });
        }

        public event EventHandler CanExecuteChanged;
    }
}