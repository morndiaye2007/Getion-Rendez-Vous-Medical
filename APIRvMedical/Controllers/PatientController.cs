using APIRvMedical.DTOs;
using APIRvMedical.Model;
using GestionRV.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace APIRvMedical.Controllers
{
    public class PatientController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/patient
        public IHttpActionResult GetPatients()
        {
            var list = db.Patients.ToList();

            var dtoList = list.Select(p => new PatientDto
            {
                IdU = p.IdU,
                NomPrenom = p.NomPrenom,
                Adresse = p.Adresse,
                Email = p.Email,
                Tel = p.Tel,
                GroupeSanguin = p.GroupeSanguin,
                Taille = p.taille,
                Poids = p.Poids,
                DateNaissance = p.DateNaissance
            });

            return Ok(dtoList);
        }

        // GET: api/patient/5
        public IHttpActionResult GetPatient(int id)
        {
            var p = db.Patients.Find(id);
            if (p == null)
                return NotFound();

            var dto = new PatientDto
            {
                IdU = p.IdU,
                NomPrenom = p.NomPrenom,
                Adresse = p.Adresse,
                Email = p.Email,
                Tel = p.Tel,
                GroupeSanguin = p.GroupeSanguin,
                Taille = p.taille,
                Poids = p.Poids,
                DateNaissance = p.DateNaissance
            };

            return Ok(dto);
        }

        // POST: api/patient
        public IHttpActionResult PostPatient([FromBody] PatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var p = new Patient
            {
                NomPrenom = dto.NomPrenom,
                Adresse = dto.Adresse,
                Email = dto.Email,
                Tel = dto.Tel,
                GroupeSanguin = dto.GroupeSanguin,
                taille = dto.Taille,
                Poids = dto.Poids,
                DateNaissance = dto.DateNaissance
            };

            db.Patients.Add(p);
            db.SaveChanges();

            dto.IdU = p.IdU; // met à jour le dto avec l’ID généré
            return CreatedAtRoute("DefaultApi", new { id = dto.IdU }, dto);
        }

        // PUT: api/patient/5
        public IHttpActionResult PutPatient(int id, [FromBody] PatientDto dto)
        {
            var existing = db.Patients.Find(id);
            if (existing == null)
                return NotFound();

            existing.NomPrenom = dto.NomPrenom;
            existing.Adresse = dto.Adresse;
            existing.Email = dto.Email;
            existing.Tel = dto.Tel;
            existing.GroupeSanguin = dto.GroupeSanguin;
            existing.taille = dto.Taille;
            existing.Poids = dto.Poids;
            existing.DateNaissance = dto.DateNaissance;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/patient/5
        public IHttpActionResult DeletePatient(int id)
        {
            var p = db.Patients.Find(id);
            if (p == null)
                return NotFound();

            db.Patients.Remove(p);
            db.SaveChanges();

            return Ok();
        }
    }
}
