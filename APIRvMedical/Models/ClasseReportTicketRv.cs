using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRV.Model
{
    public class ClasseReportTicketRv
    {
        public string NomPrenom {  get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DaterV { get; set; }
        public string Medecin {  get; set; }
        public string HeureRv { get; set; }
        public byte[] DataQr { get; set; }
    }
}
