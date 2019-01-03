using DesktopVotingModuleModel;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class SelectVoteResult : ICommand
    {
        private VoteResultViewModel viewModelResult;
        
        public SelectVoteResult(VoteResultViewModel viewModelResult)
        {
            this.viewModelResult = viewModelResult;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModelResult.GetVoteResult();
        }

        public event EventHandler CanExecuteChanged;
    }
}