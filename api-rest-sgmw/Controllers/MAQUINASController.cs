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
    public class MAQUINASController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/MAQUINAS
        public IQueryable<MAQUINAS> GetMAQUINAS()
        {
            return db.MAQUINAS;
        }

        // GET: api/MAQUINAS/5
        [ResponseType(typeof(MAQUINAS))]
        public IHttpActionResult GetMAQUINAS(int id)
        {
            MAQUINAS mAQUINAS = db.MAQUINAS.Find(id);
            if (mAQUINAS == null)
            {
                return NotFound();
            }

            return Ok(mAQUINAS);
        }

        // PUT: api/MAQUINAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMAQUINAS(int id, MAQUINAS mAQUINAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mAQUINAS.MAQUINA_ID)
            {
                return BadRequest();
            }

            db.Entry(mAQUINAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MAQUINASExists(id))
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

        // POST: api/MAQUINAS
        [ResponseType(typeof(MAQUINAS))]
        public IHttpActionResult PostMAQUINAS(MAQUINAS mAQUINAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MAQUINAS.Add(mAQUINAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mAQUINAS.MAQUINA_ID }, mAQUINAS);
        }

        // DELETE: api/MAQUINAS/5
        [ResponseType(typeof(MAQUINAS))]
        public IHttpActionResult DeleteMAQUINAS(int id)
        {
            MAQUINAS mAQUINAS = db.MAQUINAS.Find(id);
            if (mAQUINAS == null)
            {
                return NotFound();
            }

            db.MAQUINAS.Remove(mAQUINAS);
            db.SaveChanges();

            return Ok(mAQUINAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MAQUINASExists(int id)
        {
            return db.MAQUINAS.Count(e => e.MAQUINA_ID == id) > 0;
        }
    }
}