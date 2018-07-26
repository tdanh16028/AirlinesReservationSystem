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
            return View();
        }

        public ActionResult CheckingAvailability() {
            List<City> lstCity = ARSMVCUtilities.GetDB().Cities.ToList();
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
      
        public ActionResult QueryFlightDetails()
        {
            return View();
        }

        //Post FlightStatus from QueryFlightDetails
        [HttpPost]
        public ActionResult FlightStatus(string airplaneCode, DateTime? departureDate = null)
        {
            // if airplaneCode == null => back to QueryFlightDetails
            if (airplaneCode == null)
            {
                ViewBag.QueryFlightDetailsError = "Airplane code is required";
                return View("QueryFlightDetails");
            }

            //Search in the database returns the list of airplane code is "airplaneCode", if not find returned error message
            List<FlightSchedule> rs;
            if (departureDate == null)
            {
                rs = ARSMVCUtilities.GetDB().FlightSchedules.Where(s => s.AirplaneCode == airplaneCode && s.DepartureDate >= DateTime.Now).ToList();
            } else
            {
                rs = ARSMVCUtilities.GetDB().FlightSchedules.Where(s => s.AirplaneCode == airplaneCode && s.DepartureDate == departureDate).ToList();
            }
            
            if (rs != null && rs.Count > 0)
            {
                return View(rs);
            }
            else
            {
                ViewBag.QueryFlightDetailsError = "The airplane " + airplaneCode + " does not have any flight schedule at the given date";
                return View("QueryFlightDetails");
            }
        }
    }
}