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
    [Authorize]
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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate product)
        {
            if (!ModelState.IsValid) return View(product);

            var service = CreateProductService();

            if (service.CreateProduct(product))
            {
                TempData["SaveResult"] = "Product was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be created.");

            return View(product);
        }
        
        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var product = svc.GetProductById(id);

            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductById(id);
            var product =
                new ProductEdit
                {
                    ProductId = detail.ProductId,
                    TypeOfItem = detail.TypeOfItem,
                    Name = detail.Name,
                    Model = detail.Model,
                    Serial = detail.Serial,
                    Notes = detail.Notes
                };
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit product)
        {
            if (!ModelState.IsValid) return View(product);

            if(product.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(product);
            }
            var service = CreateProductService();

            if (service.UpdateProduct(product))
            {
                TempData["SaveResult"] = "Your product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var product = svc.GetProductById(id);

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Your ntoe was deleted";

            return RedirectToAction("Index");
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
    }
}