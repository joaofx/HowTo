using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;

namespace HowShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(DefaultAuthenticationTypes.ExternalCookie);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                AuthenticationMode = AuthenticationMode.Passive,
                LoginPath = new PathString("/Login"),
                CookieHttpOnly = true,
                CookieName = CookieAuthenticationDefaults.CookiePrefix + "External"
            });
        }
    }
}