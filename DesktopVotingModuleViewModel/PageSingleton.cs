using System.ComponentModel;

namespace DesktopVotingModuleViewModel
{
    //https://stackoverflow.com/questions/44232233/how-to-set-a-static-class-to-data-context
    //https://stackoverflow.com/questions/34762879/static-binding-doesnt-update-when-resource-changes
    public class PageSingleton
    {
        //private static string pageSource = "Pages/LoginPage.xaml";
        private static string pageSource = "Pages/VoteResultPage.xaml";
        public static string PageSource
        {
            get { return pageSource; }
            set
            {
                pageSource = value;
                OnStaticPropertyChanged("PageSource");
            }
        }
        
        public static PageSingleton Instance { get; }
        static PageSingleton()
        {
            Instance = new PageSingleton();
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