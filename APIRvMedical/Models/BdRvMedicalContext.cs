using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GestAPIRvMedical.Model;
using APIRvMedical.Model;
using MySql.Data.MySqlClient;

namespace GestionRV.Model
{
    [DbConfigurationType(typeof(MySqlConfiguration))]
    public class BdRvMedicalContext:DbContext
    {
        public BdRvMedicalContext() :base("bdRvMedicalContext")
        { }
        public DbSet<Personne> Personnees { get; set; }
        public DbSet<Patient> Patients { get; set; }    
        public DbSet<Utilisateur> Utilisateur { get;set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Secretaire> Secretaires { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }
        public DbSet<Specialite> Specialites { get; set; }
        public DbSet<GroupeSanguin> GroupeSanguins { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

        

    }
}
