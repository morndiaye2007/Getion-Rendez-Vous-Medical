using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRvMedical.dtos
{
    public class SecretaireDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
    }
}