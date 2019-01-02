using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DesktopVotingModuleModel;

namespace DesktopVotingModuleViewModel
{
    public class VoteViewModel
    {
        private User user;
        private Ballot ballot;
        private Candidate selectedCandidate;
        private Vote selectedVote;
        private ObservableCollection<Vote> votesCollection;

        
        public Vote SelectedVote { get => selectedVote; set => selectedVote = value; }
        
        public ObservableCollection<Vote> VotesCollection { get => votesCollection; set => votesCollection = value; }


        public VoteViewModel()
        {
            user = PageController.User;
            //ballot = Task.Run(async () => { return await API.GetBallots(user); }).Result;
            //CandidatesSingleton.candidatesCollection = Task.Run(async () => { return await API.GetCandidateNamesForBallot(ballot, user); }).Result;
            //candidatesCollection = CandidatesSingleton.candidatesCollection;
            VotesCollection = VotesSingleton.voteCollection;
        }

        public ICommand BackToStartPageCommand
        {
            get
            {
                return new BackToStartPage(this);
            }
        }

        public void Back()
        {
            PageController.PageSource = "MenuPage.xaml";
        }

        public ICommand GetVoteCommand
        {
            get
            {
                return new GetVote(this);
            }
        }

        public void GetVote()
        {
            PageController.PageSource = "VotingPage.xaml";
        }
    }
}

