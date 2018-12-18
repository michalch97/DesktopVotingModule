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
    public class MenuViewModel
    {
        public ICommand GoToVotePageCommand
        {
            get
            {
                return new GoToVotePage(this);
            }
        }

        public void VotePage()
        {
            PageController.PageSource = "VotingPage.xaml";
        }

        public ICommand GoToVoteResultCommand
        {
            get
            {
                return new GoToVoteResultPage(this);
            }
        }

        public void VoteResultPage()
        {
            PageController.PageSource = "VoteResultPage.xaml";
        }

    }
}
