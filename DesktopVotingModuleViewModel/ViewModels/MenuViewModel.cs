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
                return new GoTo(VoteSelectPage);
            }
        }
        public void VoteSelectPage()
        {
            PageSingleton.PageSource = "Pages/VoteSelectPage.xaml";
        }

        public ICommand GoToVoteResultCommand
        {
            get
            {
                return new GoTo(VoteResultPage);
            }
        }

        public void VoteResultPage()
        {
            PageSingleton.PageSource = "Pages/VoteResultSelectPage.xaml";
        }


    }
}
