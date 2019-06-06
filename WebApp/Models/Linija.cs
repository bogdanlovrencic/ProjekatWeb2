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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLinije { get; set; }

        public ICollection<Stanica> Stanice { get; set; }

        public TipRedaVoznje TipRedaVoznje { get; set; }

        public string Relacija { get; set; }

        public Linija()
        {
            Stanice = new HashSet<Stanica>();
        }
    }
}