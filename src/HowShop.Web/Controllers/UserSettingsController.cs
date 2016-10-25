using System.Web.Mvc;
using HowShop.Core.Commands;
using MediatR;

namespace HowShop.Web.Controllers
{
    [RoutePrefix("User/Settings")]
    public class UserSettingsController : Controller
    {
        private readonly IMediator _mediator;

        public UserSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View(new UserSettingsEdit.Command());
        }

        public ActionResult Save(UserSettingsEdit.Command command)
        {
            _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}