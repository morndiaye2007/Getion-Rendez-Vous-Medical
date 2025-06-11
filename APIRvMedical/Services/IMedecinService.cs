using System.Collections.Generic;
using APIRvMedical.Model;
namespace ApiRvMedical.Services
{
    public interface IMedecinService
    {
        IEnumerable<Medecin> GetAll();
        Medecin GetById(int id);
        void Create(Medecin medecin);
        void Update(Medecin medecin);
        void Delete(int id);
    }
}