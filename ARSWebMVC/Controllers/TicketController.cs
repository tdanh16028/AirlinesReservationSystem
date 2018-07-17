using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARSWebMVC.Models;

namespace ARSWebMVC.Controllers
{
    public class TicketController : Controller
    {
        DBUserEntities db = new DBUserEntities();


        // GET: Ticket
        public ActionResult Index() {
            
            if (Session["UserProfile"] == null)
            {
                TempData["Status"] = "Ticket";
                return RedirectToAction("Login", "UserAccount");
            }
            else {
                TempData["Status"] = "";
                return View();
            }

        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (Session["UserProfile"] == null) return RedirectToAction("Login","UserAccount");
            var code = form["txtConfirmationCode"];
            if (code == null || code == "")
            {
                ViewBag.ErrorMessage = "Invalid ConfirmationCode";
                return View();
            }
            else
            {
                Ticket rs = db.Tickets.SingleOrDefault(s => s.TicketCode == code);
                if (rs != null)
                {
                    return RedirectToAction("TicketDetail", rs);
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid ConfirmationCode";
                    return View();
                }
            }
        }

        public ActionResult TicketDetail(Ticket ticket)
        {

            if (ticket.Status == "temp")
            {
                return View(ticket);
            }

            if (ticket.TicketCode != null)
            {

                var rs = db.Tickets.SingleOrDefault(s => s.TicketCode == ticket.TicketCode);
                return View(rs);
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult TicketDetailTemp()
        {
            Ticket tickettemp = new Ticket()
            {
                ID = 0,
                ProfileID = 2,
                Profile = db.Profiles.Find(2),
                TicketCode = "000000",
                Status = "temp",
                ChildrenCount = 2,
                AdultCount = 2,
                SeniorCount = 1,
                AirplaneClassID = 1,
                AirplaneClass = db.AirplaneClasses.Find(1),
                OrderDate = DateTime.Now,
                TotalCost = 0,
                FlightSchedules = new List<FlightSchedule>()
                {
                    db.FlightSchedules.Where(fs => fs.ID == 1).Single(),
                    db.FlightSchedules.Where(fs => fs.ID == 4).Single(),
                    db.FlightSchedules.Where(fs => fs.ID == 5).Single()
                }
            };

            return View("TicketDetail", tickettemp);
        }


        public ActionResult Cancelled(string ticketCode) {
           
            var rs = db.Tickets.SingleOrDefault(s => s.TicketCode == ticketCode);

            if (rs != null)
            {
                rs.Status = "Cancelled";
                
                db.SaveChanges();

                return RedirectToAction("TicketDetail", rs);
            }
            else
            {
                return RedirectToAction("TicketDetail");
            }
        }

        public ActionResult ConfirmTicket(string ticketCode)
        {

            var rs = db.Tickets.SingleOrDefault(s => s.TicketCode == ticketCode);

            if (rs != null)
            {
                rs.Status = "Reversed";

                db.SaveChanges();

                return RedirectToAction("TicketDetail", rs);
            }
            else
            {
                return RedirectToAction("TicketDetail");
            }
        }
    }
}