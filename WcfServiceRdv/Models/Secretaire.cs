﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceRdv.Models
{
    public class Secretaire: Utilisateur
    {
        [MaxLength(15)]
        public String TelphoneFixe {  get; set; }
    }
}
