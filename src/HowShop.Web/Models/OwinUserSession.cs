using System;
using System.Security.Claims;
using System.Web;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace HowShop.Web.Models
{
    //public class OwinUserSession : IUserSession
    //{
    //    public void Login(User user, bool remember)
    //    {
    //        var identity = new ClaimsIdentity(
    //            new[] { new Claim(ClaimTypes.Email, user.Email) },
    //            DefaultAuthenticationTypes.ApplicationCookie);

    //        HttpContext.Current.GetOwinContext().Authentication.SignIn(new AuthenticationProperties
    //        {
    //            IsPersistent = remember
    //        }, identity);
    //    }

    //    public void Logout()
    //    {
    //        HttpContext.Current.GetOwinContext().Authentication.SignOut();
    //    }

    //    public User User { get; }
    //    public bool IsLogged { get; }
    //}
}