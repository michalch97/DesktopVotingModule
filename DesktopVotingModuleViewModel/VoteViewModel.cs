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
        private ObservableCollection<Candidate> candidatesCollection;

        public Candidate SelectedCandidate { get => selectedCandidate; set => selectedCandidate = value; }
        public ObservableCollection<Candidate> CandidatesCollection { get => candidatesCollection; set => candidatesCollection = value; }


        public VoteViewModel()
        {
            user = PageController.User;
            ballot = Task.Run(async () => {return await API.GetBallots(user); }).Result;
            CandidatesSingleton.candidatesCollection = Task.Run(async () => { return await API.GetCandidateNamesForBallot(ballot, user); }).Result;
            //ballot.candidates = candidatesCollection.ToList();
            candidatesCollection = CandidatesSingleton.candidatesCollection;
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
        }
    }
}
