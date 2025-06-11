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
    public class AgendaService : IAgendaService
    {
        private readonly BdRvMedicalContext _context;

        public AgendaService()
        {
            _context = new BdRvMedicalContext();
        }

        public IEnumerable<Agenda> GetAll() => _context.Agendas.ToList();

        public Agenda GetById(int id) => _context.Agendas.Find(id);

        public void Create(Agenda agenda)
        {
            _context.Agendas.Add(agenda);
            _context.SaveChanges();
        }

        public void Update(Agenda agenda)
        {
            var a = _context.Agendas.Find(agenda.IdAgenda);
            if (a != null)
            {
                a.IdMedecin = agenda.IdMedecin;
                a.Jour = agenda.Jour;
                a.HeureDebut = agenda.HeureDebut;
                a.HeureFin = agenda.HeureFin;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var a = _context.Agendas.Find(id);
            if (a != null)
            {
                _context.Agendas.Remove(a);
                _context.SaveChanges();
            }
        }
    }
}
