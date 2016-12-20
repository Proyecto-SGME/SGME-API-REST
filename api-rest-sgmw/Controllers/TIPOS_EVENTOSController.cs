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
    public class TIPOS_EVENTOSController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/TIPOS_EVENTOS
        public IQueryable<TIPOS_EVENTOS> GetTIPOS_EVENTOS()
        {
            return db.TIPOS_EVENTOS;
        }

        // GET: api/TIPOS_EVENTOS/5
        [ResponseType(typeof(TIPOS_EVENTOS))]
        public IHttpActionResult GetTIPOS_EVENTOS(int id)
        {
            TIPOS_EVENTOS tIPOS_EVENTOS = db.TIPOS_EVENTOS.Find(id);
            if (tIPOS_EVENTOS == null)
            {
                return NotFound();
            }

            return Ok(tIPOS_EVENTOS);
        }

        // PUT: api/TIPOS_EVENTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIPOS_EVENTOS(int id, TIPOS_EVENTOS tIPOS_EVENTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIPOS_EVENTOS.TIPO_EVENTO_ID)
            {
                return BadRequest();
            }

            db.Entry(tIPOS_EVENTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIPOS_EVENTOSExists(id))
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

        // POST: api/TIPOS_EVENTOS
        [ResponseType(typeof(TIPOS_EVENTOS))]
        public IHttpActionResult PostTIPOS_EVENTOS(TIPOS_EVENTOS tIPOS_EVENTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIPOS_EVENTOS.Add(tIPOS_EVENTOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tIPOS_EVENTOS.TIPO_EVENTO_ID }, tIPOS_EVENTOS);
        }

        // DELETE: api/TIPOS_EVENTOS/5
        [ResponseType(typeof(TIPOS_EVENTOS))]
        public IHttpActionResult DeleteTIPOS_EVENTOS(int id)
        {
            TIPOS_EVENTOS tIPOS_EVENTOS = db.TIPOS_EVENTOS.Find(id);
            if (tIPOS_EVENTOS == null)
            {
                return NotFound();
            }

            db.TIPOS_EVENTOS.Remove(tIPOS_EVENTOS);
            db.SaveChanges();

            return Ok(tIPOS_EVENTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIPOS_EVENTOSExists(int id)
        {
            return db.TIPOS_EVENTOS.Count(e => e.TIPO_EVENTO_ID == id) > 0;
        }
    }
}