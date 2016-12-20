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
    public class EQUIPOS_INSTALADOSController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        // GET: api/EQUIPOS_INSTALADOS
        public IQueryable<EQUIPOS_INSTALADOS> GetEQUIPOS_INSTALADOS()
        {
            return db.EQUIPOS_INSTALADOS;
        }

        // GET: api/EQUIPOS_INSTALADOS/5
        [ResponseType(typeof(EQUIPOS_INSTALADOS))]
        public IHttpActionResult GetEQUIPOS_INSTALADOS(int id)
        {
            EQUIPOS_INSTALADOS eQUIPOS_INSTALADOS = db.EQUIPOS_INSTALADOS.Find(id);
            if (eQUIPOS_INSTALADOS == null)
            {
                return NotFound();
            }

            return Ok(eQUIPOS_INSTALADOS);
        }

        // PUT: api/EQUIPOS_INSTALADOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEQUIPOS_INSTALADOS(int id, EQUIPOS_INSTALADOS eQUIPOS_INSTALADOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eQUIPOS_INSTALADOS.EQUIPO_INSTALADO_ID)
            {
                return BadRequest();
            }

            db.Entry(eQUIPOS_INSTALADOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EQUIPOS_INSTALADOSExists(id))
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

        // POST: api/EQUIPOS_INSTALADOS
        [ResponseType(typeof(EQUIPOS_INSTALADOS))]
        public IHttpActionResult PostEQUIPOS_INSTALADOS(EQUIPOS_INSTALADOS eQUIPOS_INSTALADOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EQUIPOS_INSTALADOS.Add(eQUIPOS_INSTALADOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eQUIPOS_INSTALADOS.EQUIPO_INSTALADO_ID }, eQUIPOS_INSTALADOS);
        }

        // DELETE: api/EQUIPOS_INSTALADOS/5
        [ResponseType(typeof(EQUIPOS_INSTALADOS))]
        public IHttpActionResult DeleteEQUIPOS_INSTALADOS(int id)
        {
            EQUIPOS_INSTALADOS eQUIPOS_INSTALADOS = db.EQUIPOS_INSTALADOS.Find(id);
            if (eQUIPOS_INSTALADOS == null)
            {
                return NotFound();
            }

            db.EQUIPOS_INSTALADOS.Remove(eQUIPOS_INSTALADOS);
            db.SaveChanges();

            return Ok(eQUIPOS_INSTALADOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EQUIPOS_INSTALADOSExists(int id)
        {
            return db.EQUIPOS_INSTALADOS.Count(e => e.EQUIPO_INSTALADO_ID == id) > 0;
        }
    }
}