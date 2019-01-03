using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class GoToVotePage : ICommand
    {
        public GoToVotePage()
        {

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PageController.PageSource = "VoteSelectPage.xaml";
        }

        public event EventHandler CanExecuteChanged;
    }
}