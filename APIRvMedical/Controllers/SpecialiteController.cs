using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;


using System.Web.Http;
using System.Web.Http.Description;
using APIRvMedical.Model;
using GestionRV.Model;

namespace APIRvMedical.Controllers
{
    
        public class SpecialiteController : ApiController
        {
            private BdRvMedicalContext db = new BdRvMedicalContext();

            // GET: api/specialite
            [HttpGet]
            public IHttpActionResult GetSpecialites()
            {
                var specialites = db.Specialites.ToList();
                return Ok(specialites);
            }

            // GET: api/specialite/5
            [HttpGet]
            public IHttpActionResult GetSpecialite(int id)
            {
                var specialite = db.Specialites.Find(id);
                if (specialite == null)
                    return NotFound();

                return Ok(specialite);
            }

            // POST: api/specialite
            [HttpPost]
            public IHttpActionResult PostSpecialite([FromBody] Specialite specialite)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                db.Specialites.Add(specialite);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = specialite.IdSpecialite }, specialite);
            }

            // PUT: api/specialite/5
            [HttpPut]
            public IHttpActionResult PutSpecialite(int id, [FromBody] Specialite specialite)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existing = db.Specialites.Find(id);
                if (existing == null)
                    return NotFound();

                existing.CodeSpecialite = specialite.CodeSpecialite;
                existing.NomSpecialite = specialite.NomSpecialite;

                db.Entry(existing).State = EntityState.Modified;
                db.SaveChanges();

                return StatusCode(HttpStatusCode.NoContent);
            }

            // DELETE: api/specialite/5
            [HttpDelete]
            public IHttpActionResult DeleteSpecialite(int id)
            {
                var specialite = db.Specialites.Find(id);
                if (specialite == null)
                    return NotFound();

                db.Specialites.Remove(specialite);
                db.SaveChanges();

                return Ok(specialite);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                    db.Dispose();
                base.Dispose(disposing);
            }
        }

    }
