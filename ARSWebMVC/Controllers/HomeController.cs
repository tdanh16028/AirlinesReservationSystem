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
            List<City> lstCity = db.Cities.ToList();
            return View(lstCity);
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
        //Post FlightStatus from QueryFlightDetails
        [HttpPost]
        public ActionResult FlightStatus(string airplaneCode)
        {
            // if airplaneCode == null => back to QueryFlightDetails
            if (airplaneCode == null)
            {
                return RedirectToAction("QueryFlightDetails");
            }

            //Search in the database returns the list of airplane code is "airplaneCode",if not find returned error message
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