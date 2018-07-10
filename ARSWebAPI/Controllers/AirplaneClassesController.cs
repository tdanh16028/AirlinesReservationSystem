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
    public class AirplaneClassesController : ApiController
    {
        private DBUserEntities db = new DBUserEntities();

        // GET: api/AirplaneClasses
        public IQueryable<AirplaneClass> GetAirplaneClasses()
        {
            return db.AirplaneClasses;
        }

        // GET: api/AirplaneClasses/5
        [ResponseType(typeof(AirplaneClass))]
        public IHttpActionResult GetAirplaneClass(int id)
        {
            AirplaneClass airplaneClass = db.AirplaneClasses.Find(id);
            if (airplaneClass == null)
            {
                return NotFound();
            }

            return Ok(airplaneClass);
        }

        // PUT: api/AirplaneClasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAirplaneClass(int id, AirplaneClass airplaneClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airplaneClass.ID)
            {
                return BadRequest();
            }

            db.Entry(airplaneClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AirplaneClasses
        [ResponseType(typeof(AirplaneClass))]
        public IHttpActionResult PostAirplaneClass(AirplaneClass airplaneClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AirplaneClasses.Add(airplaneClass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = airplaneClass.ID }, airplaneClass);
        }

        // DELETE: api/AirplaneClasses/5
        [ResponseType(typeof(AirplaneClass))]
        public IHttpActionResult DeleteAirplaneClass(int id)
        {
            AirplaneClass airplaneClass = db.AirplaneClasses.Find(id);
            if (airplaneClass == null)
            {
                return NotFound();
            }

            db.AirplaneClasses.Remove(airplaneClass);
            db.SaveChanges();

            return Ok(airplaneClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AirplaneClassExists(int id)
        {
            return db.AirplaneClasses.Count(e => e.ID == id) > 0;
        }
    }
}