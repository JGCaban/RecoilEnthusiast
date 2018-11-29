using Microsoft.AspNet.Identity;
using RecoilEnthusiast.Models;
using RecoilEnthusiast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecoilEnthusiast.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            var product = service.GetProducts();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);

            service.CreateProduct(product);

            return RedirectToAction("Index");
        }
    }
}