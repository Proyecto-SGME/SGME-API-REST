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
    public class RUTASController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/RUTAS
        public IQueryable<RUTAS> GetRUTAS()
        {
            return db.RUTAS;
        }

        // GET: api/RUTAS/5
        [ResponseType(typeof(RUTAS))]
        public IHttpActionResult GetRUTAS(int id)
        {
            RUTAS rUTAS = db.RUTAS.Find(id);
            if (rUTAS == null)
            {
                return NotFound();
            }

            return Ok(rUTAS);
        }

        // PUT: api/RUTAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRUTAS(int id, RUTAS rUTAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rUTAS.RUTA_ID)
            {
                return BadRequest();
            }

            db.Entry(rUTAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RUTASExists(id))
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

        // POST: api/RUTAS
        [ResponseType(typeof(RUTAS))]
        public IHttpActionResult PostRUTAS(RUTAS rUTAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RUTAS.Add(rUTAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rUTAS.RUTA_ID }, rUTAS);
        }

        // DELETE: api/RUTAS/5
        [ResponseType(typeof(RUTAS))]
        public IHttpActionResult DeleteRUTAS(int id)
        {
            RUTAS rUTAS = db.RUTAS.Find(id);
            if (rUTAS == null)
            {
                return NotFound();
            }

            db.RUTAS.Remove(rUTAS);
            db.SaveChanges();

            return Ok(rUTAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RUTASExists(int id)
        {
            return db.RUTAS.Count(e => e.RUTA_ID == id) > 0;
        }
    }
}