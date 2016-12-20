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
    public class DETALLES_EVENTOSController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/DETALLES_EVENTOS
        public IQueryable<DETALLES_EVENTOS> GetDETALLES_EVENTOS()
        {
            return db.DETALLES_EVENTOS;
        }

        // GET: api/DETALLES_EVENTOS/5
        [ResponseType(typeof(DETALLES_EVENTOS))]
        public IHttpActionResult GetDETALLES_EVENTOS(int id)
        {
            DETALLES_EVENTOS dETALLES_EVENTOS = db.DETALLES_EVENTOS.Find(id);
            if (dETALLES_EVENTOS == null)
            {
                return NotFound();
            }

            return Ok(dETALLES_EVENTOS);
        }

        // PUT: api/DETALLES_EVENTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLES_EVENTOS(int id, DETALLES_EVENTOS dETALLES_EVENTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLES_EVENTOS.DETALLE_EVENTO_ID)
            {
                return BadRequest();
            }

            db.Entry(dETALLES_EVENTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLES_EVENTOSExists(id))
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

        // POST: api/DETALLES_EVENTOS
        [ResponseType(typeof(DETALLES_EVENTOS))]
        public IHttpActionResult PostDETALLES_EVENTOS(DETALLES_EVENTOS dETALLES_EVENTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DETALLES_EVENTOS.Add(dETALLES_EVENTOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dETALLES_EVENTOS.DETALLE_EVENTO_ID }, dETALLES_EVENTOS);
        }

        // DELETE: api/DETALLES_EVENTOS/5
        [ResponseType(typeof(DETALLES_EVENTOS))]
        public IHttpActionResult DeleteDETALLES_EVENTOS(int id)
        {
            DETALLES_EVENTOS dETALLES_EVENTOS = db.DETALLES_EVENTOS.Find(id);
            if (dETALLES_EVENTOS == null)
            {
                return NotFound();
            }

            db.DETALLES_EVENTOS.Remove(dETALLES_EVENTOS);
            db.SaveChanges();

            return Ok(dETALLES_EVENTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLES_EVENTOSExists(int id)
        {
            return db.DETALLES_EVENTOS.Count(e => e.DETALLE_EVENTO_ID == id) > 0;
        }
    }
}