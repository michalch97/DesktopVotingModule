using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVotingModuleModel
{
    public class User
    {
        private string login;
        private string password;
        private string token;
        public string Login
        {
            get { return login; }
        }
        public string Password
        {
            get { return password; }
        }
        public string Token
        {
            get { return token; }
            set { this.token = value; }
        }
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public User()
        {
        }
    }
}
