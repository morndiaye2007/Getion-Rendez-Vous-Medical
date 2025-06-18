using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRvMedical.dtos
{
    public class MedecinDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int SpecialiteId { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}