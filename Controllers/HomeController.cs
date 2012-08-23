using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StageOne.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Robots()
        {
          Response.ContentType = "text/plain";
          return View();
        }
    }
}
