using ARSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ARSWebAPI.Controllers
{
    public class TicketFlightSchedulesController : ApiController
    {
        private DBUserEntities db = new DBUserEntities();

        // GET: api/TicketFlightSchedules/5
        [ResponseType(typeof(List<FlightSchedule>))]
        public IHttpActionResult GetFlightSchedule(long id)
        {
            Ticket ticket = db.Tickets.Include(t => t.FlightSchedules).SingleOrDefault(t => t.ID == id);

            if (ticket == null)
            {
                return NotFound();
            }

            foreach (FlightSchedule flightSchedule in ticket.FlightSchedules)
            {
                flightSchedule.Tickets = null;
                flightSchedule.Route = null;
                flightSchedule.Airplane = null;
            }

            return Ok(ticket.FlightSchedules);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
