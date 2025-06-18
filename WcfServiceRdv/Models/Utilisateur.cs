using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceRdv.Models;

namespace WcfServiceRdv.Models
{
    public class Utilisateur: Personne
    {
        [MaxLength(20)]
        public String Identifiant {  get; set; }
        [MaxLength(250)]
        public String MotDePasse { get; set; }
        public bool Statut { get; set; }

    }
}
