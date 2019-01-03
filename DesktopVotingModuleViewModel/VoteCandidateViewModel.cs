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
    public class VoteCandidateViewModel
    {
        private User user;
        private Ballot ballot;
        private Candidate selectedCandidate;
        private ObservableCollection<Candidate> candidatesCollection;
        private string voteName { get; set; }


        public Candidate SelectedCandidate { get => selectedCandidate; set => selectedCandidate = value; }

        public ObservableCollection<Candidate> CandidatesCollection { get => candidatesCollection; set => candidatesCollection = value; }
        public string VoteName { get => voteName; set => voteName = value; }



        public VoteCandidateViewModel()
        {
            user = PageController.User;
            VoteName = VotesSingleton.VoteName;
            if (CandidatesSingleton.candidatesCollection.Count > 0)
            {
                CandidatesCollection = CandidatesSingleton.candidatesCollection.Last();
            }
        }

        public ICommand VoteCandidateCommand
        {
            get
            {
                return new VoteCandidate(this);
            }
        }

        public async Task Vote()
        {
            await API.Vote(ballot, selectedCandidate, user);
            PageController.PageSource = "AfterVotePage.xaml";
        }

        public ICommand GoToVoteSelectCommand
        {
            get
            {
                return new GoToVoteSelectPage(this);
            }
        }

        public async Task Back()
        {
            PageController.PageSource = "VoteSelectPage.xaml";
        }

    }
}

