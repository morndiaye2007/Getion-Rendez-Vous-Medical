using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections.Generic;
using System.Linq;
using APIRvMedical.Model;
using GestionRV.Model;

namespace ApiRvMedical.Services
{
    public class RendezVousService : IRendezVousService
    {
        private readonly BdRvMedicalContext _context;

        public RendezVousService()
        {
            _context = new BdRvMedicalContext();
        }

        public IEnumerable<RendezVous> GetAll() => _context.RendezVous.ToList();

        public RendezVous GetById(int id) => _context.RendezVous.Find(id);

        public void Create(RendezVous rdv)
        {
            _context.RendezVous.Add(rdv);
            _context.SaveChanges();
        }

        

        public void Delete(int id)
        {
            var r = _context.RendezVous.Find(id);
            if (r != null)
            {
                _context.RendezVous.Remove(r);
                _context.SaveChanges();
            }
        }

      

        public void Update(RendezVous rdv)
        {
            throw new NotImplementedException();
        }

        public bool IsDisponible(int agendaId, string date, string heure)
        {
            throw new NotImplementedException();
        }
    }
}
