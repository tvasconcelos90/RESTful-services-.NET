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
using Restful_services.Models;

namespace Restful_services.Controllers
{
    public class TarefasController : ApiController
    {
        private TarefasContext db = new TarefasContext();

        // GET: api/Tarefas
        public IQueryable<Tarefas> GetTarefas()
        {
            return db.Tarefas;
        }

        // GET: api/Tarefas/5
        [ResponseType(typeof(Tarefas))]
        public IHttpActionResult GetTarefas(int id)
        {
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return Ok(tarefas);
        }

        // PUT: api/Tarefas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarefas(int id, Tarefas tarefas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarefas.Id)
            {
                return BadRequest();
            }

            db.Entry(tarefas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefasExists(id))
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

        // POST: api/Tarefas
        [ResponseType(typeof(Tarefas))]
        public IHttpActionResult PostTarefas(Tarefas tarefas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tarefas.Add(tarefas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tarefas.Id }, tarefas);
        }

        // DELETE: api/Tarefas/5
        [ResponseType(typeof(Tarefas))]
        public IHttpActionResult DeleteTarefas(int id)
        {
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return NotFound();
            }

            db.Tarefas.Remove(tarefas);
            db.SaveChanges();

            return Ok(tarefas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TarefasExists(int id)
        {
            return db.Tarefas.Count(e => e.Id == id) > 0;
        }
    }
}