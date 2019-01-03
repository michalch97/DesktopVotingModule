using DesktopVotingModuleModel;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopVotingModuleViewModel
{
    public class GetVote : ICommand
    {
        private VoteViewModel viewModel;

        public GetVote(VoteViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (viewModel.SelectedVote != null)
            {
                Vote tmpVote = VotesSingleton.voteCollection.Where(x => x.Name == viewModel.SelectedVote.Name).FirstOrDefault();
                CandidatesSingleton.candidatesCollection.Add(tmpVote.Candidates);
                VotesSingleton.VoteName = viewModel.SelectedVote.Name;
            }

            viewModel.GetVote();
        }

        public event EventHandler CanExecuteChanged;
    }
}