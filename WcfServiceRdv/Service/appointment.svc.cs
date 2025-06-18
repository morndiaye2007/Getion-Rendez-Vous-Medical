using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceRdv.Models;
using AppGestionRdv.Helper;
using AppGestionRdv.Helper;

namespace WcfServiceRdv.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "appointment" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez appointment.svc ou appointment.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class appointment : Iappointment
    {
        public void DoWork()
        {
        }


        BdRvMedicalContext db = new BdRvMedicalContext();

        /// <summary>
        /// Récupère la liste de tous les rendez-vous enregistrés dans la base de données.
        /// </summary>
        /// <returns>Liste d'objets RendezVous</returns>

        public List<RendezVous> GetAllRendezVous()
        {

           

            return db.Rendezvous
                     .Include(r => r.Medcin)
                     .Include(r => r.Soin)
                     .ToList();
        }

        /// <summary>
        /// Ajoute un nouveau rendez-vous dans la base de données.
        /// </summary>
        /// <param name="rdv">Objet RendezVous à enregistrer</param>
        /// <returns>True si l'opération réussit, sinon False</returns>
        public bool AddRendezVous(RendezVous rdv)
        {
            try
            {
                db.Rendezvous.Add(rdv);
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
        /// Met à jour les informations d’un rendez-vous existant.
        /// </summary>
        /// <param name="rdv">Objet RendezVous modifié</param>
        /// <returns>True si la mise à jour réussit, sinon False</returns>
        public bool UpdateRendezVous(RendezVous rdv)
        {
            try
            {
                db.Entry(rdv).State = EntityState.Modified;
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
        /// Supprime un rendez-vous à partir de son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du rendez-vous</param>
        /// <returns>True si la suppression réussit, sinon False</returns>
        public bool DeleteRendezVous(int id)
        {
            try
            {
                var rdv = db.Rendezvous.Find(id);
                if (rdv != null)
                {
                    db.Rendezvous.Remove(rdv);
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
        /// Recherche un rendez-vous à partir de son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du rendez-vous</param>
        /// <returns>Objet RendezVous correspondant</returns>
        public RendezVous GetRendezVousById(int id)
        {
            return db.Rendezvous.Find(id);
        }

        /// <summary>
        /// Récupère la liste complète des soins disponibles dans l'établissement.
        /// </summary>
        /// <returns>Liste d'objets Soin</returns>
        public List<Soin> GetSoin()
        {

            return db.Soin.ToList();

        }

        /// <summary>
        /// Vérifie si un créneau horaire est disponible pour un médecin donné, à une date et heure précises.
        /// </summary>
        /// <param name="medecinId">ID du médecin</param>
        /// <param name="dateRdv">Date du rendez-vous</param>
        /// <param name="heureRdv">Heure du rendez-vous</param>
        /// <returns>True si le créneau est libre, sinon False</returns>
        public bool IsCreneauDisponible(int medecinId, DateTime dateRdv, string heureRdv)
        {
            return !db.Rendezvous.Any(rv => rv.IdMedcin == medecinId &&
                                           rv.DateRendezVous == dateRdv &&
                                           rv.HeureRdv == heureRdv);
        }



        /// <summary>
        /// Récupère un soin spécifique à partir de son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du soin</param>
        /// <returns>Objet Soin correspondant</returns>
        public Soin GetSoinById(int id)
        {
            return db.Soin.Find(id);
        }

        /// <summary>
        /// Récupère la liste des médecins qui proposent un soin spécifique.
        /// </summary>
        /// <param name="soinId">Identifiant du soin</param>
        /// <returns>Liste des médecins associés à ce soin</returns>
        public List<MedecinViewModel> GetMedecinsParSoin(int soinId)
        {

            return db.MedecinSoin
                .Where(ms => ms.IdSoin == soinId)
                .Select(ms => new MedecinViewModel
                {
                    IdU = ms.Medcin.IdU,
                    NomPrenom = ms.Medcin.NomPrenom
                })
                .ToList();

        }


        /// <summary>
        /// Récupère l'agenda d'un médecin (heures de début, fin, créneau).
        /// </summary>
        /// <param name="medecinId">ID du médecin</param>
        /// <returns>Objet Agenda associé</returns>
        public Agenda GetAgendaParMedecin(int medecinId)
        {

            var agenda = db.Agenda.FirstOrDefault(a => a.IdMedcin == medecinId);
            if (agenda == null) return null;

            return new Agenda
            {
                IdAgenda = agenda.IdAgenda,
                IdMedcin = agenda.IdMedcin,
                HeureDebut = agenda.HeureDebut,
                HeureFin = agenda.HeureFin,
                Creneau = agenda.Creneau
            };

        }
        /// <summary>
        /// Liste les créneaux déjà réservés pour un médecin donné à une date spécifique.
        /// </summary>
        /// <param name="medecinId">ID du médecin</param>
        /// <param name="dateRdv">Date du rendez-vous</param>
        /// <returns>Liste des heures déjà prises</returns>
        public List<string> GetCreneauxReserves(int medecinId, DateTime dateRdv)
        {

            return db.Rendezvous
                .Where(rv => rv.IdMedcin == medecinId && rv.DateRendezVous == dateRdv)
                .Select(rv => rv.HeureRdv)
                .ToList();
        }


        /// <summary>
        /// Récupère les informations nécessaires à l’envoi d’un email de confirmation pour un rendez-vous.
        /// </summary>
        /// <param name="rdvId">Identifiant du rendez-vous</param>
        /// <returns>Objet EmailConfirmationData contenant les infos du patient et du médecin</returns>
        public EmailConfirmationData GetEmailConfirmationData(int rdvId)
        {
            var rdv = db.Rendezvous.Find(rdvId);
            var medecin = db.Medcin.Find(rdv.IdMedcin);

            return new EmailConfirmationData
            {
                PatientName = rdv.NomPrenom,
                Email = rdv.Email,
                DateRdv = rdv.DateRendezVous,
                HeureRdv = rdv.HeureRdv,
                MedecinName = medecin?.NomPrenom
            };
        }

        /// <summary>
        /// Modèle de données pour envoyer un email de confirmation.
        /// </summary>
        public class EmailConfirmationData
        {
            [DataMember]
            public string PatientName { get; set; }

            [DataMember]
            public string Email { get; set; }

            [DataMember]
            public DateTime DateRdv { get; set; }

            [DataMember]
            public string HeureRdv { get; set; }

            [DataMember]
            public string MedecinName { get; set; }

            [DataMember]
            public string Telephone { get; set; }
        }

    }
}
