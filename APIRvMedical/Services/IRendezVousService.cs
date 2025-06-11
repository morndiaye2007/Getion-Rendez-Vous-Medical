using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using APIRvMedical.Model;

namespace ApiRvMedical.Services
{
    public interface IRendezVousService
    {
        IEnumerable<RendezVous> GetAll();
        RendezVous GetById(int id);
        void Create(RendezVous rdv);
        void Update(RendezVous rdv);
        void Delete(int id);
        bool IsDisponible(int agendaId, string date, string heure);
    }
}

