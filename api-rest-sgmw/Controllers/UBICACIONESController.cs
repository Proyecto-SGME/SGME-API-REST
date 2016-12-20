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
    public class UBICACIONESController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/UBICACIONES
        public IQueryable<UBICACIONES> GetUBICACIONES()
        {
            return db.UBICACIONES;
        }

        // GET: api/UBICACIONES/5
        [ResponseType(typeof(UBICACIONES))]
        public IHttpActionResult GetUBICACIONES(int id)
        {
            UBICACIONES uBICACIONES = db.UBICACIONES.Find(id);
            if (uBICACIONES == null)
            {
                return NotFound();
            }

            return Ok(uBICACIONES);
        }

        // PUT: api/UBICACIONES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUBICACIONES(int id, UBICACIONES uBICACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uBICACIONES.UBICACION_ID)
            {
                return BadRequest();
            }

            db.Entry(uBICACIONES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UBICACIONESExists(id))
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

        // POST: api/UBICACIONES
        [ResponseType(typeof(UBICACIONES))]
        public IHttpActionResult PostUBICACIONES(UBICACIONES uBICACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UBICACIONES.Add(uBICACIONES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uBICACIONES.UBICACION_ID }, uBICACIONES);
        }

        // DELETE: api/UBICACIONES/5
        [ResponseType(typeof(UBICACIONES))]
        public IHttpActionResult DeleteUBICACIONES(int id)
        {
            UBICACIONES uBICACIONES = db.UBICACIONES.Find(id);
            if (uBICACIONES == null)
            {
                return NotFound();
            }

            db.UBICACIONES.Remove(uBICACIONES);
            db.SaveChanges();

            return Ok(uBICACIONES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UBICACIONESExists(int id)
        {
            return db.UBICACIONES.Count(e => e.UBICACION_ID == id) > 0;
        }
    }
}