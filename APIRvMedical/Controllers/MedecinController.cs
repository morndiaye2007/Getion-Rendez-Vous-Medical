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
    public class MedecinController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/medecin
        public IHttpActionResult GetMedecins()
        {
            var medecins = db.Medecins.Include(m => m.Specialite).ToList();

            var dtoList = medecins.Select(m => new MedecinDto
            {
                IdU = m.IdU,
                NomPrenom = m.NomPrenom,
                Adresse = m.Adresse,
                Email = m.Email,
                Tel = m.Tel,
                Identifiant = m.Identifiant,
                MotDePasse = m.MotDePasse,
                Statut = m.Statut,
                NumeroOrdre = m.NumeroOrdre,
                IdSpecialite = m.IdSpecialite,
                SpecialiteNom = m.Specialite?.Nom
            });

            return Ok(dtoList);
        }

        // GET: api/medecin/5
        public IHttpActionResult GetMedecin(int id)
        {
            var m = db.Medecins.Include(x => x.Specialite).FirstOrDefault(x => x.IdU == id);
            if (m == null)
                return NotFound();

            var dto = new MedecinDto
            {
                IdU = m.IdU,
                NomPrenom = m.NomPrenom,
                Adresse = m.Adresse,
                Email = m.Email,
                Tel = m.Tel,
                Identifiant = m.Identifiant,
                MotDePasse = m.MotDePasse,
                Statut = m.Statut,
                NumeroOrdre = m.NumeroOrdre,
                IdSpecialite = m.IdSpecialite,
                SpecialiteNom = m.Specialite?.Nom
            };

            return Ok(dto);
        }

        // POST: api/medecin
        public IHttpActionResult PostMedecin([FromBody] MedecinDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var m = new Medecin
            {
                NomPrenom = dto.NomPrenom,
                Adresse = dto.Adresse,
                Email = dto.Email,
                Tel = dto.Tel,
                Identifiant = dto.Identifiant,
                MotDePasse = dto.MotDePasse,
                Statut = dto.Statut,
                NumeroOrdre = dto.NumeroOrdre,
                IdSpecialite = dto.IdSpecialite
            };

            db.Medecins.Add(m);
            db.SaveChanges();

            dto.IdU = m.IdU;
            return CreatedAtRoute("DefaultApi", new { id = m.IdU }, dto);
        }

        // PUT: api/medecin/5
        public IHttpActionResult PutMedecin(int id, [FromBody] MedecinDto dto)
        {
            var m = db.Medecins.Find(id);
            if (m == null)
                return NotFound();

            m.NomPrenom = dto.NomPrenom;
            m.Adresse = dto.Adresse;
            m.Email = dto.Email;
            m.Tel = dto.Tel;
            m.Identifiant = dto.Identifiant;
            m.MotDePasse = dto.MotDePasse;
            m.Statut = dto.Statut;
            m.NumeroOrdre = dto.NumeroOrdre;
            m.IdSpecialite = dto.IdSpecialite;

            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/medecin/5
        public IHttpActionResult DeleteMedecin(int id)
        {
            var m = db.Medecins.Find(id);
            if (m == null)
                return NotFound();

            db.Medecins.Remove(m);
            db.SaveChanges();

            return Ok();
        }
    }
}
