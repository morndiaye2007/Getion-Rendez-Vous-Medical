using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierappRvmedical.Model
{
    public class Soin
    {
        [Key]
        public int Idsoin {  get; set; }
    }
}
