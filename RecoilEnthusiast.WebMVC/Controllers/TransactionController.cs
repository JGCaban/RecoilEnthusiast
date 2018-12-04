using RecoilEnthusiast.Models;
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
            var transaction = new TransactionList[0];
            return View(transaction);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
    }
}