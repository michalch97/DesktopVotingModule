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
    public class VoteViewModel : INotifyPropertyChanged
    {
        private User user;
        private ObservableCollection<Ballot> ballots;
        private Ballot selectedBallot;
        public ObservableCollection<Ballot> Ballots
        {
            get { return ballots; }
            set { ballots = value; }
        }

        public Ballot SelectedBallot
        {
            get { return selectedBallot; }
            set
            {
                selectedBallot = value;
                this.OnPropertyChanged("SelectedBallot");
            }
        }

        public string AfterVoteText
        {
            get { return PageSingleton.AfterVoteText; }
        }

        public VoteViewModel()
        {
            user = UserSingleton.user;
            ballots = BallotSingleton.ballots;
        }

        public ICommand BackToStartPageCommand
        {
            get
            {
                return new BackToStartPage();
            }
        }

        public ICommand BackToLoginPageCommand
        {
            get
            {
                return new GoTo(LoginPage);
            }
        }

        public ICommand BackToVoteSelectPageCommand
        {
            get
            {
                return new BackToVoteSelectPage();
            }
        }

        public ICommand GetVoteCommand
        {
            get
            {
                return new SelectVote(this);
            }
        }

        public void LoginPage()
        {
            UserSingleton.user = new User();
            BallotSingleton.selectedBallot = new Ballot(0,null,null,false);
            BallotSingleton.ballots = new ObservableCollection<Ballot>();
            PageSingleton.PageSource = "Pages/LoginPage.xaml";
        }
        public async Task GetVote()
        {
            selectedBallot.candidates = await API.GetCandidateNamesForBallot(selectedBallot,user);
            BallotSingleton.selectedBallot = selectedBallot;
            PageSingleton.PageSource = "Pages/VotingPage.xaml";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

