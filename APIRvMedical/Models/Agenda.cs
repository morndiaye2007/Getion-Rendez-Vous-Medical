using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRvMedical.Model
{
    public class Agenda
    {
        [Key]
        public int IdAgenda {  get; set; }
        public DateTime? DatePlanifie { get; set; }
        public String Titre {  get; set; }
        public String HeureDebut {  get; set; }
        public String HeureFin {  get; set; }
        public int Creneau { get; set; }
        public String Lieu { get; set; }
        public String Statut { get; set; }
        public int IdMedecin { get; set; }
        [ForeignKey("IdMedecin")]
        public Medecin Medecin { get; set; }

        public ICollection <RendezVous> rendezVous { get; set; }
    }
}
