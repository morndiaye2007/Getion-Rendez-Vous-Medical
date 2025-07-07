using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MetierappRvmedical.Model
{
    public class Patient: Personne
    {
        [Required, MaxLength(3)]
        public String GroupeSanguin {  get; set; }
        [Required]
        public float taille { get; set; }
        [Required]
        public float Poids { get; set; }

        public DateTime? DateNaissance { get; set; }
    }
}
