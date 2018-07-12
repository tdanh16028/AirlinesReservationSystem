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
    public class AirplaneTypesController : ApiController
    {
        private DBUserEntities db = new DBUserEntities();

        // GET: api/AirplaneTypes
        public IQueryable<AirplaneType> GetAirplaneTypes()
        {
            return db.AirplaneTypes;
        }

        // GET: api/AirplaneTypes/5
        [ResponseType(typeof(AirplaneType))]
        public IHttpActionResult GetAirplaneType(int id)
        {
            AirplaneType airplaneType = db.AirplaneTypes.Find(id);
            if (airplaneType == null)
            {
                return NotFound();
            }

            return Ok(airplaneType);
        }

        // PUT: api/AirplaneTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAirplaneType(int id, AirplaneType airplaneType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airplaneType.ID)
            {
                return BadRequest();
            }

            db.Entry(airplaneType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneTypeExists(id))
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

        // POST: api/AirplaneTypes
        [ResponseType(typeof(AirplaneType))]
        public IHttpActionResult PostAirplaneType(AirplaneType airplaneType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AirplaneTypes.Add(airplaneType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = airplaneType.ID }, airplaneType);
        }

        // DELETE: api/AirplaneTypes/5
        [ResponseType(typeof(AirplaneType))]
        public IHttpActionResult DeleteAirplaneType(int id)
        {
            AirplaneType airplaneType = db.AirplaneTypes.Find(id);
            if (airplaneType == null)
            {
                return NotFound();
            }

            db.AirplaneTypes.Remove(airplaneType);
            db.SaveChanges();

            return Ok(airplaneType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AirplaneTypeExists(int id)
        {
            return db.AirplaneTypes.Count(e => e.ID == id) > 0;
        }
    }
}