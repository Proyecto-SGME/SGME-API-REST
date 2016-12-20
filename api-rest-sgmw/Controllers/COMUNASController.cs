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
using api_rest_sgmw;

namespace api_rest_sgmw.Controllers
{
    public class COMUNASController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/COMUNAS
        public IQueryable<COMUNAS> GetCOMUNAS()
        {
            return db.COMUNAS;
        }

        // GET: api/COMUNAS/5
        [ResponseType(typeof(COMUNAS))]
        public IHttpActionResult GetCOMUNAS(int id)
        {
            COMUNAS cOMUNAS = db.COMUNAS.Find(id);
            if (cOMUNAS == null)
            {
                return NotFound();
            }

            return Ok(cOMUNAS);
        }

        // PUT: api/COMUNAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCOMUNAS(int id, COMUNAS cOMUNAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cOMUNAS.COMUNA_ID)
            {
                return BadRequest();
            }

            db.Entry(cOMUNAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!COMUNASExists(id))
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

        // POST: api/COMUNAS
        [ResponseType(typeof(COMUNAS))]
        public IHttpActionResult PostCOMUNAS(COMUNAS cOMUNAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.COMUNAS.Add(cOMUNAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (COMUNASExists(cOMUNAS.COMUNA_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cOMUNAS.COMUNA_ID }, cOMUNAS);
        }

        // DELETE: api/COMUNAS/5
        [ResponseType(typeof(COMUNAS))]
        public IHttpActionResult DeleteCOMUNAS(int id)
        {
            COMUNAS cOMUNAS = db.COMUNAS.Find(id);
            if (cOMUNAS == null)
            {
                return NotFound();
            }

            db.COMUNAS.Remove(cOMUNAS);
            db.SaveChanges();

            return Ok(cOMUNAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool COMUNASExists(int id)
        {
            return db.COMUNAS.Count(e => e.COMUNA_ID == id) > 0;
        }
    }
}