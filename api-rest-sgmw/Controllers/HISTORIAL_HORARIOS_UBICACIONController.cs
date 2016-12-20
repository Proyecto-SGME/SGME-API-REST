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
    public class HISTORIAL_HORARIOS_UBICACIONController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/HISTORIAL_HORARIOS_UBICACION
        public IQueryable<HISTORIAL_HORARIOS_UBICACION> GetHISTORIAL_HORARIOS_UBICACION()
        {
            return db.HISTORIAL_HORARIOS_UBICACION;
        }

        // GET: api/HISTORIAL_HORARIOS_UBICACION/5
        [ResponseType(typeof(HISTORIAL_HORARIOS_UBICACION))]
        public IHttpActionResult GetHISTORIAL_HORARIOS_UBICACION(int id)
        {
            HISTORIAL_HORARIOS_UBICACION hISTORIAL_HORARIOS_UBICACION = db.HISTORIAL_HORARIOS_UBICACION.Find(id);
            if (hISTORIAL_HORARIOS_UBICACION == null)
            {
                return NotFound();
            }

            return Ok(hISTORIAL_HORARIOS_UBICACION);
        }

        // PUT: api/HISTORIAL_HORARIOS_UBICACION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHISTORIAL_HORARIOS_UBICACION(int id, HISTORIAL_HORARIOS_UBICACION hISTORIAL_HORARIOS_UBICACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hISTORIAL_HORARIOS_UBICACION.ID)
            {
                return BadRequest();
            }

            db.Entry(hISTORIAL_HORARIOS_UBICACION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HISTORIAL_HORARIOS_UBICACIONExists(id))
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

        // POST: api/HISTORIAL_HORARIOS_UBICACION
        [ResponseType(typeof(HISTORIAL_HORARIOS_UBICACION))]
        public IHttpActionResult PostHISTORIAL_HORARIOS_UBICACION(HISTORIAL_HORARIOS_UBICACION hISTORIAL_HORARIOS_UBICACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HISTORIAL_HORARIOS_UBICACION.Add(hISTORIAL_HORARIOS_UBICACION);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hISTORIAL_HORARIOS_UBICACION.ID }, hISTORIAL_HORARIOS_UBICACION);
        }

        // DELETE: api/HISTORIAL_HORARIOS_UBICACION/5
        [ResponseType(typeof(HISTORIAL_HORARIOS_UBICACION))]
        public IHttpActionResult DeleteHISTORIAL_HORARIOS_UBICACION(int id)
        {
            HISTORIAL_HORARIOS_UBICACION hISTORIAL_HORARIOS_UBICACION = db.HISTORIAL_HORARIOS_UBICACION.Find(id);
            if (hISTORIAL_HORARIOS_UBICACION == null)
            {
                return NotFound();
            }

            db.HISTORIAL_HORARIOS_UBICACION.Remove(hISTORIAL_HORARIOS_UBICACION);
            db.SaveChanges();

            return Ok(hISTORIAL_HORARIOS_UBICACION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HISTORIAL_HORARIOS_UBICACIONExists(int id)
        {
            return db.HISTORIAL_HORARIOS_UBICACION.Count(e => e.ID == id) > 0;
        }
    }
}