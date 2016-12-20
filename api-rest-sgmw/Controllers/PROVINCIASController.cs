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
    public class PROVINCIASController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/PROVINCIAS
        public IQueryable<PROVINCIAS> GetPROVINCIAS()
        {
            return db.PROVINCIAS;
        }

        // GET: api/PROVINCIAS/5
        [ResponseType(typeof(PROVINCIAS))]
        public IHttpActionResult GetPROVINCIAS(int id)
        {
            PROVINCIAS pROVINCIAS = db.PROVINCIAS.Find(id);
            if (pROVINCIAS == null)
            {
                return NotFound();
            }

            return Ok(pROVINCIAS);
        }

        // PUT: api/PROVINCIAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPROVINCIAS(int id, PROVINCIAS pROVINCIAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pROVINCIAS.PROVINCIA_ID)
            {
                return BadRequest();
            }

            db.Entry(pROVINCIAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROVINCIASExists(id))
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

        // POST: api/PROVINCIAS
        [ResponseType(typeof(PROVINCIAS))]
        public IHttpActionResult PostPROVINCIAS(PROVINCIAS pROVINCIAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PROVINCIAS.Add(pROVINCIAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PROVINCIASExists(pROVINCIAS.PROVINCIA_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pROVINCIAS.PROVINCIA_ID }, pROVINCIAS);
        }

        // DELETE: api/PROVINCIAS/5
        [ResponseType(typeof(PROVINCIAS))]
        public IHttpActionResult DeletePROVINCIAS(int id)
        {
            PROVINCIAS pROVINCIAS = db.PROVINCIAS.Find(id);
            if (pROVINCIAS == null)
            {
                return NotFound();
            }

            db.PROVINCIAS.Remove(pROVINCIAS);
            db.SaveChanges();

            return Ok(pROVINCIAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PROVINCIASExists(int id)
        {
            return db.PROVINCIAS.Count(e => e.PROVINCIA_ID == id) > 0;
        }
    }
}