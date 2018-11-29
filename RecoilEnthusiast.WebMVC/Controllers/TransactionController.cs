using RecoilEnthusiast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecoilEnthusiast.WebMVC.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var model = new TransactionList[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}