using System;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;

namespace HowTo.IntegratedTests
{
    public class TestUserSession : IUserSession
    {
        public static Func<User> CurrentUser = () => null;
         
        public void Login(User user, bool remember)
        {
        }

        public void Logout()
        {
        }

        public User User => CurrentUser();
        public bool IsLogged => User != null;
    }
}
