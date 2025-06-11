using System;

namespace APIRvMedical.DTOs
{
    public class RendezVousDto
    {
        public int IdRv { get; set; }
        public DateTime DateRv { get; set; }
        public string Statut { get; set; }

        public int IdMedecin { get; set; }
        public string NomMedecin { get; set; }

        public int IdPatient { get; set; }
        public string NomPatient { get; set; }

        public int IdSoin { get; set; }
        public string NomSoin { get; set; }
    }
}
