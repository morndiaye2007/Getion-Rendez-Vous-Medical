using System.Collections.Generic;
using System.Linq;
using APIRvMedical.Model;

namespace ApiRvMedical.Services
{
    public class MedecinService : IMedecinService
    {
        private readonly BdRvMedicalContext _context;

        public MedecinService()
        {
            _context = new BdRvMedicalContext();
        }

        public IEnumerable<Medecin> GetAll() => _context.Medecins.ToList();

        public Medecin GetById(int id) => _context.Medecins.Find(id);

        public void Create(Medecin medecin)
        {
            _context.Medecins.Add(medecin);
            _context.SaveChanges();
        }

        public void Update(Medecin medecin)
        {
            var m = _context.Medecins.Find(medecin.Id);
            if (m != null)
            {
                m.Nom = medecin.Nom;
                m.Prenom = medecin.Prenom;
                m.SpecialiteId = medecin.SpecialiteId;
                m.Telephone = medecin.Telephone;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var m = _context.Medecins.Find(id);
            if (m != null)
            {
                _context.Medecins.Remove(m);
                _context.SaveChanges();
            }
        }
    }
}
