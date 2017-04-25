using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.message = "This is index.";
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Cjenik()
        {
            return View();
        }

        public ActionResult Skladiste()
        {
            return View();
        }

        public ActionResult IspisRacuna()
        {
            return View();
        }
    }
}