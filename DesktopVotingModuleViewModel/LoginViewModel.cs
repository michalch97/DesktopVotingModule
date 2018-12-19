using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DesktopVotingModuleModel;

namespace DesktopVotingModuleViewModel
{
    public class LoginViewModel
    {
        private string login;
        private string password;
        public string Login
        {
            set { this.login = value; }
            get { return login; }
        }

        public string Password
        {
            set { this.password = value; }
            get { return password; }
        }

        public ICommand LoginUserCommand
        {
            get
            {
                return new LoginUser(this);
            }
        }

        public void GetPassword(object parameter)
        {
            var passwordContainer = parameter as IPassword;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.Password;
                Password = ConvertToUnsecureString(secureString);
            }
        }
        public async Task Authorize()
        {
            User user = new User(login,password);
            bool authorizationStatus = await API.LoginAsync(user);
            PageController.PageSource = "VotingPage.xaml";
            PageController.User = user;
        }
        private string ConvertToUnsecureString(System.Security.SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
