using System.CodeDom;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesktopVotingModuleModel;
using DesktopVotingModuleViewModel.Annotations;

namespace DesktopVotingModuleViewModel
{
    //https://stackoverflow.com/questions/44232233/how-to-set-a-static-class-to-data-context
    //https://stackoverflow.com/questions/34762879/static-binding-doesnt-update-when-resource-changes
    public class PageController
    {
        private static string pageSource="LoginPage.xaml";
        public static string PageSource
        {
            get { return pageSource; }
            set
            {
                pageSource = value;
                OnStaticPropertyChanged("PageSource");
            }
        }

        private static User user;

        public static User User
        {
            get { return user; }
            set { user = value; }
        }

        public static PageController Instance { get; }
        static PageController()
        {
            Instance = new PageController();
        }

        public static event PropertyChangedEventHandler StaticPropertyChanged;
        private static void OnStaticPropertyChanged(string propertyName)
        {
            var handler = StaticPropertyChanged;
            if (handler != null)
            {
                handler(null, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}