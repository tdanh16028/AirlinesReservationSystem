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
    public class AirplaneInfoesController : ApiController
    {
        private DBUserEntities db = new DBUserEntities();

        // GET: api/AirplaneInfoes
        public IQueryable<AirplaneInfo> GetAirplaneInfoes()
        {
            return db.AirplaneInfoes;
        }

        // GET: api/AirplaneInfoes/5
        [ResponseType(typeof(List<AirplaneInfo>))]
        public IHttpActionResult GetAirplaneInfoes(int id)
        {
            List<AirplaneInfo> lstAirplaneInfo = db.AirplaneInfoes.Where(ai => ai.AirplaneTypeID == id).Select(ai => ai).ToList();
            if (lstAirplaneInfo.Count == 0)
            {
                return NotFound();
            }

            return Ok(lstAirplaneInfo);
        }

        // GET: api/AirplaneInfoes/5/3
        [ResponseType(typeof(AirplaneInfo))]
        [Route("api/AirplaneInfoes/{airplaneTypeID}/{classID}")]
        public IHttpActionResult GetAirplaneInfo(int airplaneTypeID, int classID)
        {
            AirplaneInfo airplaneInfo = db.AirplaneInfoes
                .Where(ai => ai.AirplaneTypeID == airplaneTypeID && ai.ClassID == classID)
                .SingleOrDefault();

            if (airplaneInfo == null)
            {
                return NotFound();
            }

            return Ok(airplaneInfo);
        }

        // PUT: api/AirplaneInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAirplaneInfo(int id, AirplaneInfo airplaneInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airplaneInfo.AirplaneTypeID)
            {
                return BadRequest();
            }

            db.Entry(airplaneInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (!AirplaneInfoExists(id))
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

        // POST: api/AirplaneInfoes
        [ResponseType(typeof(AirplaneInfo))]
        public IHttpActionResult PostAirplaneInfo(AirplaneInfo airplaneInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AirplaneInfoes.Add(airplaneInfo);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (AirplaneInfoExists(airplaneInfo.AirplaneTypeID))
                {
                    return Conflict();
                }
                else
                {
                    while (ex.InnerException != null) ex = ex.InnerException;
                    return InternalServerError(ex);
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = airplaneInfo.AirplaneTypeID }, airplaneInfo);
        }

        // DELETE: api/AirplaneInfoes/5
        [ResponseType(typeof(AirplaneInfo))]
        public IHttpActionResult DeleteAirplaneInfo(int id)
        {
            AirplaneInfo airplaneInfo = db.AirplaneInfoes.Find(id);
            if (airplaneInfo == null)
            {
                return NotFound();
            }

            db.AirplaneInfoes.Remove(airplaneInfo);
            db.SaveChanges();

            return Ok(airplaneInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AirplaneInfoExists(int id)
        {
            return db.AirplaneInfoes.Count(e => e.AirplaneTypeID == id) > 0;
        }
    }
}