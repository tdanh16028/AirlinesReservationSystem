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
                
                return RedirectToAction("Login", "UserAccount", ViewBag.ErrorMessage = "Please Login");
            }
            else {
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