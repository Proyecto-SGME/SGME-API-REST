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
    public class HORARIOS_UBICACIONESController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/HORARIOS_UBICACIONES
        public IQueryable<HORARIOS_UBICACIONES> GetHORARIOS_UBICACIONES()
        {
            return db.HORARIOS_UBICACIONES;
        }

        // GET: api/HORARIOS_UBICACIONES/5
        [ResponseType(typeof(HORARIOS_UBICACIONES))]
        public IHttpActionResult GetHORARIOS_UBICACIONES(int id)
        {
            HORARIOS_UBICACIONES hORARIOS_UBICACIONES = db.HORARIOS_UBICACIONES.Find(id);
            if (hORARIOS_UBICACIONES == null)
            {
                return NotFound();
            }

            return Ok(hORARIOS_UBICACIONES);
        }

        // PUT: api/HORARIOS_UBICACIONES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHORARIOS_UBICACIONES(int id, HORARIOS_UBICACIONES hORARIOS_UBICACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hORARIOS_UBICACIONES.ID_HORARIO)
            {
                return BadRequest();
            }

            db.Entry(hORARIOS_UBICACIONES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HORARIOS_UBICACIONESExists(id))
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

        // POST: api/HORARIOS_UBICACIONES
        [ResponseType(typeof(HORARIOS_UBICACIONES))]
        public IHttpActionResult PostHORARIOS_UBICACIONES(HORARIOS_UBICACIONES hORARIOS_UBICACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HORARIOS_UBICACIONES.Add(hORARIOS_UBICACIONES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hORARIOS_UBICACIONES.ID_HORARIO }, hORARIOS_UBICACIONES);
        }

        // DELETE: api/HORARIOS_UBICACIONES/5
        [ResponseType(typeof(HORARIOS_UBICACIONES))]
        public IHttpActionResult DeleteHORARIOS_UBICACIONES(int id)
        {
            HORARIOS_UBICACIONES hORARIOS_UBICACIONES = db.HORARIOS_UBICACIONES.Find(id);
            if (hORARIOS_UBICACIONES == null)
            {
                return NotFound();
            }

            db.HORARIOS_UBICACIONES.Remove(hORARIOS_UBICACIONES);
            db.SaveChanges();

            return Ok(hORARIOS_UBICACIONES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HORARIOS_UBICACIONESExists(int id)
        {
            return db.HORARIOS_UBICACIONES.Count(e => e.ID_HORARIO == id) > 0;
        }
    }
}