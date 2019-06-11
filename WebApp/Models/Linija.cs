using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Linija
    {      
        [Key]     
        public string IdLinije { get; set; }

        public ICollection<Stanica> Stanice { get; set; }

        public string TipRedaVoznje { get; set; }

        public string Relacija { get; set; }

        public Linija()
        {
            Stanice = new HashSet<Stanica>();
        }

        public Linija(string id,string tip,string relacija)
        {
            IdLinije = id;
            TipRedaVoznje = tip;
            Relacija = relacija;
            Stanice = new HashSet<Stanica>();
        }


    }
}