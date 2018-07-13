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
            return View();
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
    }
}