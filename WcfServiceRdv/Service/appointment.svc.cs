        using System;
        using System.Collections.Generic;
        using System.Data.Entity;
        using System.Linq;
        using System.Runtime.Serialization;
        using System.ServiceModel;
        using System.ServiceModel.Web;
        using System.Text;
        using WcfServiceRdv.Models;
        using WcfServiceRdv.Helper;

        namespace WcfServiceRdv.Service
        {
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "appointment" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez appointment.svc ou appointment.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class appointment : Iappointment
    {
        BdRvMedicalContext db = new BdRvMedicalContext();

        public List<RendezVous> GetAllRendezVous()
        {
            return db.RendezVous
                     .Include(r => r.Medecin)
                     .Include(r => r.Patient)
                     .Include(r => r.Soin)
                     .ToList();
        }

        public bool AddRendezVous(RendezVous rdv)
        {
            try
            {
                db.RendezVous.Add(rdv);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.Message);
                return false;
            }
        }

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

        public bool DeleteRendezVous(int id)
        {
            try
            {
                var rdv = db.RendezVous.Find(id);
                if (rdv != null)
                {
                    db.RendezVous.Remove(rdv);
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

        public RendezVous GetRendezVousById(int id)
        {
            return db.RendezVous.Find(id);
        }

        public bool IsCreneauDisponible(int medecinId, DateTime dateRdv, string heureRdv)
        {
            return !db.RendezVous.Any(rv => rv.IdMedecin == medecinId &&
                                            rv.DateRv == dateRdv &&
                                            rv.HeureRv == heureRdv);
        }

        public List<string> GetCreneauxReserves(int medecinId, DateTime dateRdv)
        {
            return db.RendezVous
                     .Where(rv => rv.IdMedecin == medecinId && rv.DateRv == dateRdv)
                     .Select(rv => rv.HeureRv)
                     .ToList();
        }

        public List<Soin> GetSoin()
        {
            return db.Soin.ToList();
        }

        public Soin GetSoinById(int id)
        {
            return db.Soin.Find(id);
        }

        public Agenda GetAgendaParMedecin(int medecinId)
        {
            return db.Agenda.FirstOrDefault(a => a.IdMedecin == medecinId);
        }

        public EmailConfirmationData GetEmailConfirmationData(int rdvId)
        {
            var rdv = db.RendezVous
                        .Include(r => r.Patient)
                        .Include(r => r.Medecin)
                        .FirstOrDefault(r => r.IdRv == rdvId);

            if (rdv == null) return null;

            return new EmailConfirmationData
            {
                PatientName = rdv.Patient.NomPrenom,
                Email = rdv.Patient.Email,
                DateRdv = rdv.DateRv,
                HeureRdv = rdv.HeureRv,
            };
        }
    }

    [DataContract]
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
