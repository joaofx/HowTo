using System.Web.Mvc;
using HowShop.Core.Commands;
using HowShop.Core.Queries;
using MediatR;
using SolidR.Core.Mvc;

namespace HowShop.Web.Controllers
{
    [RoutePrefix("Admin/User")]
    [Route("{action=Index}")]
    public class AdminUserController : Controller
    {
        private readonly IMediator _mediator;

        public AdminUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public ActionResult Index()
        {
            var result = _mediator.Send(new UserList.Query());
            return View(result);
        }

        public ActionResult New()
        {
            return View("Edit", new UserEdit.Command());
        }

        public ActionResult Edit(long id)
        {
            var result = _mediator.Send(new UserEdit.Query { Id = id });
            return View("Edit", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserEdit.Command command)
        {
            _mediator.Send(command);
            return this.RedirectToActionJson(c => c.Index());
        }
    }
}