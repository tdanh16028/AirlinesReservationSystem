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
    public class ProfilesController : ApiController
    {
        private DBUserEntities db = new DBUserEntities();

        // GET: api/Profiles
        public IQueryable<Profile> GetProfiles()
        {
            return db.Profiles;
        }

        // GET: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult GetProfile(long id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfile(long id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.ID)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profiles
        [ResponseType(typeof(Profile))]
        public IHttpActionResult PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = profile.ID }, profile);
        }

        // DELETE: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult DeleteProfile(long id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(profile);
            db.SaveChanges();

            return Ok(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileExists(long id)
        {
            return db.Profiles.Count(e => e.ID == id) > 0;
        }
    }
}