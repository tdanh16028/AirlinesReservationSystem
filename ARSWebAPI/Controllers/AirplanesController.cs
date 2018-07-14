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
    public class AirplanesController : ApiController
    {
        private DBUserEntities db = new DBUserEntities();

        // GET: api/Airplanes
        public IQueryable<Airplane> GetAirplanes()
        {
            return db.Airplanes;
        }

        // GET: api/Airplanes/5
        [ResponseType(typeof(Airplane))]
        public IHttpActionResult GetAirplane(string id)
        {
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return NotFound();
            }

            return Ok(airplane);
        }

        // PUT: api/Airplanes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAirplane(string id, Airplane airplane)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airplane.AirplaneCode)
            {
                return BadRequest();
            }

            db.Entry(airplane).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (!AirplaneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    while (ex.InnerException != null) ex = ex.InnerException;
                    return InternalServerError(ex);
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Airplanes
        [ResponseType(typeof(Airplane))]
        public IHttpActionResult PostAirplane(Airplane airplane)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Airplanes.Add(airplane);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (AirplaneExists(airplane.AirplaneCode))
                {
                    return Content(HttpStatusCode.Conflict, "Airplane code already existed!");
                }
                else
                {
                    while (ex.InnerException != null) ex = ex.InnerException;
                    return InternalServerError(ex);
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = airplane.AirplaneCode }, airplane);
        }

        // DELETE: api/Airplanes/5
        [ResponseType(typeof(Airplane))]
        public IHttpActionResult DeleteAirplane(string id)
        {
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return NotFound();
            }

            db.Airplanes.Remove(airplane);
            db.SaveChanges();

            return Ok(airplane);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AirplaneExists(string id)
        {
            return db.Airplanes.Count(e => e.AirplaneCode == id) > 0;
        }
    }
}