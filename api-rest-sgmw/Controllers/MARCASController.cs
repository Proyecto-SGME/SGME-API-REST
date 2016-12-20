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
    public class MARCASController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/MARCAS
        public IQueryable<MARCAS> GetMARCAS()
        {
            return db.MARCAS;
        }

        // GET: api/MARCAS/5
        [ResponseType(typeof(MARCAS))]
        public IHttpActionResult GetMARCAS(int id)
        {
            MARCAS mARCAS = db.MARCAS.Find(id);
            if (mARCAS == null)
            {
                return NotFound();
            }

            return Ok(mARCAS);
        }

        // PUT: api/MARCAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMARCAS(int id, MARCAS mARCAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mARCAS.MARCA_ID)
            {
                return BadRequest();
            }

            db.Entry(mARCAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MARCASExists(id))
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

        // POST: api/MARCAS
        [ResponseType(typeof(MARCAS))]
        public IHttpActionResult PostMARCAS(MARCAS mARCAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MARCAS.Add(mARCAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mARCAS.MARCA_ID }, mARCAS);
        }

        // DELETE: api/MARCAS/5
        [ResponseType(typeof(MARCAS))]
        public IHttpActionResult DeleteMARCAS(int id)
        {
            MARCAS mARCAS = db.MARCAS.Find(id);
            if (mARCAS == null)
            {
                return NotFound();
            }

            db.MARCAS.Remove(mARCAS);
            db.SaveChanges();

            return Ok(mARCAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MARCASExists(int id)
        {
            return db.MARCAS.Count(e => e.MARCA_ID == id) > 0;
        }
    }
}