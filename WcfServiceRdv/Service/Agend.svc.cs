using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GestionRV.Model;
using GestionRV.Helper;
using WcfServiceRdv.Helper;

namespace WcfServiceRdv.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Agend" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Agend.svc ou Agend.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Agend : IAgend
    {
        public void DoWork()
        {
        }


        BdRvMedicalContext db = new BdRvMedicalContext();

        /// <summary>
        /// Récupère la liste complète de tous les agendas.
        /// Un agenda correspond aux disponibilités horaires d’un médecin.
        /// </summary>
        /// <returns>Liste des objets Agenda</returns>
        public List<Agenda> GetListeAgenda()
        {
            return db.Agenda.ToList();
        }


        /// <summary>
        /// Ajoute un nouvel agenda (planning) pour un médecin.
        /// </summary>
        /// <param name="agenda">Objet Agenda à ajouter</param>
        /// <returns>True si l’ajout a réussi, sinon False</returns>
        public bool AddAgenda(Agenda agenda)
        {
            try
            {
                db.Agenda.Add(agenda);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Met à jour un agenda existant.
        /// </summary>
        /// <param name="agenda">Objet Agenda contenant les modifications</param>
        /// <returns>True si la mise à jour a réussi, sinon False</returns>

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

        /// <summary>
        /// Recherche un médecin à partir de son identifiant.
        /// Cette méthode peut être utilisée pour vérifier à qui appartient un agenda.
        /// </summary>
        /// <param name="id">Identifiant du médecin</param>
        /// <returns>Objet Medcin correspondant ou null</returns>
        public Medcin GetMedecinById(int id)
        {
            return db.Medcin.Find(id);

        }

        /// <summary>
        /// Supprime un agenda à partir de son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l’agenda</param>
        /// <returns>True si la suppression a réussi, sinon False</returns>
        public bool DeleteAgenda(int id)
        {
            try
            {
                var agenda = db.Agenda.Find(id);
                if (agenda != null)
                {
                    db.Agenda.Remove(agenda);
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

        /// <summary>
        /// Récupère un agenda spécifique à partir de son ID.
        /// </summary>
        /// <param name="id">Identifiant de l’agenda</param>
        /// <returns>Objet Agenda correspondant ou null</returns>
        public Agenda GetAgendaById(int id)
        {
            return db.Agenda.Find(id);
        }


        public List<Agenda> GetAgendaByMedecin(int idMedecin)
        {
            return db.Agenda
                     .Include(a => a.Medcin)
                     .Where(a => a.IdMedcin == idMedecin)
                     .ToList();
        }


    }
}
