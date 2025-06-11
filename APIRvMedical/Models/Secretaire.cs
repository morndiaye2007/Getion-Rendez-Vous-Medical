﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRvMedical.Model
{
    public class Secretaire: Utilisateur
    {
        [MaxLength(15)]
        public String TelphoneFixe {  get; set; }
    }
}
