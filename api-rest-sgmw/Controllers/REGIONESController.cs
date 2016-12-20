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
    public class REGIONESController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/REGIONES
        public IQueryable<REGIONES> GetREGIONES()
        {
            return db.REGIONES;
        }

        // GET: api/REGIONES/5
        [ResponseType(typeof(REGIONES))]
        public IHttpActionResult GetREGIONES(int id)
        {
            REGIONES rEGIONES = db.REGIONES.Find(id);
            if (rEGIONES == null)
            {
                return NotFound();
            }

            return Ok(rEGIONES);
        }

        // PUT: api/REGIONES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutREGIONES(int id, REGIONES rEGIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rEGIONES.REGION_ID)
            {
                return BadRequest();
            }

            db.Entry(rEGIONES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!REGIONESExists(id))
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

        // POST: api/REGIONES
        [ResponseType(typeof(REGIONES))]
        public IHttpActionResult PostREGIONES(REGIONES rEGIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.REGIONES.Add(rEGIONES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (REGIONESExists(rEGIONES.REGION_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rEGIONES.REGION_ID }, rEGIONES);
        }

        // DELETE: api/REGIONES/5
        [ResponseType(typeof(REGIONES))]
        public IHttpActionResult DeleteREGIONES(int id)
        {
            REGIONES rEGIONES = db.REGIONES.Find(id);
            if (rEGIONES == null)
            {
                return NotFound();
            }

            db.REGIONES.Remove(rEGIONES);
            db.SaveChanges();

            return Ok(rEGIONES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool REGIONESExists(int id)
        {
            return db.REGIONES.Count(e => e.REGION_ID == id) > 0;
        }
    }
}