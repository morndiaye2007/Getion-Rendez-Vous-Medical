using APIRvMedical.Model;
using GestionRV.Model;
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
        [HttpGet]
        public IHttpActionResult GetRendezVous()
        {
            var rendezVousList = db.RendezVous
                                   .Include(r => r.Patient)
                                   .Include(r => r.Medecin)
                                   .Include(r => r.Soin)
                                   .ToList();

            return Ok(rendezVousList);
        }

        // GET: api/rendezvous/5
        [HttpGet]
        public IHttpActionResult GetRendezVous(int id)
        {
            var rendezVous = db.RendezVous
                               .Include(r => r.Patient)
                               .Include(r => r.Medecin)
                               .Include(r => r.Soin)
                               .FirstOrDefault(r => r.IdRv == id);

            if (rendezVous == null)
                return NotFound();

            return Ok(rendezVous);
        }

        // POST: api/rendezvous
        [HttpPost]
        public IHttpActionResult PostRendezVous([FromBody] RendezVous rv)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.RendezVous.Add(rv);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rv.IdRv }, rv);
        }

        // PUT: api/rendezvous/5
        [HttpPut]
        public IHttpActionResult PutRendezVous(int id, [FromBody] RendezVous rv)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRv = db.RendezVous.Find(id);
            if (existingRv == null)
                return NotFound();

            existingRv.DateRv = rv.DateRv;
            existingRv.Statut = rv.Statut;
            existingRv.IdMedecin = rv.IdMedecin;
            existingRv.IdPatient = rv.IdPatient;
            existingRv.IdSoin = rv.IdSoin;

            db.Entry(existingRv).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/rendezvous/5
        [HttpDelete]
        public IHttpActionResult DeleteRendezVous(int id)
        {
            var rv = db.RendezVous.Find(id);
            if (rv == null)
                return NotFound();

            db.RendezVous.Remove(rv);
            db.SaveChanges();

            return Ok(rv);
        }

        // Bonne pratique : Libérer le contexte
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
