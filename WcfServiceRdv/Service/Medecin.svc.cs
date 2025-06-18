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
using System.IO;

namespace WcfServiceRdv.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Medecin" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Medecin.svc ou Medecin.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Medecin : IMedecin
    {
        public void DoWork()
        {
        }

        BdRvMedicalContext db = new BdRvMedicalContext();



        /// <summary>
        /// Récupère la liste de tous les médecins avec leur spécialité.
        /// </summary>
        /// <returns>Liste des médecins</returns>
        public List<Medecin> GetAllMedecins()
        {

            try
            {
               
                return db.Medecins.Include(m => m.Specialites).ToList();
            }
            catch (Exception ex)
            {
              File.AppendAllText(@"C:\Users\diabd\source\repos\G-etude\log\medecin_error.log", DateTime.Now + " => " + ex.ToString() + Environment.NewLine);
                throw;

                
            }
        }

        /// <summary>
        /// Ajoute un nouveau médecin à la base de données.
        /// </summary>
        /// <param name="medcin">Objet Medcin à ajouter</param>
        /// <returns>True si l'ajout réussit, sinon False</returns>
        public bool AddMedecin(Medecin medecin)
        {
            try
            {
                db.Medecins.Add(medecin);
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
        /// Modifie les informations d’un médecin existant.
        /// </summary>
        /// <param name="medcin">Objet Medcin modifié</param>
        /// <returns>True si la mise à jour réussit, sinon False</returns>

        public bool UpdateMedecin(Medecin medcin)
        {

            try
            {
                db.Entry(medcin).State = EntityState.Modified;
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
        /// Supprime un médecin de la base via son ID.
        /// </summary>
        /// <param name="id">ID du médecin à supprimer</param>
        /// <returns>True si la suppression réussit, sinon False</returns>
        public bool DeleteMedcin(int id)
        {
            try
            {
                var medcin = db.Medecins.Find(id);
                if (medcin != null)
                {
                    db.Medecins.Remove(medcin);
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
        /// Récupère les informations d’un médecin à partir de son identifiant.
        /// </summary>
        /// <param name="id">ID du médecin</param>
        /// <returns>Objet Medcin ou null si non trouvé</returns>
        public Medecin GetMedcinById(int id)
        {
          
            return db.Medecins.Find(id);
        }


        /// <summary>
        /// Récupère la liste des spécialités médicales disponibles.
        /// </summary>
        /// <returns>Liste des spécialités</returns>
        public List<Specialite> GetListeSpecialites()
        {

            return db.Specialites.ToList();

        }

        /// <summary>
        /// Récupère la liste de tous les rôles disponibles dans le système.
        /// </summary>
        /// <returns>Liste des rôles</returns>
        //public List<Role> GetListeRoles()
        //{

        //    return db.roles.ToList();

        //}

        /// <summary>
        /// Recherche une spécialité par son identifiant.
        /// </summary>
        /// <param name="id">ID de la spécialité</param>
        /// <returns>Objet Specialite ou null si non trouvé</returns>
        public Specialite GetSpecialiteById(int id)
        {

            return db.Specialites.Find(id);

        }
    }
}
