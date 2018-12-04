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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            var customer = service.GetCustomers();

            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate customer)
        {
            if (!ModelState.IsValid) return View(customer);

            var service = CreateCustomerService();

            if (service.CreateCustomer(customer))
            {
                TempData["SaveResult"] = "Customer was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Customer could not be created.");

            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var customer = svc.GetCustomerById(id);

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var customer =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    DateOfBirth = detail.DateOfBirth,
                    HasFelony = detail.HasFelony
                };
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit customer)
        {
            if (!ModelState.IsValid) return View(customer);

            if(customer.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(customer);
            }
            var service = CreateCustomerService();

            if (service.UpdateCustomer(customer))
            {
                TempData["SaveResult"] = "Customer was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your customer could not be updated.");

            return View(customer);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var customer = svc.GetCustomerById(id);

            return View(customer);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Customer was deleted";


            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}