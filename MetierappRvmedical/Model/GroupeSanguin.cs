using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  MetierappRvmedical.Model
.Model
{
    public class GroupeSanguin
    {
        [Key]
        public int IdGroupeSanguin { get; set; }

        [Required, MaxLength(3)]
        public string CodeGroupeSanguin { get; set; }
    }
}
