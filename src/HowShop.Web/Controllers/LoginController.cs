using System.Web.Mvc;
using HowShop.Core.Commands;
using MediatR;
using SolidR.Core.Mvc;

namespace HowShop.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View(new UserLogin.Command());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(UserLogin.Command command)
        {
            _mediator.Send(command);
            return this.RedirectToActionJson<AdminProductController>(x => x.Index(null));
        }

        public ActionResult SignOut()
        {
            _mediator.Send(new UserLogout.Command());
            return RedirectToAction("Index", "Login");
        }
    }
}