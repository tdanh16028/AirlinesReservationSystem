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
    public class AdminAccountsController : ApiController
    {
        private DBUserEntities db = new DBUserEntities();

        // GET: api/AdminAccounts
        public IQueryable<AdminAccount> GetAdminAccounts()
        {
            return db.AdminAccounts;
        }

        // GET: api/AdminAccounts/5
        [ResponseType(typeof(AdminAccount))]
        public IHttpActionResult GetAdminAccount(int id)
        {
            AdminAccount adminAccount = db.AdminAccounts.Find(id);
            if (adminAccount == null)
            {
                return NotFound();
            }

            return Ok(adminAccount);
        }

        // PUT: api/AdminAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdminAccount(int id, AdminAccount adminAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminAccount.ID)
            {
                return BadRequest();
            }

            db.Entry(adminAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (!AdminAccountExists(id))
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

        // POST: api/AdminAccounts
        [ResponseType(typeof(AdminAccount))]
        public IHttpActionResult PostAdminAccount(AdminAccount adminAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.AdminAccounts.Add(adminAccount);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                return InternalServerError(ex);
            }

            return CreatedAtRoute("DefaultApi", new { id = adminAccount.ID }, adminAccount);
        }

        // DELETE: api/AdminAccounts/5
        [ResponseType(typeof(AdminAccount))]
        public IHttpActionResult DeleteAdminAccount(int id)
        {
            AdminAccount adminAccount = db.AdminAccounts.Find(id);
            if (adminAccount == null)
            {
                return NotFound();
            }

            db.AdminAccounts.Remove(adminAccount);
            db.SaveChanges();

            return Ok(adminAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminAccountExists(int id)
        {
            return db.AdminAccounts.Count(e => e.ID == id) > 0;
        }
    }
}