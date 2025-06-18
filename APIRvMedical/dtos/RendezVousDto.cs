using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRvMedical.dtos
{
    public class RendezVousDto
    {
        public int Id { get; set; }
        public int AgendaId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public string Statut { get; set; }
    }
}