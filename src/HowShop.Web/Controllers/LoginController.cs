﻿using System.Collections.Generic;
using System.Web.Mvc;
using HowShop.Core.Domain;
using HowShop.Core.Queries;
using HowShop.Core.Security;
using MediatR;
using SolidR.Mvc;

namespace HowShop.Web.Controllers
{
    /// <summary>
    /// TODO: Proper authentication
    /// https://weblog.west-wind.com/posts/2015/Apr/29/Adding-minimal-OWIN-Identity-Authentication-to-an-Existing-ASPNET-MVC-Application
    /// http://www.khalidabuhakmeh.com/asp-net-mvc-5-authentication-breakdown
    /// https://coding.abel.nu/2014/06/understanding-the-owin-external-authentication-pipeline/
    /// http://stackoverflow.com/questions/26166826/usecookieauthentication-vs-useexternalsignincookie
    /// </summary>
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserSession _userSession;

        public LoginController(IMediator mediator, UserSession userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
        }

        public ActionResult Index()
        {
            return View(new List<User>()
            {
                new User("Admin", 20),
                new User("Backoffice", 20)
            });
        }

        public ActionResult SignIn(string name)
        {
            _userSession.SignIn(new User(name, 20));
            return RedirectToAction("Index", "AdminProduct");
        }

        public ActionResult SignOut()
        {
            _userSession.SignOut();
            return this.RedirectToAction(x => x.Index());
        }
    }
}