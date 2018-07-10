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
            var code = form["txtConfirmationCode"].ToString();
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

        public ActionResult TicketDetail(Object ticket)
        {
            return View(ticket);
        }

    }
}