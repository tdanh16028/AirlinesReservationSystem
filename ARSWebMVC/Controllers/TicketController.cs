using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARSWebMVC.Models;
using static ARSWebMVC.Controllers.ARSMVCUtilities;

namespace ARSWebMVC.Controllers
{
    public class TicketController : Controller
    {
        DBUserEntities db = new DBUserEntities();


        // GET: Ticket
        public ActionResult Index() {
            
            if (Session[SessionKey.UserProfile] == null)
            {
                TempData["lastPageVisit"] = new Dictionary<String, Object>() {
                    { "actionName", "Index" },
                    { "controllerName", "Ticket" }
                };
                return RedirectToAction("Login", "UserAccount");
            }
            else {
                TempData["lastPageVisit"] = null;
                return View();
            }

        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (Session[SessionKey.UserProfile] == null) return RedirectToAction("Login","UserAccount");
            var code = form["txtConfirmationCode"];

            if (code == null || code == "")
            {
                ViewBag.ErrorMessage = "Invalid Ticket Code";
                return View();
            }
            else
            {
                Profile userProfile = (Profile)Session[SessionKey.UserProfile];
                Ticket rs = ARSMVCUtilities.GetDB().Tickets.SingleOrDefault(s => s.TicketCode == code && s.ProfileID == userProfile.ID);
                if (rs != null)
                {
                    return RedirectToAction("TicketDetail", rs);
                }
                else
                {
                    ViewBag.ErrorMessage = "Ticket not found";
                    return View();
                }
            }
        }

