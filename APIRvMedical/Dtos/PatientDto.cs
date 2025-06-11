using APIRvMedical.DTOs;
using APIRvMedical.Model;
using GestionRV.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace APIRvMedical.Controllers
{
    public class RendezVousController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/rendezvous
        public IHttpActionResult GetRendezVous()
        {
            var list = db.RendezVous
                         .Include(r => r.Patient)
                         .Include(r => r.Medecin)
                         .Include(r => r.Soin)
                         .ToList();

            var dtoList = list.Select(r => new RendezVousDto
            {
                IdRv = r.IdRv,
                DateRv = r.DateRv,
                Statut = r.Statut,
                IdMedecin = r.IdMedecin,
                NomMedecin = r.Medecin?.NomPrenom,
                IdPatient = r.IdPatient,
                NomPatient = r.Patient?.NomPrenom,
                IdSoin = r.IdSoin,
                NomSoin = r.Soin?.Nom
            });

            return Ok(dtoList);
        }

        // GET: api/rendezvous/5
        public IHttpActionResult GetRendezVous(int id)
        {
            var r = db.RendezVous
                      .Include(x => x.Patient)
                      .Include(x => x.Medecin)
                      .Include(x => x.Soin)
                      .FirstOrDefault(x => x.IdRv == id);

            if (r == null)
                return NotFound();

            var dto = new RendezVousDto
            {
                IdRv = r.IdRv,
                DateRv = r.DateRv,
                Statut = r.Statut,
                IdMedecin = r.IdMedecin,
                NomMedecin = r.Medecin?.NomPrenom,
                IdPatient = r.IdPatient,
                NomPatient = r.Patient?.NomPrenom,
                IdSoin = r.IdSoin,
                NomSoin = r.Soin?.Nom
            };

            return Ok(dto);
        }

        // POST: api/rendezvous
        public IHttpActionResult PostRendezVous([FromBody] RendezVousDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var r = new RendezVous
            {
                DateRv = dto.DateRv,
                Statut = dto.Statut,
                IdMedecin = dto.IdMedecin,
                IdPatient = dto.IdPatient,
                IdSoin = dto.IdSoin
            };

            db.RendezVous.Add(r);
            db.SaveChanges();
            dto.IdRv = r.IdRv;

            return CreatedAtRoute("DefaultApi", new { id = r.IdRv }, dto);
        }

        // PUT: api/rendezvous/5
        public IHttpActionResult PutRendezVous(int id, [FromBody] RendezVousDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var r = db.RendezVous.Find(id);
            if (r == null)
                return NotFound();

            r.DateRv = dto.DateRv;
            r.Statut = dto.Statut;
            r.IdMedecin = dto.IdMedecin;
            r.IdPatient = dto.IdPatient;
            r.IdSoin = dto.IdSoin;

            db.Entry(r).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/rendezvous/5
        public IHttpActionResult DeleteRendezVous(int id)
        {
            var r = db.RendezVous.Find(id);
            if (r == null)
                return NotFound();

            db.RendezVous.Remove(r);
            db.SaveChanges();

            return Ok();
        }
    }
}
