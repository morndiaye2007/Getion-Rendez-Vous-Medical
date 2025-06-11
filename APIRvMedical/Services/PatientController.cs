using System.Web.Http;

using ApiRvMedical.Services;
using APIRvMedical.Model;
using APIRvMedical.Services;

namespace ApiRvMedical.Controllers
{
    [RoutePrefix("api/patients")]
    public class PatientController : ApiController
    {
        private readonly IPatientService _patientService;

        public PatientController()
        {
            _patientService = new PatientService(); // ou injecte via un conteneur DI
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(_patientService.GetAll());
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] Patient patient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _patientService.Create(patient);
            return Ok(patient);
        }

        [HttpPut, Route("{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] Patient patient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            _patientService.Update(patient);
            return Ok();
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _patientService.Delete(id);
            return Ok();
        }
    }
}
