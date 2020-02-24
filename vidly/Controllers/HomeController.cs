using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class HomeController : Controller
    {
        // to open gate to database 
        majdiEntities beso = new majdiEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Emp em)
        {
            if (!ModelState.IsValid) {

                return View();
            }

            beso.Emps.Add(em);
            beso.SaveChanges();

            return RedirectToAction("reEmployee");
        }
        // to get data from database to view as a list
        public ActionResult reEmployee() {
            var list = beso.Emps.ToList();
            return View(list);

        }


    }
}