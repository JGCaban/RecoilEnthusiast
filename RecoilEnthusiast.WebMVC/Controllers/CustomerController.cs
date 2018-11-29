using RecoilEnthusiast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecoilEnthusiast.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var model = new CustomerList[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}