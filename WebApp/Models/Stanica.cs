using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Stanica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }

    
        public List<Linija> Linije { get; set; }

        public bool Aktivna { get; set; }

    }
}