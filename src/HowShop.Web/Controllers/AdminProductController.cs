using System.Web.Mvc;
using HowShop.Core.Commands;
using HowShop.Core.Queries;
using MediatR;
using SolidR.Core.Mvc;

namespace HowShop.Web.Controllers
{
    [RoutePrefix("Admin/Product")]
    public class AdminProductController : Controller
    {
        private readonly IMediator _mediator;

        public AdminProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index(ProductList.Query query)
        {
            var result = _mediator.Send(query);
            return View(result);
        }

        public ActionResult New()
        {
            return View("Edit", new ProductEdit.Command());
        }

        public ActionResult Edit(ProductEdit.Query query)
        {
            var result = _mediator.Send(query);
            return View("Edit", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProductEdit.Command command)
        {
            _mediator.Send(command);
            return this.RedirectToActionJson(c => c.Index(null));
        }
    }
}