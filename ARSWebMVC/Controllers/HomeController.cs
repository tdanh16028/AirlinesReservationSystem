using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARSWebMVC.Models;

namespace ARSWebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("CheckingAvailability");
        }

        public ActionResult CheckingAvailability() {
            return View();
        }

        public ActionResult ListRoute()
        {
            return View();
        }

        public ActionResult DatePic()
        {
            return View();
        }

        public ActionResult TicketDetailTemp()
        {
            
            return View();
        }
    }
}