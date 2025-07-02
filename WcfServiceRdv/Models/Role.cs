using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WcfServiceRdv.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }

        [Required]
        [MaxLength(50)]
        public string NomRole { get; set; }
    }
}