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
    public class DATOS_CLIENTESController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/DATOS_CLIENTES
        public IQueryable<DATOS_CLIENTES> GetDATOS_CLIENTES()
        {
            return db.DATOS_CLIENTES;
        }

        // GET: api/DATOS_CLIENTES/5
        [ResponseType(typeof(DATOS_CLIENTES))]
        public IHttpActionResult GetDATOS_CLIENTES(int id)
        {
            DATOS_CLIENTES dATOS_CLIENTES = db.DATOS_CLIENTES.Find(id);
            if (dATOS_CLIENTES == null)
            {
                return NotFound();
            }

            return Ok(dATOS_CLIENTES);
        }

        // PUT: api/DATOS_CLIENTES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDATOS_CLIENTES(int id, DATOS_CLIENTES dATOS_CLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dATOS_CLIENTES.DATOS_CLIENTE_ID)
            {
                return BadRequest();
            }

            db.Entry(dATOS_CLIENTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DATOS_CLIENTESExists(id))
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

        // POST: api/DATOS_CLIENTES
        [ResponseType(typeof(DATOS_CLIENTES))]
        public IHttpActionResult PostDATOS_CLIENTES(DATOS_CLIENTES dATOS_CLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DATOS_CLIENTES.Add(dATOS_CLIENTES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dATOS_CLIENTES.DATOS_CLIENTE_ID }, dATOS_CLIENTES);
        }

        // DELETE: api/DATOS_CLIENTES/5
        [ResponseType(typeof(DATOS_CLIENTES))]
        public IHttpActionResult DeleteDATOS_CLIENTES(int id)
        {
            DATOS_CLIENTES dATOS_CLIENTES = db.DATOS_CLIENTES.Find(id);
            if (dATOS_CLIENTES == null)
            {
                return NotFound();
            }

            db.DATOS_CLIENTES.Remove(dATOS_CLIENTES);
            db.SaveChanges();

            return Ok(dATOS_CLIENTES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DATOS_CLIENTESExists(int id)
        {
            return db.DATOS_CLIENTES.Count(e => e.DATOS_CLIENTE_ID == id) > 0;
        }
    }
}