        public ActionResult TicketDetail(Ticket ticket)
        {

            if (ticket.Status == "Preview")
            {
                return View(ticket);
            }

            if (ticket.TicketCode != null)
            {

                var rs = ARSMVCUtilities.GetDB().Tickets.SingleOrDefault(s => s.TicketCode == ticket.TicketCode);
                return View(rs);
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult PreviewTicket()
        {
            if (Session[SessionKey.Ticket] == null || Session[SessionKey.ListFlightScheduleChosen] == null)
                return RedirectToAction("Index", "Home");

            int lstFSChoice = (int)Session[SessionKey.ListFlightScheduleChosen];
            int seatClassID = ((Ticket)Session[SessionKey.Ticket]).AirplaneClassID;
            return PreviewTicket(lstFSChoice, seatClassID);
        }

        [HttpPost]
        public ActionResult PreviewTicket(int lstFSChoice, int seatClassID)
        {
            Session[SessionKey.ListFlightScheduleChosen] = lstFSChoice;
            List<FlightSchedule> lstFS = ((Dictionary<int, List<FlightSchedule>>)Session[SessionKey.ListPossibleFlightSchedule])[lstFSChoice];
            Ticket ticket = (Ticket)Session[SessionKey.Ticket];

            ticket.Profile = new Profile();
            if (Session[SessionKey.UserProfile] == null)
            {
                ticket.Profile.LastName = "Guest";
                ticket.Profile.FirstName = "";
            } else
            {
                ticket.Profile = (Profile)Session[SessionKey.UserProfile];
                ticket.ProfileID = ticket.Profile.ID;
                ticket.Profile = ARSMVCUtilities.GetDB().Profiles.Find(ticket.ProfileID);
            }

            List<FlightSchedule> lstTicketFS = new List<FlightSchedule>();
            foreach (FlightSchedule fs in lstFS)
            {
                FlightSchedule f = ARSMVCUtilities.GetDB().FlightSchedules.Find(fs.ID);
                lstTicketFS.Add(f);

                //lstTicketFS.Add(new FlightSchedule()
                //{
                //    ID = f.ID,
                //    AirplaneCode = f.AirplaneCode,
                //    Airplane = new Airplane()
                //    {
                //        AirplaneCode = f.AirplaneCode,
                //        TypeID = f.Airplane.TypeID,
                //        AirplaneType = new AirplaneType()
                //        {
                //            ID = f.Airplane.AirplaneType.ID,
                //            Name = f.Airplane.AirplaneType.Name
                //        }
                //    },
                //    FirstSeatAvail = f.FirstSeatAvail,
                //    BusinessSeatAvail = f.BusinessSeatAvail,
                //    ClubSeatAvail = f.ClubSeatAvail,
                //    DepartureDate = f.DepartureDate,
                //    RouteID = f.RouteID,
                //    Route = new Route()
                //    {
                //        CityA = new City()
                //        {
                //            ID = f.Route.CityA.ID,
                //            Code = f.Route.CityA.Code,
                //            Name = f.Route.CityA.Name
                //        },
                //        CityB = new City()
                //        {
                //            ID = f.Route.CityB.ID,
                //            Code = f.Route.CityB.Code,
                //            Name = f.Route.CityB.Name
                //        },
                //        BasePrice = f.Route.BasePrice,
                //        SkyMiles = f.Route.SkyMiles
                //    },
                //    IsActive = f.IsActive,
                //});
            }

            ticket.FlightSchedules = lstTicketFS;
            ticket.AirplaneClassID = seatClassID;
            AirplaneClass ac = ARSMVCUtilities.GetDB().AirplaneClasses.Find(seatClassID);
            ticket.AirplaneClass = ac;
            //ticket.AirplaneClass = new AirplaneClass()
            //{
            //    ID = ac.ID,
            //    Class = ac.Class,
            //    PriceRate = ac.PriceRate
            //};
            ticket.OrderDate = DateTime.Now;
            ticket.Status = "Preview";
            ticket.TicketCode = "N/A";

            int totalSeat = ticket.ChildrenCount + ticket.AdultCount + ticket.SeniorCount;
            double priceRate = ticket.AirplaneClass.PriceRate;
            double basePrice = lstFS.Sum(fs => fs.Route.BasePrice);
            ticket.TotalCost = Math.Round(basePrice * priceRate * totalSeat, 2);

            Session[SessionKey.Ticket] = ticket;
            return View("TicketDetail", ticket);
        }

        public ActionResult BuyTicket()
        {
            return AddTicket("Reserved");
        }

        public ActionResult BlockTicket()
        {
            return AddTicket("Blocked");
        }

        private ActionResult AddTicket(string ticketStatus)
        {
            if (Session[SessionKey.Ticket] == null)
            {
                RedirectToAction("Index", "Home");
            }

            if (Session[SessionKey.UserProfile] == null)
            {
                TempData["lastPageVisit"] = new Dictionary<String, Object>() {
                    { "actionName", "PreviewTicket" },
                    { "controllerName", "Ticket" }
                };
                return RedirectToAction("Login", "UserAccount");
            }

            Ticket ticket = (Ticket)Session[SessionKey.Ticket];
            ticket.Status = ticketStatus;

            // ticket.AirplaneClass = ARSMVCUtilities.GetDB().AirplaneClasses.Find(ticket.AirplaneClassID);
            // ticket.Profile = ARSMVCUtilities.GetDB().Profiles.Find(1);
            //foreach (FlightSchedule fs in ticket.FlightSchedules)
            //{
            //    fs = new FlightSchedule() {
            //        ARSMVCUtilities.GetDB().Airplanes.Find(fs.AirplaneCode);
            //    fs.Route = ARSMVCUtilities.GetDB().Routes.Find(fs.RouteID);
            //}


            //Ticket newTicket = new Ticket()
            //{
            //    ProfileID = profile.ID,
            //    AirplaneClassID = ticket.AirplaneClassID,
            //    ChildrenCount = ticket.ChildrenCount,
            //    AdultCount = ticket.AdultCount,
            //    SeniorCount = ticket.SeniorCount,
            //    FlightSchedules = lstFS,
            //    TicketCode = "N/A",
            //    OrderDate = ticket.OrderDate,
            //    Status = ticketStatus,
            //    TotalCost = ticket.TotalCost
            //};

            try
            {
                ARSMVCUtilities.GetDB().Tickets.Add(ticket);
                ARSMVCUtilities.GetDB().SaveChanges();

                // Gen ticket code
                ticket.TicketCode = "#" + ticket.ID.ToString();
                ARSMVCUtilities.GetDB().Entry(ticket).State = System.Data.Entity.EntityState.Modified;
                ARSMVCUtilities.GetDB().SaveChanges();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                throw ex;
            }

            return View("TicketDetail", ticket);
        }

        public ActionResult Cancelled(string ticketCode) {

            if (Session[SessionKey.UserProfile] == null) return RedirectToAction("Login", "UserAccount");
            var rs = ARSMVCUtilities.GetDB().Tickets.SingleOrDefault(s => s.TicketCode == ticketCode && s.ProfileID == ((Profile)Session[SessionKey.UserProfile]).ID);

            if (rs != null)
            {
                rs.Status = "Cancelled";
                
                ARSMVCUtilities.GetDB().SaveChanges();

                return RedirectToAction("TicketDetail", rs);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult ConfirmTicket(string ticketCode)
        {

            if (Session[SessionKey.UserProfile] == null) return RedirectToAction("Login", "UserAccount");
            var rs = ARSMVCUtilities.GetDB().Tickets.SingleOrDefault(s => s.TicketCode == ticketCode && s.ProfileID == ((Profile)Session[SessionKey.UserProfile]).ID);

            if (rs != null)
            {
                rs.Status = "Reserved";

                ARSMVCUtilities.GetDB().SaveChanges();

                return RedirectToAction("TicketDetail", rs);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}