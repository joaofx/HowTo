using System.Web.Mvc;
using HowShop.Core.Commands;
using HowShop.Core.Queries;
using HowShop.Web.Models;
using MediatR;

namespace HowShop.Web.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IMediator _mediator;

        public AdminProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            var result = _mediator.Send(new ProductList.Query());
            return View(result);
        }

        public ActionResult New()
        {
            var result = _mediator.Send(new ProductEdit.Command());
            return View(result);
        }

        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult Mostrar(string id)
        {
            return View(Products.ById(id));
        }
    }
}