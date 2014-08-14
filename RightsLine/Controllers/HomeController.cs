using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RightsLine.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Title = "Cory Crabb - RightsLine Project";
            return View();
        }
    }
}
