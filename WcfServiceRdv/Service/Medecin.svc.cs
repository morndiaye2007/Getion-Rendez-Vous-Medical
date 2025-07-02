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
    // Nouveau nom pour éviter la confusion avec Models.Medecin
    public class MedecinService : IMedecin
    {
        BdRvMedicalContext db = new BdRvMedicalContext();

        public void DoWork()
        {
            // Peut rester vide
        }

        public List<Medecin> GetAllMedecins()
        {
            return db.Medecins.Include(m => m.Specialite).ToList();
        }

        public Medecin GetMedcinById(int id)
        {
            return db.Medecins.Include(m => m.Specialite).FirstOrDefault(m => m.IdU == id);
        }

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

        public bool UpdateMedecin(Medecin medecin)
        {
            try
            {
                db.Entry(medecin).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.Message);
                return false;
            }
        }

        public bool DeleteMedcin(int id)
        {
            try
            {
                var medecin = db.Medecins.Find(id);
                if (medecin != null)
                {
                    db.Medecins.Remove(medecin);
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

        public List<Specialite> GetListeSpecialites()
        {
            return db.Specialites.ToList();
        }

        public Specialite GetSpecialiteById(int id)
        {
            return db.Specialites.Find(id);
        }
    }
}
