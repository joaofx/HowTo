using HowShop.Core.Domain;

namespace HowShop.Core.Concerns
{
    public interface IUserSession
    {
        void Login(User user, bool remember);
        void Logout();
        User User { get; }
        bool IsLogged { get; }
    }
}