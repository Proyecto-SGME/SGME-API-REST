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
    public class CONTACTOSController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/CONTACTOS
        public IQueryable<CONTACTOS> GetCONTACTOS()
        {
            return db.CONTACTOS;
        }

        // GET: api/CONTACTOS/5
        [ResponseType(typeof(CONTACTOS))]
        public IHttpActionResult GetCONTACTOS(int id)
        {
            CONTACTOS cONTACTOS = db.CONTACTOS.Find(id);
            if (cONTACTOS == null)
            {
                return NotFound();
            }

            return Ok(cONTACTOS);
        }

        // PUT: api/CONTACTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCONTACTOS(int id, CONTACTOS cONTACTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cONTACTOS.CONTACTO_ID)
            {
                return BadRequest();
            }

            db.Entry(cONTACTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONTACTOSExists(id))
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

        // POST: api/CONTACTOS
        [ResponseType(typeof(CONTACTOS))]
        public IHttpActionResult PostCONTACTOS(CONTACTOS cONTACTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CONTACTOS.Add(cONTACTOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cONTACTOS.CONTACTO_ID }, cONTACTOS);
        }

        // DELETE: api/CONTACTOS/5
        [ResponseType(typeof(CONTACTOS))]
        public IHttpActionResult DeleteCONTACTOS(int id)
        {
            CONTACTOS cONTACTOS = db.CONTACTOS.Find(id);
            if (cONTACTOS == null)
            {
                return NotFound();
            }

            db.CONTACTOS.Remove(cONTACTOS);
            db.SaveChanges();

            return Ok(cONTACTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CONTACTOSExists(int id)
        {
            return db.CONTACTOS.Count(e => e.CONTACTO_ID == id) > 0;
        }
    }
}