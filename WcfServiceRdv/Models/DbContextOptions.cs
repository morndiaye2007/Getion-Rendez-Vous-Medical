using System.Data.Entity;

using MySql.Data.EntityFramework;

namespace WcfServiceRdv.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=bdRvMedicalContext") { }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }
        // Ajoute ici d'autres DbSet si nécessaire
    }
}
