﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestAPIRvMedical.Model
{
    [Table("Patients")]
    public class Personne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdU { get; set; }

        [Required, MaxLength(160)]
        public string NomPrenom { get; set; }

        [Required, MaxLength(160)]
        public string Adresse { get; set; }

        [Required, MaxLength(80), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(200)]
        public string Tel { get; set; }

    }
}
