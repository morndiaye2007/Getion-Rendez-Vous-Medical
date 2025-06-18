using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRvMedical.dtos
{
    public class UtilisateurDto
    {
        public int Id { get; set; }
        public string NomUtilisateur { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; set; }
    }
}