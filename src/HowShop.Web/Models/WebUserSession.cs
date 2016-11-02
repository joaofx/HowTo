using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using HowShop.Core.Infra;

namespace HowShop.Web.Models
{
    /// <summary>
    /// TODO: Proper authentication
    /// http://www.codeproject.com/Tips/849113/Four-Easy-Steps-to-Set-Up-OWIN-for-Form-authentica
    /// https://weblog.west-wind.com/posts/2015/Apr/29/Adding-minimal-OWIN-Identity-Authentication-to-an-Existing-ASPNET-MVC-Application
    /// http://www.khalidabuhakmeh.com/asp-net-mvc-5-authentication-breakdown
    /// https://coding.abel.nu/2014/06/understanding-the-owin-external-authentication-pipeline/
    /// http://stackoverflow.com/questions/26166826/usecookieauthentication-vs-useexternalsignincookie
    /// </summary>
    public class WebUserSession : IUserSession
    {
        private readonly HowShopContext _db;

        public WebUserSession(HowShopContext db)
        {
            _db = db;
        }

        public bool IsLogged => HttpContext.Current.User.Identity.IsAuthenticated;

        public void Login(User user, bool remember)
        {
            FormsAuthentication.SetAuthCookie(user.Email, true);

            if (remember)
                SetAuthenticationCookieExpiration(user.Email);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public User User
        {
            get
            {
                if (HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var user = _db.Users.SingleOrDefault(x => x.Email == HttpContext.Current.User.Identity.Name);

                    if (user != null)
                    {
                        return user;
                    }
                }

                Logout();
                return null;
            }
        }

        private void SetAuthenticationCookieExpiration(string userName)
        {
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(userName, true);
            cookie.Expires = DateTime.Now.AddDays(5);
            var decriptedCookie = FormsAuthentication.Decrypt(cookie.Value);

            var at = new FormsAuthenticationTicket(
                decriptedCookie.Version,
                decriptedCookie.Name,
                decriptedCookie.IssueDate,
                cookie.Expires,
                true,
                decriptedCookie.UserData);

            cookie.Value = FormsAuthentication.Encrypt(at);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}