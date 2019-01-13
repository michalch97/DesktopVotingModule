using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using DesktopVotingModuleModel;
using Microsoft.Win32;

namespace DesktopVotingModuleViewModel
{
    public class VoteResultViewModel
    {
        private ObservableCollection<Ballot> ballots;
        private Ballot selectedBallot;
        private string folderPath;
        public IBrowse FolderBrowser { get; set; }
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
        
        public VoteResultViewModel()
        {
            ballots = BallotSingleton.ballots;
            selectedBallot = BallotSingleton.selectedBallot;
        }
        public ICommand GetVoteResultCommand
        {
            get
            {
                return new VoteResult(this);
            }
        }

        public ICommand GoToVoteSelectCommand
        {
            get
            {
                return new GoTo(VoteSelect);
            }
        }
        public ICommand GetPathCommand
        {
            get
            {
                return new GetPath(this);
            }
        }

        public ICommand BackToMenuCommand
        {
            get
            {
                return new BackToStartPage();
            }
        }

        public void GetFolderPath()
        {
            folderPath = FolderBrowser.Browse();
        }
        public async Task SetPath()
        {
            await API.GetResultsImage(selectedBallot, folderPath);
        }
        public void VoteSelect()
        {
            PageSingleton.PageSource = "Pages/VoteResultSelectPage.xaml";
        }
        public void VoteResult()
        {
            BallotSingleton.selectedBallot = SelectedBallot;
            PageSingleton.PageSource = "Pages/VoteResultPage.xaml";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

