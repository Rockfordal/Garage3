using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Vehicles()
        {
            ViewBag.Title = "Lista av fordon";

            return View();
        }

        public ActionResult People()
        {
            ViewBag.Title = "Lista av personer";

            return View();
        }
    }
}
