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
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TicketDetail()
        {
            Ticket ticket = new Ticket();
            ticket.Status = "";
            return View(ticket);
        }

    }
}