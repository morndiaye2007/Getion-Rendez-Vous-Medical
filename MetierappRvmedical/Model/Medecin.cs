using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionRV.View;

namespace MetierappRvmedical.Model
{
    public class Medecin : Utilisateur
    {
       // [MaxLength(100)]
        //public String Specialite {  get; set; }
        public int? IdSpecialite { get; set; }

        [ForeignKey("IdSpecialite")]
        public virtual Specialite Specialite { get; set; }
        
        [MaxLength(10)]
        public String NumeroOrdre { get; set; }
        public virtual ICollection<Agenda> agenda { get; set; }
    }
}
