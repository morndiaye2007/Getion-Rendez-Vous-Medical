using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRV.Model
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }

        [Required, MaxLength(50)]
        public string NomRole { get; set; }

        // Relation : un rôle peut être lié à plusieurs utilisateurs
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
