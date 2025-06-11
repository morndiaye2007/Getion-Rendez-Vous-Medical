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
            return Ok(db.Medecins.Include(m => m.Specialite).ToList());
        }

        // GET: api/medecin/5
        public IHttpActionResult GetMedecin(int id)
        {
            var medecin = db.Medecins.Include(m => m.Specialite).FirstOrDefault(m => m.IdU == id);
            if (medecin == null)
                return NotFound();

            return Ok(medecin);
        }

        // POST: api/medecin
        public IHttpActionResult PostMedecin([FromBody] Medecin medecin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Medecins.Add(medecin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medecin.IdU }, medecin);
        }

        // PUT: api/medecin/5
        public IHttpActionResult PutMedecin(int id, [FromBody] Medecin medecin)
        {
            var existing = db.Medecins.Find(id);
            if (existing == null)
                return NotFound();

            existing.NomPrenom = medecin.NomPrenom;
            existing.Adresse = medecin.Adresse;
            existing.Email = medecin.Email;
            existing.Tel = medecin.Tel;
            existing.Identifiant = medecin.Identifiant;
            existing.MotDePasse = medecin.MotDePasse;
            existing.Statut = medecin.Statut;
            existing.NumeroOrdre = medecin.NumeroOrdre;
            existing.IdSpecialite = medecin.IdSpecialite;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/medecin/5
        public IHttpActionResult DeleteMedecin(int id)
        {
            var medecin = db.Medecins.Find(id);
            if (medecin == null)
                return NotFound();

            db.Medecins.Remove(medecin);
            db.SaveChanges();

            return Ok(medecin);
        }
    }
}
