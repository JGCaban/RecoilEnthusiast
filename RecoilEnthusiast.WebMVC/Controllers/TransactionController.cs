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
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            var transaction = service.GetTransactions();

            return View(transaction);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate transaction)
        {
            if (!ModelState.IsValid) return View(transaction);

            var service = CreateTransactionService();

            if (service.CreateTransaction(transaction))
            {
                TempData["SaveResult"] = "Transaction record was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Transaction record could not be created.");
            return View(transaction);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var transaction = svc.GetTransactionById(id);

            return View(transaction);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTransactionService();
            var detail = service.GetTransactionById(id);
            var transaction =
                new TransactionEdit
                {
                    TransactionId = detail.TransactionId,
                    Designation = detail.Designation,
                    IssuerName = detail.IssuerName,
                    TransactionDate = detail.TransactionDate
                };
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEdit transaction)
        {
            if (!ModelState.IsValid) return View(transaction);

            if(transaction.TransactionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(transaction);
            }
            var service = CreateTransactionService();

            if (service.UpdateTransaction(transaction))
            {
                TempData["SaveResult"] = "The Transaction has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Transaction could not be updated.");
            return View(transaction);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionService();
            var transaction = svc.GetTransactionById(id);

            return View(transaction);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTransactionService();

            service.DeleteTransaction(id);

            TempData["SaveResult"] = "Transaction has been deleted";

            return RedirectToAction("Index");
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }
    }
}