using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceRdv.Models;

namespace AppGestionRdv.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IAgend" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAgend
    {
        [OperationContract]
        void DoWork();



        /// <summary>
        /// Cette section concerne la gestion de l'agenda du medecin 
        /// </summary>
        /// <param name="agenda"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateAgenda(Agenda agenda);

        [OperationContract]
        bool AddAgenda(Agenda agenda);

        [OperationContract]
        List<Agenda> GetListeAgenda();

        [OperationContract]
        Medcin GetMedecinById(int id);

        [OperationContract]
        bool DeleteAgenda(int id);

        [OperationContract]
        Agenda GetAgendaById(int id);

        [OperationContract]
        List<Agenda> GetAgendaByMedecin(int idMedecin);
    }
}
