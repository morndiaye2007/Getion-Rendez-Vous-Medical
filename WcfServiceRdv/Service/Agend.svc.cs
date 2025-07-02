using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using WcfServiceRdv.Helper;

using WcfServiceRdv.Models;

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WcfServiceRdv.Models;
using WcfServiceRdv.Helper;
using AppGestionRdv.Service;

namespace WcfServiceRdv.Service
{
    public class Agend : IAgend
    {
        BdRvMedicalContext db = new BdRvMedicalContext();

        public void DoWork() { }

        public List<Agenda> GetListeAgenda()
        {
            return db.Agendas.ToList();
        }

        public bool AddAgenda(Agenda agenda)
        {
            try
            {
                db.Agendas.Add(agenda);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.Message);
                return false;
            }
        }

        public bool UpdateAgenda(Agenda agenda)
        {
            try
            {
                db.Entry(agenda).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.Message);
                return false;
            }
        }

        public Medecin GetMedecinById(int id)
        {
            return db.Medecins.Find(id);
        }

        public bool DeleteAgenda(int id)
        {
            try
            {
                var agenda = db.Agendas.Find(id);
                if (agenda != null)
                {
                    db.Agendas.Remove(agenda);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.Message);
            }
            return false;
        }

        public Agenda GetAgendaById(int id)
        {
            return db.Agendas.Find(id);
        }

        public List<Agenda> GetAgendaByMedecin(int idMedecin)
        {
            return db.Agendas
                     .Include(a => a.Medecin)
                     .Where(a => a.IdMedecin == idMedecin)
                     .ToList();
        }
    }
}

