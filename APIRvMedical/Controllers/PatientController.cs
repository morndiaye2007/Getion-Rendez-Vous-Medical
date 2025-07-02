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
    

        public class PatientController : ApiController
        {
            private BdRvMedicalContext db = new BdRvMedicalContext();

            // GET: api/patient
            public IHttpActionResult GetPatients()
            {
                return Ok(db.Patients.ToList());
            }

            // GET: api/patient/5
            public IHttpActionResult GetPatient(int id)
            {
                var patient = db.Patients.Find(id);
                if (patient == null)
                    return NotFound();

                return Ok(patient);
            }

            // POST: api/patient
            [HttpPost]
            public IHttpActionResult PostPatient([FromBody] Patient patient)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex); // Te donne l’erreur détaillée
                }

                return CreatedAtRoute("DefaultApi", new { id = patient.IdU }, patient);
            }

            // PUT: api/patient/5
            [HttpPut]
            public IHttpActionResult PutPatient(int id, [FromBody] Patient patient)
            {
                var existing = db.Patients.Find(id);
                if (existing == null)
                    return NotFound();

                existing.NomPrenom = patient.NomPrenom;
                existing.Adresse = patient.Adresse;
                existing.Email = patient.Email;
                existing.Tel = patient.Tel;
                existing.GroupeSanguin = patient.GroupeSanguin;
                existing.taille = patient.taille;
                existing.Poids = patient.Poids;
                existing.DateNaissance = patient.DateNaissance;

                db.Entry(existing).State = EntityState.Modified;
                db.SaveChanges();

                return StatusCode(HttpStatusCode.NoContent);
            }

            // DELETE: api/patient/5
            [HttpDelete]
            public IHttpActionResult DeletePatient(int id)
            {
                var patient = db.Patients.Find(id);
                if (patient == null)
                    return NotFound();

                db.Patients.Remove(patient);
                db.SaveChanges();

                return Ok(patient);
            }
        }
    } 
