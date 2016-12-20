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
    public class ESTADOS_EVENTOSController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/ESTADOS_EVENTOS
        public IQueryable<ESTADOS_EVENTOS> GetESTADOS_EVENTOS()
        {
            return db.ESTADOS_EVENTOS;
        }

        // GET: api/ESTADOS_EVENTOS/5
        [ResponseType(typeof(ESTADOS_EVENTOS))]
        public IHttpActionResult GetESTADOS_EVENTOS(int id)
        {
            ESTADOS_EVENTOS eSTADOS_EVENTOS = db.ESTADOS_EVENTOS.Find(id);
            if (eSTADOS_EVENTOS == null)
            {
                return NotFound();
            }

            return Ok(eSTADOS_EVENTOS);
        }

        // PUT: api/ESTADOS_EVENTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutESTADOS_EVENTOS(int id, ESTADOS_EVENTOS eSTADOS_EVENTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eSTADOS_EVENTOS.ESTADO_ID)
            {
                return BadRequest();
            }

            db.Entry(eSTADOS_EVENTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ESTADOS_EVENTOSExists(id))
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

        // POST: api/ESTADOS_EVENTOS
        [ResponseType(typeof(ESTADOS_EVENTOS))]
        public IHttpActionResult PostESTADOS_EVENTOS(ESTADOS_EVENTOS eSTADOS_EVENTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ESTADOS_EVENTOS.Add(eSTADOS_EVENTOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eSTADOS_EVENTOS.ESTADO_ID }, eSTADOS_EVENTOS);
        }

        // DELETE: api/ESTADOS_EVENTOS/5
        [ResponseType(typeof(ESTADOS_EVENTOS))]
        public IHttpActionResult DeleteESTADOS_EVENTOS(int id)
        {
            ESTADOS_EVENTOS eSTADOS_EVENTOS = db.ESTADOS_EVENTOS.Find(id);
            if (eSTADOS_EVENTOS == null)
            {
                return NotFound();
            }

            db.ESTADOS_EVENTOS.Remove(eSTADOS_EVENTOS);
            db.SaveChanges();

            return Ok(eSTADOS_EVENTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ESTADOS_EVENTOSExists(int id)
        {
            return db.ESTADOS_EVENTOS.Count(e => e.ESTADO_ID == id) > 0;
        }
    }
}