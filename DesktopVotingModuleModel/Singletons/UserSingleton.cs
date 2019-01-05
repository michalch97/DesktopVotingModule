namespace DesktopVotingModuleModel
{
    public class UserSingleton
    {
        public static User user;
        public static UserSingleton Instance { get; }
        static UserSingleton()
        {
            user = new User();
            Instance = new UserSingleton();
        }

    }
}