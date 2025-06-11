using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIRvMedical.Model;
using GestionRV.Model;


namespace APIRvMedical.Services
{
    public class PatientService : IPatientService
    {
        private readonly BdRvMedicalContext _context;

        public PatientService()
        {
            _context = new BdRvMedicalContext();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Find(id);
        }

        public void Create(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        

        public void Delete(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }

        public void Update(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}