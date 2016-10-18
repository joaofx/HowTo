using HowShop.Core.Domain;

namespace HowShop.Core.Security
{
    public class UserSession
    {
        private static User _currentUser;

        public User CurrentUser => _currentUser;

        public bool IsLogged => _currentUser != null;

        public void SignOut()
        {
            _currentUser = null;
        }

        public void SignIn(User user)
        {
            _currentUser = user;
        }
    }
}