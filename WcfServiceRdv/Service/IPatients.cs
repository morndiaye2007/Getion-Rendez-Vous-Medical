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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IPatients" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IPatients
    {
        [OperationContract]
        void DoWork();


        /// <summary>
        /// Gestion des patients
        /// </summary>
        /// <returns></returns>

        [OperationContract]
        List<Patient> GetAllPatients();

        [OperationContract]
        bool AddPatient(Patient p);

        [OperationContract]
        bool UpdatePatient(Patient p);

        [OperationContract]
        bool DeletePatient(int id);

        [OperationContract]
        Patient GetPatientById(int id);

    }
}
