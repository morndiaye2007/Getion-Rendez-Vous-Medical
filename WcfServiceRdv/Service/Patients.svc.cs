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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Patients" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Patients.svc ou Patients.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Patients : IPatients
    {
        public void DoWork()
        {
        }
        BdRvMedicalContext db = new BdRvMedicalContext();

        /// <summary>
        /// Récupère la liste complète de tous les patients enregistrés dans la base de données.
        /// </summary>
        /// <returns>Liste des patients</returns>>

        public List<Patient> GetAllPatients()
        {
            return db.Patients.ToList();
        }

        /// <summary>
        /// Ajoute un nouveau patient dans la base de données.
        /// </summary>
        /// <param name="p">Objet Patient à ajouter</param>
        /// <returns>Vrai si l'opération réussit, Faux sinon</returns>

        public bool AddPatient(Patient p)
        {
            try
            {
                db.Patients.Add(p);
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
        /// Met à jour les informations d'un patient existant.
        /// </summary>
        /// <param name="p">Objet Patient avec les nouvelles données</param>
        /// <returns>True si la mise à jour réussit, sinon False</returns>
        public bool UpdatePatient(Patient p)
        {
            try
            {
                db.Entry(p).State = EntityState.Modified;
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
        /// Supprime un patient de la base de données via son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du patient</param>
        /// <returns>True si la suppression réussit, sinon False</returns>
        public bool DeletePatient(int id)
        {
            try
            {
                var p = db.Patients.Find(id);
                if (p != null)
                {
                    db.Patients.Remove(p);
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
        /// Récupère les informations d’un patient à partir de son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du patient</param>
        /// <returns>Objet Patient correspondant à l’ID, ou null si introuvable</returns>
        public Patient GetPatientById(int id)
        {
            return db.Patients.Find(id);
        }
    }
}
