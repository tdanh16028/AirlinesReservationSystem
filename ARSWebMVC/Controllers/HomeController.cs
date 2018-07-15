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
        DBUserEntities db = new DBUserEntities();
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


        public ActionResult QueryFlightDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FlightStatus(string airplaneCode)
        {
            if (airplaneCode ==null)
            {
                return RedirectToAction("QueryFlightDetails");
            }
            List<FlightSchedule> rs = db.FlightSchedules.Where(s => s.AirplaneCode == airplaneCode).ToList();
            if (rs != null && rs.Count >0)
            {
                return View(rs);
            }
            else
            {
                ViewBag.FlightStatusErrorMessage = "Not found";
                return View("QueryFlightDetails");
            }
        }
    }
}