using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopVotingModuleModel;
using DesktopVotingModuleViewModel;

namespace DesktopVotingModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = PageController.Instance;

            ObservableCollection<Candidate> candidates = new ObservableCollection<Candidate>();
            Candidate c1 = new Candidate("Paweł", 1);
            Candidate c2 = new Candidate("Michał", 2);

            candidates.Add(c1);
            candidates.Add(c2);


            Vote x = new Vote("Głosowanie 1", candidates, DateTime.Now, DateTime.Now);

            VotesSingleton.voteCollection.Add(x);
        }
        
    }
}
