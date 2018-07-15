using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ARSWebAPI.Models;

namespace ARSWebAPI.Controllers
{
    public class FlightSchedulesController : ApiController
    {
        private DBUserEntities db = new DBUserEntities();

        // GET: api/FlightSchedules
        public IQueryable<FlightSchedule> GetFlightSchedules()
        {
            return db.FlightSchedules;
        }

        // GET: api/FlightSchedules/5
        [ResponseType(typeof(FlightSchedule))]
        public IHttpActionResult GetFlightSchedule(long id)
        {
            FlightSchedule flightSchedule = db.FlightSchedules.Find(id);
            if (flightSchedule == null)
            {
                return NotFound();
            }

            return Ok(flightSchedule);
        }

        // PUT: api/FlightSchedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlightSchedule(long id, FlightSchedule flightSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightSchedule.ID)
            {
                return BadRequest();
            }

            db.Entry(flightSchedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (!FlightScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    while (ex.InnerException != null) ex = ex.InnerException;
                    return Content(HttpStatusCode.InternalServerError, ex.Message);
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FlightSchedules
        [ResponseType(typeof(FlightSchedule))]
        public IHttpActionResult PostFlightSchedule(FlightSchedule flightSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.FlightSchedules.Add(flightSchedule);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = flightSchedule.ID }, flightSchedule);
        }

        // DELETE: api/FlightSchedules/5
        [ResponseType(typeof(FlightSchedule))]
        public IHttpActionResult DeleteFlightSchedule(long id)
        {
            FlightSchedule flightSchedule = db.FlightSchedules.Find(id);
            if (flightSchedule == null)
            {
                return NotFound();
            }

            db.FlightSchedules.Remove(flightSchedule);
            db.SaveChanges();

            return Ok(flightSchedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightScheduleExists(long id)
        {
            return db.FlightSchedules.Count(e => e.ID == id) > 0;
        }
    }
}