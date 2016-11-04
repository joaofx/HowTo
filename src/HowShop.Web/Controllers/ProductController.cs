using System.Web.Mvc;
using HowShop.Core.Queries;
using HowShop.Web.Models;
using MediatR;

namespace HowShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index(ProductList.Query query)
        {
            var result = _mediator.Send(query);
            return View(result);
        }

        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult Mostrar(string id)
        {
            return View(Products.ById(id));
        }
    }
}