using System;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class GoTo : ICommand
    {
        private readonly Action action;

        public GoTo(Action action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public event EventHandler CanExecuteChanged;
    }
}