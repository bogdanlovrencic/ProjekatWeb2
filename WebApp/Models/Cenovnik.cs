﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Cenovnik
    {
     
        public int Id { get; set; }

        public DateTime VaziOd { get; set; }

        public DateTime VaziDo { get; set; }

        public bool  Aktivan { get; set; }

        public long  Version { get; set; }


    }
}