using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using APIRvMedical.Model;
using GestionRV.Model;

namespace APIRvMedical.Controllers
{
    public class AgendaController
    {

        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/agenda
        [HttpGet]
        public IHttpActionResult GetAgendas()
        {
            var agendas = db.Agendas
                            .Include(a => a.Medecin)
                            .Include(a => a.rendezVous)
                            .ToList();

            return Ok(agendas);
        }

        // GET: api/agenda/5
        [HttpGet]
        public IHttpActionResult GetAgenda(int id)
        {
            var agenda = db.Agendas
                           .Include(a => a.Medecin)
                           .Include(a => a.rendezVous)
                           .FirstOrDefault(a => a.IdAgenda == id);

            if (agenda == null)
                return NotFound();

            return Ok(agenda);
        }

        // POST: api/agenda
        [HttpPost]
        public IHttpActionResult PostAgenda([FromBody] Agenda agenda)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Agendas.Add(agenda);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agenda.IdAgenda }, agenda);
        }

        // PUT: api/agenda/5
        [HttpPut]
        public IHttpActionResult PutAgenda(int id, [FromBody] Agenda agenda)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = db.Agendas.Find(id);
            if (existing == null)
                return NotFound();

            existing.DatePlanifie = agenda.DatePlanifie;
            existing.Titre = agenda.Titre;
            existing.HeureDebut = agenda.HeureDebut;
            existing.HeureFin = agenda.HeureFin;
            existing.Creneau = agenda.Creneau;
            existing.Lieu = agenda.Lieu;
            existing.Jour = agenda.Jour;
            existing.Statut = agenda.Statut;
            existing.IdMedecin = agenda.IdMedecin;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/agenda/5
        [HttpDelete]
        public IHttpActionResult DeleteAgenda(int id)
        {
            var agenda = db.Agendas.Find(id);
            if (agenda == null)
                return NotFound();

            db.Agendas.Remove(agenda);
            db.SaveChanges();

            return Ok(agenda);
        }

        // Libération du DbContext
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }

}
