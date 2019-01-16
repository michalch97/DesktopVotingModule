using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DesktopVotingModuleModel;
using DesktopVotingModuleViewModel.Annotations;

namespace DesktopVotingModuleViewModel
{
    public class VoteCandidateViewModel : INotifyPropertyChanged
    {
        private User user;
        private Ballot ballot;
        private ObservableCollection<Candidate> candidates;
        private Candidate selectedCandidate;


        public Candidate SelectedCandidate
        {
            get { return selectedCandidate; }
            set
            {
                selectedCandidate = value;
                this.OnPropertyChanged("SelectedCandidate");
            }
        }
        public string BallotName
        {
            get { return ballot.Name; }
        }

        public ObservableCollection<Candidate> Candidates
        {
            get { return candidates; }
            set { candidates = value; }
        }

        public VoteCandidateViewModel()
        {
            user = UserSingleton.user;
            ballot = BallotSingleton.selectedBallot;
            Candidates = ballot.candidates;
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
            ballot.SelectedCandidate = SelectedCandidate;
            bool voteStatus = await API.Vote(ballot, ballot.SelectedCandidate, user);

            if (voteStatus)
                PageSingleton.AfterVoteText = "Dziękujemy za oddanie głosu!";
            else
                PageSingleton.AfterVoteText = "Błąd! Ponowne oddanie głosu!";

            PageSingleton.PageSource = "Pages/AfterVotePage.xaml";
        }

        public ICommand GoToVoteSelectCommand
        {
            get
            {
                return new GoTo(VoteSelectPage);
            }
        }

        public void VoteSelectPage()
        {
            PageSingleton.PageSource = "Pages/VoteSelectPage.xaml";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

