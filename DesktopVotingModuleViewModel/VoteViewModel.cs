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
        private Candidate SelectedCandidate;
        private ObservableCollection<Candidate> candidatesCollection = CandidatesSingleton.candidatesCollection;

        public Candidate SelectedCandidate1 { get => SelectedCandidate; set => SelectedCandidate = value; }
        public ObservableCollection<Candidate> CandidatesCollection { get => candidatesCollection; set => candidatesCollection = value; }


        public ICommand VoteCandidateCommand
        {
            get
            {
                return new VoteCandidate(this);
            }
        }

        public void Vote()
        {
            PageController.PageSource = "AfterVotePage.xaml";
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

       
    }
}
