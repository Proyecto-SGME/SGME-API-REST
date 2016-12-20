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
    public class CLIENTESController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/CLIENTES
        public IQueryable<CLIENTES> GetCLIENTES()
        {
            return db.CLIENTES;
        }

        // GET: api/CLIENTES/5
        [ResponseType(typeof(CLIENTES))]
        public IHttpActionResult GetCLIENTES(int id)
        {
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return NotFound();
            }

            return Ok(cLIENTES);
        }

        // PUT: api/CLIENTES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCLIENTES(int id, CLIENTES cLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cLIENTES.CLIENTE_RUT)
            {
                return BadRequest();
            }

            db.Entry(cLIENTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLIENTESExists(id))
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

        // POST: api/CLIENTES
        [ResponseType(typeof(CLIENTES))]
        public IHttpActionResult PostCLIENTES(CLIENTES cLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CLIENTES.Add(cLIENTES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CLIENTESExists(cLIENTES.CLIENTE_RUT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cLIENTES.CLIENTE_RUT }, cLIENTES);
        }

        // DELETE: api/CLIENTES/5
        [ResponseType(typeof(CLIENTES))]
        public IHttpActionResult DeleteCLIENTES(int id)
        {
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return NotFound();
            }

            db.CLIENTES.Remove(cLIENTES);
            db.SaveChanges();

            return Ok(cLIENTES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CLIENTESExists(int id)
        {
            return db.CLIENTES.Count(e => e.CLIENTE_RUT == id) > 0;
        }
    }
}