using System.Collections.Generic;
using System.Web.Mvc;
using HowShop.Core.Commands;
using HowShop.Core.Domain;
using HowShop.Core.Queries;
using HowShop.Core.Security;
using MediatR;
using SolidR.Mvc;

namespace HowShop.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserSession _userSession;

        public UserController(IMediator mediator, UserSession userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
        }

        public ActionResult Settings()
        {
            return View(new UserSettingsEdit.Command());
        }

        public ActionResult SaveSettings(UserSettingsEdit.Command command)
        {
            _mediator.Send(command);
            return this.RedirectToAction(x => x.Settings());
        }
    }
}