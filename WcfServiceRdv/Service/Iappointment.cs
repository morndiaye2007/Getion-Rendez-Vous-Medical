using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceRdv.Models;
using static AppGestionRdv.Service.appointment;

namespace WcfServiceRdv.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "Iappointment" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface Iappointment
    {
        [OperationContract]
        void DoWork();



        [OperationContract]
        List<RendezVous> GetAllRendezVous();

        [OperationContract]
        bool AddRendezVous(RendezVous rdv);

        [OperationContract]
        bool UpdateRendezVous(RendezVous rdv);

        [OperationContract]
        bool DeleteRendezVous(int id);

        [OperationContract]
        RendezVous GetRendezVousById(int id);

        // Récupérer tous les soins
        [OperationContract]
        List<Soin> GetSoin();

        // Récupérer les médecins associés à un soin
        [OperationContract]
        List<MedecinViewModel> GetMedecinsParSoin(int soinId);

        // Récupérer l'agenda d'un médecin
        [OperationContract]
        Agenda GetAgendaParMedecin(int medecinId);

        // Récupérer les créneaux déjà pris pour un médecin à une date donnée
        [OperationContract]
        List<string> GetCreneauxReserves(int medecinId, DateTime dateRdv);

        

        [OperationContract]
        Soin GetSoinById(int id);

        [OperationContract]
        bool IsCreneauDisponible(int medecinId, DateTime dateRdv, string heureRdv);

        [OperationContract]
        EmailConfirmationData GetEmailConfirmationData(int rdvId);
    }
}
