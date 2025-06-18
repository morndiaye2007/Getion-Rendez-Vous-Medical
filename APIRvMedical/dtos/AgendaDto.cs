using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRvMedical.dtos
{
    public class AgendaDto
    {
        public int Id { get; set; }
        public int MedecinId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
    }
}