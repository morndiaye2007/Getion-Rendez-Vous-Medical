using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using APIRvMedical.Model;

namespace ApiRvMedical.Services
{
    public interface IAgendaService
    {
        IEnumerable<Agenda> GetAll();
        Agenda GetById(int id);
        void Create(Agenda agenda);
        void Update(Agenda agenda);
        void Delete(int id);
    }
}

