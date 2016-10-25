using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

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
    public class UserSession : IUserSession
    {
        private readonly IAuthenticationManager _authenticationManager;

        public UserSession()
        {
            // TODO: not use HttpContext
            var ctx = HttpContext.Current.Request.GetOwinContext();
            _authenticationManager = ctx.Authentication;
        }

        public bool IsLogged => _authenticationManager.User.Identity.IsAuthenticated;

        public void Login(User user, bool remember)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            _authenticationManager.SignIn(id);
        }

        public void Logout()
        {
            _authenticationManager.SignOut();
        }
    }
}