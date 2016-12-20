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
    public class MODELOSController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/MODELOS
        public IQueryable<MODELOS> GetMODELOS()
        {
            return db.MODELOS;
        }

        // GET: api/MODELOS/5
        [ResponseType(typeof(MODELOS))]
        public IHttpActionResult GetMODELOS(int id)
        {
            MODELOS mODELOS = db.MODELOS.Find(id);
            if (mODELOS == null)
            {
                return NotFound();
            }

            return Ok(mODELOS);
        }

        // PUT: api/MODELOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMODELOS(int id, MODELOS mODELOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mODELOS.MODELO_ID)
            {
                return BadRequest();
            }

            db.Entry(mODELOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MODELOSExists(id))
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

        // POST: api/MODELOS
        [ResponseType(typeof(MODELOS))]
        public IHttpActionResult PostMODELOS(MODELOS mODELOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MODELOS.Add(mODELOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mODELOS.MODELO_ID }, mODELOS);
        }

        // DELETE: api/MODELOS/5
        [ResponseType(typeof(MODELOS))]
        public IHttpActionResult DeleteMODELOS(int id)
        {
            MODELOS mODELOS = db.MODELOS.Find(id);
            if (mODELOS == null)
            {
                return NotFound();
            }

            db.MODELOS.Remove(mODELOS);
            db.SaveChanges();

            return Ok(mODELOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MODELOSExists(int id)
        {
            return db.MODELOS.Count(e => e.MODELO_ID == id) > 0;
        }
    }
}