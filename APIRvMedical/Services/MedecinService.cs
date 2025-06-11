using System.Collections.Generic;
using System.Linq;
using APIRvMedical.Model;
using GestionRV.Model;

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

        public void Create(Medecin m)
        {
            _context.Medecins.Add(m);
            _context.SaveChanges();
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

        public void Update(Medecin medecin)
        {
            throw new System.NotImplementedException();
        }
    }
}
