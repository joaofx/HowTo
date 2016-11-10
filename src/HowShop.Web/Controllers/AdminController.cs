using System.Web.Mvc;
using HowShop.Core.Queries;
using MediatR;

namespace HowShop.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}