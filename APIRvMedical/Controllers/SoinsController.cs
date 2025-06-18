using APIRvMedical.Model;
using GestionRV.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace APIRvMedical.Controllers
{
    public class SoinsController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/soins
        public IHttpActionResult GetSoins()
        {
            var soins = db.Soins.ToList();
            return Ok(soins);
        }

        // GET: api/soins/5
        public IHttpActionResult GetSoin(int id)
        {
            var soin = db.Soins.Find(id);
            if (soin == null)
                return NotFound();

            return Ok(soin);
        }

        // POST: api/soins
        public IHttpActionResult PostSoin([FromBody] Soin soin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Soins.Add(soin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = soin.Idsoin }, soin);
        }

        // PUT: api/soins/5
        public IHttpActionResult PutSoin(int id, [FromBody] Soin soin)
        {
            var existing = db.Soins.Find(id);
            if (existing == null)
                return NotFound();

            existing.Nom = soin.Nom;
            existing.Description = soin.Description;
            existing.Prix = soin.Prix;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/soins/5
        public IHttpActionResult DeleteSoin(int id)
        {
            var soin = db.Soins.Find(id);
            if (soin == null)
                return NotFound();

            db.Soins.Remove(soin);
            db.SaveChanges();

            return Ok(soin);
        }
    }
}
