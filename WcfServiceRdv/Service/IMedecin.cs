using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceRdv.Models;

namespace WcfServiceRdv.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IMedecin" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IMedecin
    {
        [OperationContract]
        void DoWork();




        /// <summary>
        ///     Cette section concerte l'ajout, la modif, la suppression d'un medecin
        /// </summary>
        /// <param name="medcin"></param>
        /// <returns></returns>

        [OperationContract]
        List<Medecin> GetAllMedecins();

        [OperationContract]
        bool UpdateMedecin(Medecin medcin);

        [OperationContract]
        bool AddMedecin(Medecin medcin);

        

        [OperationContract]
        bool DeleteMedcin(int id);

        [OperationContract]
        Medecin GetMedcinById(int id);

        [OperationContract]
        List<Specialite> GetListeSpecialites();

        [OperationContract]

        Specialite GetSpecialiteById(int id);

    }
}
